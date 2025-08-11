using Modeler.EventsFlowModel;
using Modeler.Full.Sample.EventsFlow.Commands;
using Modeler.Full.Sample.EventsFlow.Events;

namespace Modeler.Full.Sample.EventsFlow;

public class HRFlowModel : FlowModel
{
    public static void Create(HREventsFlowModel model)
    {
        var addEmployeeCommand = model.GetCommand<AddEmployeeCommand>();
        var sendNotificationCommand = model.GetCommand<SendNotificationCommand>();
        var regenerateEmployeesReportCommand = model.GetCommand<RegenerateEmployeesReportCommand>();
        
        var employeeAddedEvent = model.GetEvent<EmployeeAddedEvent>();
        var employeeChangedEvent = model.GetEvent<EmployeeChangedEvent>();
        var emailSentEvent = model.GetEvent<EmailSentEvent>();
        var smsSentEvent = model.GetEvent<SmsSentEvent>();
        var employeesReportRegeneratedEvent = model.GetEvent<EmployeesReportRegeneratedEvent>();

        addEmployeeCommand.Triggers(employeeAddedEvent);
        employeeAddedEvent.Triggers(sendNotificationCommand);
        employeeAddedEvent.Triggers(regenerateEmployeesReportCommand);
        sendNotificationCommand.Triggers(emailSentEvent);
        sendNotificationCommand.Triggers(smsSentEvent);
        employeeChangedEvent.Triggers(regenerateEmployeesReportCommand);
        regenerateEmployeesReportCommand.Triggers(employeesReportRegeneratedEvent);
    }
}