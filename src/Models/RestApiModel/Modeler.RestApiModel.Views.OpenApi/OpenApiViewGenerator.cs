using System.Text.Json;

namespace Modeler.RestApiModel.Views.OpenApi;

public class OpenApiViewGenerator
{
    private readonly IOpenApiRestApiViewsOutput<OpenApiView> _viewsOutput;

    public OpenApiViewGenerator(IOpenApiRestApiViewsOutput<OpenApiView> viewsOutput)
    {
        _viewsOutput = viewsOutput;
    }

    public void Generate(List<OpenApiView> views)
    {
        var outputItems = new List<OpenApiRestApiViewsOutputItem<OpenApiView>>();
        foreach (var view in views)
        {
            var spec = GenerateSpecification(view.Model);
            var json = JsonSerializer.Serialize(spec, new JsonSerializerOptions { WriteIndented = true });
            outputItems.Add(new OpenApiRestApiViewsOutputItem<OpenApiView>(view.Id, view, json));
        }
        _viewsOutput.Execute(outputItems);
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
                properties[attr.Name] = new Dictionary<string, object>
                {
                    ["type"] = attr.Type
                };
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
}
