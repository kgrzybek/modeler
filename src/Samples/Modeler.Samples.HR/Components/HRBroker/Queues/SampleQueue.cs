using Modeler.Models.Common.Elements;
using Modeler.Models.Messaging;

namespace Modeler.Samples.HR.Components.HRBroker.Queues;

public class SampleQueue : IQueue
{
    public string Name { get; } = "Sample";
    public string Id { get; } = ElementIdGenerator.GenerateElementId(typeof(SampleQueue), "Sample");
}