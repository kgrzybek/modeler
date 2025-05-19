using Modeler.EventsFlowModel.Sample.Commands;
using Modeler.EventsFlowModel.Sample.Events;
using Modeler.EventsFlowModel.Views.Mermaid;

namespace Modeler.EventsFlowModel.Sample.Views.Mermaid;

public class HREventsFlowViewDefinition : MermaidEventFlowsViewDefinition
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