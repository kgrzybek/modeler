using Modeler.EventsFlowModel.Views.Mermaid;
using Modeler.Full.Sample.EventsFlow.Commands;
using Modeler.Full.Sample.EventsFlow.Events;

namespace Modeler.Full.Sample.EventsFlow.Views.EventsFlowDiagrams.Mermaid;

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