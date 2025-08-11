using Modeler.EventsFlowModel;

namespace Modeler.Full.Sample.EventsFlow.Commands;

public class SendNotificationCommand : Command
{
    public static Command Create() => new SendNotificationCommand()
        .WithName("Send Notification");
}