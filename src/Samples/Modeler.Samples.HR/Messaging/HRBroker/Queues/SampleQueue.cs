using Modeler.Models.Common;
using Modeler.Models.Common.Elements;
using Modeler.Models.Messaging;

namespace Modeler.Samples.HR.Messaging.HRBroker.Queues;

public class SampleQueue : IQueue
{
    public string Name { get; } = "Sample";
    public string Id { get; } = ElementIdGenerator.GenerateElementId(typeof(SampleQueue), "Sample");
}