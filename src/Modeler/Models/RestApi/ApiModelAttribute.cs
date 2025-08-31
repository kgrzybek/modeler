using Modeler.Models.RestApi.Types;

namespace Modeler.Models.RestApi;

public record ApiModelAttribute(string Name, AttributeType Type, bool Required);
