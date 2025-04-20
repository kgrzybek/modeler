using Modeler.SequenceModel.Tests.Sample.Parameters;
using Modeler.SequenceModel.Tests.Sample.Participants;

namespace Modeler.SequenceModel.Tests.Sample.Sequences;

public class BasicSequence : Sequence
{
    public static void Create(SequencesModel model)
    {
        var user = model.GetParticipant<UserParticipant>();
        var frontend = model.GetParticipant<FrontendParticipant>();
        var backend = model.GetParticipant<BackendParticipant>();
        var backendDatabase = model.GetParticipant<BackendDatabaseParticipant>();

        var builder = new SequenceBuilder<BasicSequence>("Basic");

        builder.AddSynchronousRequestMessage(user, "doSomething", new StringMessageParameter("123"), frontend);
        builder.AddSynchronousRequestMessage(frontend, "getData", new StringMessageParameter("123"), backend);
        
        builder.AddSynchronousRequestMessage(backend, "getData", new StringMessageParameter("SQL"), backendDatabase);
        builder.AddSynchronousResponseMessage(backendDatabase, "OK", new StringMessageParameter("data"), backend);
        
        builder.AddSynchronousResponseMessage(backend, "OK", new StringMessageParameter("data"), frontend);
        
        builder.AddSelfMessage(frontend, "Process", new StringMessageParameter("data"));
        builder.AddSynchronousResponseMessage(frontend, "OK", new NoMessageParameters(), user);

        var sequence = builder.Build();
        model.AddSequence(sequence);
    }
}