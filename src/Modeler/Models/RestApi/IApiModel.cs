using Modeler.Models.Common.Elements;

namespace Modeler.Models.RestApi;

public interface IApiModel : IElement
{
    public List<Endpoint> GetEndpoints();

    public List<ApiObjectModel> GetApiObjectModels();
}