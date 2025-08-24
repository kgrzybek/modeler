using Modeler.Messaging;
using Models.Elements;

namespace Modeler.Full.Sample.Messaging;

public class EmployeeAddedEventMessage : IMessage
{
    public EmployeeAddedEventMessage()
    {
        Name = "Employee Added Event";
        Id = ElementIdGenerator.GenerateElementId(this.GetType(), Name);
    }

    public string Name { get; }
    public string Id { get; }
}