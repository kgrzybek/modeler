
using Modeler.Models.Components;
using Modeler.Samples.HR.Components.Types;

namespace Modeler.Samples.HR.Components.Brokers;

public class MessagesBroker : Component
{
    public MessagesBroker() : base("Messages Broker", new MessagesBrokerComponentType())
    {
    }
}