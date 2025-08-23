using Modeler.Messaging;
using Models.Elements;

namespace Modeler.Full.Sample.Messaging;

public class PersonAddedEventMessage : IMessage
{
    public PersonAddedEventMessage()
    {
        Name = "Person Added Event";
        Id = ElementIdGenerator.GenerateElementId(this.GetType(), Name);
    }

    public string Name { get; }
    public string Id { get; }
}