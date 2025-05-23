﻿using Modeler.SequenceModel.Sample.Models.Parameters;
using Modeler.SequenceModel.Sample.Models.Participants;

namespace Modeler.SequenceModel.Sample.Models.Sequences;

public class HRSystemFlowSequence : Sequence
{
    public static void Create(HRSequencesModel model)
    {
        var user = model.GetParticipant<UserParticipant>();
        var frontend = model.GetParticipant<FrontendParticipant>();
        var backend = model.GetParticipant<HRBackendParticipant>();
        var backendDatabase = model.GetParticipant<HRDatabaseParticipant>();
        var crm = model.GetParticipant<CrmParticipant>();

        var builder = new SequenceBuilder<HRSystemFlowSequence>("HR System Flow Sequence");

        builder.AddSynchronousRequestMessage(user, "addEmployee", new StringMessageParameter("Employee"), frontend);
        builder.AddSynchronousRequestMessage(frontend, "addEmployee", new StringMessageParameter("EmployeeDto"), backend);
        
        builder.AddSelfMessage(backend, "Validate", new StringMessageParameter("EmployeeDto"));
        
        builder.AddSynchronousRequestMessage(backend, "addEmployee", new StringMessageParameter("SQL"), backendDatabase);
        builder.AddSynchronousResponseMessage(backendDatabase, "OK", new NoMessageParameters(), backend);
        builder.AddEventMessage(backend, "EmployeeAdded", new StringMessageParameter("EmployeeAddedEvent"), crm);
        builder.AddSynchronousResponseMessage(backend, "OK", new NoMessageParameters(), frontend);
        
        builder.AddSynchronousResponseMessage(frontend, "OK", new NoMessageParameters(), user);

        var sequence = builder.Build();
        model.AddSequence(sequence);
    }
}