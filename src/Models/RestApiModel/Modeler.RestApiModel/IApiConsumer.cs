using Models.Elements;

namespace Modeler.RestApiModel;

public interface IApiConsumer : IElement
{
    public IApiModel ConsumingApi { get; }
}