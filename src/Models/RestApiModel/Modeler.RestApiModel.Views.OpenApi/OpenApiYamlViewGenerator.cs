using System.Text;
using System.Text.Json;
using Modeler.RestApiModel.Types;

namespace Modeler.RestApiModel.Views.OpenApi;

public class OpenApiYamlViewGenerator
{
    private readonly IOpenApiRestApiViewsOutput<OpenApiView> _viewsOutput;

    public OpenApiYamlViewGenerator(IOpenApiRestApiViewsOutput<OpenApiView> viewsOutput)
    {
        _viewsOutput = viewsOutput;
    }

    public void Generate(List<OpenApiView> views)
    {
        var outputItems = new List<OpenApiRestApiViewsOutputItem<OpenApiView>>();
        foreach (var view in views)
        {
            var spec = GenerateSpecification(view.Model);
            var yaml = ConvertToYaml(spec);
            outputItems.Add(new OpenApiRestApiViewsOutputItem<OpenApiView>(view.Id, view, yaml));
        }
        _viewsOutput.Execute(outputItems);
    }

    private static string ConvertToYaml(object obj)
    {
        var element = JsonSerializer.SerializeToElement(obj);
        var sb = new StringBuilder();
        WriteYaml(element, sb, 0);
        return sb.ToString();
    }

    private static void WriteYaml(JsonElement element, StringBuilder sb, int indent)
    {
        var indentStr = new string(' ', indent);
        switch (element.ValueKind)
        {
            case JsonValueKind.Object:
                foreach (var prop in element.EnumerateObject())
                {
                    sb.Append(indentStr);
                    sb.Append(prop.Name);
                    sb.Append(':');
                    if (prop.Value.ValueKind == JsonValueKind.Object || prop.Value.ValueKind == JsonValueKind.Array)
                    {
                        sb.AppendLine();
                        WriteYaml(prop.Value, sb, indent + 2);
                    }
                    else
                    {
                        sb.Append(' ');
                        sb.Append(ConvertScalar(prop.Value));
                        sb.AppendLine();
                    }
                }
                break;
            case JsonValueKind.Array:
                foreach (var item in element.EnumerateArray())
                {
                    sb.Append(indentStr);
                    sb.Append("- ");
                    if (item.ValueKind == JsonValueKind.Object || item.ValueKind == JsonValueKind.Array)
                    {
                        sb.AppendLine();
                        WriteYaml(item, sb, indent + 2);
                    }
                    else
                    {
                        sb.Append(ConvertScalar(item));
                        sb.AppendLine();
                    }
                }
                break;
            default:
                sb.Append(indentStr);
                sb.Append(ConvertScalar(element));
                sb.AppendLine();
                break;
        }
    }

    private static string ConvertScalar(JsonElement element)
    {
        return element.ValueKind switch
        {
            JsonValueKind.String => "\"" + element.GetString()!.Replace("\"", "\\\"") + "\"",
            JsonValueKind.Number or JsonValueKind.True or JsonValueKind.False => element.GetRawText(),
            JsonValueKind.Null => "null",
            _ => element.GetRawText()
        };
    }

    private static object GenerateSpecification(Model model)
    {
        var paths = new Dictionary<string, Dictionary<string, object>>();
        foreach (var ep in model.GetEndpoints())
        {
            if (!paths.ContainsKey(ep.Path))
            {
                paths[ep.Path] = new Dictionary<string, object>();
            }

            var methodObj = new Dictionary<string, object>
            {
                ["summary"] = ep.Name
            };

            if (ep.RequestModel != null)
            {
                methodObj["requestBody"] = new Dictionary<string, object>
                {
                    ["required"] = true,
                    ["content"] = new Dictionary<string, object>
                    {
                        ["application/json"] = new Dictionary<string, object>
                        {
                            ["schema"] = new Dictionary<string, object>
                            {
                                ["$ref"] = $"#/components/schemas/{ep.RequestModel.Name}"
                            }
                        }
                    }
                };
            }

            if (ep.ResponseModel != null)
            {
                methodObj["responses"] = new Dictionary<string, object>
                {
                    ["200"] = new Dictionary<string, object>
                    {
                        ["description"] = "Success",
                        ["content"] = new Dictionary<string, object>
                        {
                            ["application/json"] = new Dictionary<string, object>
                            {
                                ["schema"] = new Dictionary<string, object>
                                {
                                    ["$ref"] = $"#/components/schemas/{ep.ResponseModel.Name}"
                                }
                            }
                        }
                    }
                };
            }

            paths[ep.Path][ep.Method.ToLower()] = methodObj;
        }

        var schemas = new Dictionary<string, object>();
        foreach (var apiModel in model.GetApiModels())
        {
            var properties = new Dictionary<string, object>();
            var required = new List<string>();
            foreach (var attr in apiModel.Attributes)
            {
                properties[attr.Name] = BuildSchema(attr.Type);
                if (attr.Required)
                {
                    required.Add(attr.Name);
                }
            }
            var schema = new Dictionary<string, object>
            {
                ["type"] = "object",
                ["properties"] = properties
            };
            if (required.Count > 0)
            {
                schema["required"] = required;
            }
            schemas[apiModel.Name] = schema;
        }

        return new Dictionary<string, object>
        {
            ["openapi"] = "3.0.0",
            ["info"] = new Dictionary<string, object>
            {
                ["title"] = "Generated API",
                ["version"] = "1.0.0"
            },
            ["paths"] = paths,
            ["components"] = new Dictionary<string, object>
            {
                ["schemas"] = schemas
            }
        };
    }

    private static Dictionary<string, object> BuildSchema(AttributeType type)
    {
        return type switch
        {
            ArrayType array => new Dictionary<string, object>
            {
                ["type"] = "array",
                ["items"] = BuildSchema(array.ElementType)
            },
            ModelType model => new Dictionary<string, object>
            {
                ["$ref"] = $"#/components/schemas/{model.Model.Name}"
            },
            _ => new Dictionary<string, object>
            {
                ["type"] = type.Name
            }
        };
    }
}
