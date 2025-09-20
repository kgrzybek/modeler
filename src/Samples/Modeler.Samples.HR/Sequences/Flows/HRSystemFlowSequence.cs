using Modeler.Models.Sequence.Sequences;
using Modeler.Samples.HR.Components.ExternalSystems;
using Modeler.Samples.HR.Components.HRBroker.Events;
using Modeler.Samples.HR.Components.System.Backend;
using Modeler.Samples.HR.Components.System.Backend.Modules.Api.Endpoints;
using Modeler.Samples.HR.Components.System.Database;
using Modeler.Samples.HR.Components.System.Frontend;
using Modeler.Samples.HR.Sequences.Participants;

namespace Modeler.Samples.HR.Sequences.Flows;

public class HRSystemFlowSequence : Sequence
{
    public static HRSystemFlowSequence Create(ElementsRegistry elementsRegistry)
    {
        var user = elementsRegistry.GetElement<UserParticipant>();
        var frontend = elementsRegistry.GetElement<HRFrontendApplication>();
        var backend = elementsRegistry.GetElement<HRBackendApplication>();
        var backendDatabase = elementsRegistry.GetElement<HRDatabaseComponent>();
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