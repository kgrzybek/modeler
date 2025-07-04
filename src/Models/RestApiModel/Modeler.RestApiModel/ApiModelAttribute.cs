using Modeler.RestApiModel.Types;

namespace Modeler.RestApiModel;

public record ApiModelAttribute(string Name, AttributeType Type, bool Required);
