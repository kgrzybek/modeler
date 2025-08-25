using Modeler.EventsFlowModel;
using Modeler.EventsFlowModel.Views.Mermaid;
using Modeler.Full.Sample.EventsFlow.Commands;
using Modeler.Full.Sample.EventsFlow.Events;

namespace Modeler.Full.Sample.EventsFlow.Views.Mermaid;

public class HREventsFlowViewDefinition
{
    public const string Id = "HREventsFlowView";
    
    public static MermaidEventFlowsView Create(HREventsFlowModel model)
    {
        var flowElements = new List<FlowElement>
        {
            model.GetCommand<AddEmployeeCommand>(),
            model.GetCommand<SendNotificationCommand>(),
            model.GetCommand<RegenerateEmployeesReportCommand>(),
            model.GetEvent<EmployeeAddedEvent>(),
            model.GetEvent<EmployeeChangedEvent>(),
            model.GetEvent<EmailSentEvent>(),
            model.GetEvent<SmsSentEvent>(),
            model.GetEvent<EmployeesReportRegeneratedEvent>(),
        };
        var view = new MermaidEventFlowsView(
            Id,
            flowElements);

        return view;
    }
}