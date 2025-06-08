# Rest API

## Example

See full example [here](../../../src/Samples/RestApi/Modeler.RestApiModel.Sample).

## Design

### API models

API models describe request and response bodies. They are created by inheriting from `ApiModel` and defining attributes:

```csharp
public class AddEmployeeRequest : ApiModel
{
    public static ApiModel Create() => new AddEmployeeRequest()
        .WithName("AddEmployeeRequest")
        .WithAttribute("FirstName", StringType.Create(), true)
        .WithAttribute("LastName", StringType.Create(), true);
}
```

### Endpoints

Endpoints represent REST API operations. They are created by inheriting from `Endpoint`:

```csharp
public class AddEmployeeEndpoint : Endpoint
{
    public static Endpoint Create() => new AddEmployeeEndpoint()
        .WithName("Add Employee")
        .WithMethod("POST")
        .WithPath("/employees")
        .WithRequestModel(AddEmployeeRequest.Create())
        .WithResponseModel(EmployeeModel.Create());
}
```

## Views

### AsciiDoc

* `AsciiDocApiModelsViewGenerator` - generates tables with all API models.
* `AsciiDocEndpointsViewGenerator` - generates table listing endpoints.

### OpenAPI

* `OpenApiViewGenerator` - produces OpenAPI specification in JSON.
* `OpenApiYamlViewGenerator` - produces OpenAPI specification in YAML.
