using Modeler.Models.EventsFlow;

namespace Modeler.Samples.HR.EventsFlow.Commands;

public class SendNotificationCommand : Command
{
    public static Command Create() => new SendNotificationCommand()
        .WithName("Send Notification");
}