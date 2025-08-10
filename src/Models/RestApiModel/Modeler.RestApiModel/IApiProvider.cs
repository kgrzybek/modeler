using Models.Elements;

namespace Modeler.RestApiModel;

public interface IApiProvider : IElement
{
    public IApiModel ProvidedApi { get; }
}