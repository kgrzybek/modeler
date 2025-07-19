using Models.Elements;

namespace Modeler.RestApiModel;

public interface IApiModel : IElement
{
    public List<Endpoint> GetEndpoints();

    public List<ApiObjectModel> GetApiObjectModels();
}