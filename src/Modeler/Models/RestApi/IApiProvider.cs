using Modeler.Models.Common.Elements;

namespace Modeler.Models.RestApi;

public interface IApiProvider : IElement
{
    public IApiModel ProvidedApi { get; }
}