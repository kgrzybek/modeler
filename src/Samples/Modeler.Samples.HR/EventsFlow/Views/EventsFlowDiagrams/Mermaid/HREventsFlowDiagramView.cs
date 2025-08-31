using Modeler.Samples.HR.EventsFlow.Commands;
using Modeler.Samples.HR.EventsFlow.Events;
using Modeler.Views.EventsFlow.Diagram.Mermaid;

namespace Modeler.Samples.HR.EventsFlow.Views.EventsFlowDiagrams.Mermaid;

public class HREventsFlowDiagramView : MermaidEventFlowsDiagramView
{
    public HREventsFlowDiagramView(HREventsFlowModel model)
    {
        FlowElementsVisible =
        [
            model.GetCommand<AddEmployeeCommand>(),
            model.GetCommand<SendNotificationCommand>(),
            model.GetCommand<RegenerateEmployeesReportCommand>(),
            model.GetEvent<EmployeeAddedEvent>(),
            model.GetEvent<EmployeeChangedEvent>(),
            model.GetEvent<EmailSentEvent>(),
            model.GetEvent<SmsSentEvent>(),
            model.GetEvent<EmployeesReportRegeneratedEvent>()
        ];
    }
}