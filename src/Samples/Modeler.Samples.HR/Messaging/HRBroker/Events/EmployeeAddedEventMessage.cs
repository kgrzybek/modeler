using Modeler.Models.Common;
using Modeler.Models.Common.Elements;
using Modeler.Models.Messaging;

namespace Modeler.Samples.HR.Messaging.HRBroker.Events;

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