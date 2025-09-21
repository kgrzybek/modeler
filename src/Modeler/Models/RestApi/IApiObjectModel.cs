using Modeler.Models.Common.Elements;

namespace Modeler.Models.RestApi;

public interface IApiObjectModel : IElement
{
    public List<ApiModelAttribute> Attributes { get; }
}