using Modeler.Models.Common.Elements;

namespace Modeler.Models.RestApi;

public interface IApiConsumer : IElement
{
    public IApiModel ConsumingApi { get; }
}