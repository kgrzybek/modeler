using Modeler.Full.Sample.Components.ExternalSystems;
using Modeler.Full.Sample.Components.System.Backend;
using Modeler.Full.Sample.Components.System.Database;
using Modeler.Full.Sample.Components.System.Frontend;
using Modeler.Full.Sample.EventsFlow.Events;
using Modeler.Full.Sample.Messaging;
using Modeler.Full.Sample.Sequences.Parameters;
using Modeler.Full.Sample.Sequences.Participants;
using Modeler.SequenceModel;

namespace Modeler.Full.Sample.Sequences.Flows;

public class HRSystemFlowSequence : Sequence
{
    public static HRSystemFlowSequence Create(ElementsRegistry elementsRegistry)
    {
        var user = elementsRegistry.GetElement<UserParticipant>();
        var frontend = elementsRegistry.GetElement<HRFrontendApplication>();
        var backend = elementsRegistry.GetElement<HRBackendApplication>();
        var backendDatabase = elementsRegistry.GetElement<HRDatabase>();
        var crm = elementsRegistry.GetElement<CRM>();
        var employeeAddedEvent = elementsRegistry.GetElement<EmployeeAddedEventMessage>();

        var builder = new SequenceBuilder<HRSystemFlowSequence>("HR System Flow Sequence");

        builder.AddSynchronousRequestMessage(user, "addEmployee", new StringMessageParameter("Employee"), frontend);
        builder.AddSynchronousRequestMessage(frontend, "addEmployee", new StringMessageParameter("EmployeeDto"), backend);
        
        builder.AddSelfMessage(backend, "Validate", new StringMessageParameter("EmployeeDto"));
        
        builder.AddSynchronousRequestMessage(backend, "addEmployee", new StringMessageParameter("SQL"), backendDatabase);
        builder.AddSynchronousResponseMessage(backendDatabase, "OK", new NoMessageParameters(), backend);
        builder.AddEventMessage(backend, employeeAddedEvent, crm);
        builder.AddSynchronousResponseMessage(backend, "OK", new NoMessageParameters(), frontend);
        
        builder.AddSynchronousResponseMessage(frontend, "OK", new NoMessageParameters(), user);

        var sequence = builder.Build();
        
        return sequence;
    }
}