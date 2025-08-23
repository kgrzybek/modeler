using Modeler.Messaging;
using Models.Elements;

namespace Modeler.Full.Sample.Messaging;

public class SampleQueue : IQueue
{
    public string Name { get; } = "Sample";
    public string Id { get; } = ElementIdGenerator.GenerateElementId(typeof(SampleQueue), "Sample");
}