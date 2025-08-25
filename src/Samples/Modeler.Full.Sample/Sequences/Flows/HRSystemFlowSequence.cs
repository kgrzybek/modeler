using Modeler.Full.Sample.Apis.Endpoints;
using Modeler.Full.Sample.Components.ExternalSystems;
using Modeler.Full.Sample.Components.System.Backend;
using Modeler.Full.Sample.Components.System.Database;
using Modeler.Full.Sample.Components.System.Frontend;
using Modeler.Full.Sample.Messaging;
using Modeler.Full.Sample.Sequences.Participants;
using Modeler.SequenceModel;
using Modeler.SequenceModel.Sequences;

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
        var addEmployeeEndpoint = elementsRegistry.GetElement<AddEmployeeEndpoint>();

        var builder = new SequenceBuilder<HRSystemFlowSequence>("HR System Flow Sequence");

        builder.AddSynchronousRequestMessage(user, "addEmployee", "Employee", frontend);
        builder.AddSynchronousRequestMessage(frontend, addEmployeeEndpoint, backend);
        
        builder.AddSelfMessage(backend, "Validate", "EmployeeDto");
        
        builder.AddSynchronousRequestMessage(backend, "addEmployee", "SQL", backendDatabase);
        builder.AddOkResponseMessage(backendDatabase, "addEmployee", backend);
        builder.AddEventMessage(backend, employeeAddedEvent, crm);
        builder.AddSynchronousResponseMessage(backend, addEmployeeEndpoint, frontend);
        
        builder.AddOkResponseMessage(frontend, "addEmployee", user);

        var sequence = builder.Build();
        
        return sequence;
    }
}