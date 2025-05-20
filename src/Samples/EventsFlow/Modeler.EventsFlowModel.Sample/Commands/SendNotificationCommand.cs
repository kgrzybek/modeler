namespace Modeler.EventsFlowModel.Sample.Commands;

public class SendNotificationCommand : Command
{
    public static Command Create() => new SendNotificationCommand()
        .WithName("Send Notification");
}