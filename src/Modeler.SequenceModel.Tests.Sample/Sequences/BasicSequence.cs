using Modeler.SequenceModel.Tests.Sample.Parameters;
using Modeler.SequenceModel.Tests.Sample.Participants;

namespace Modeler.SequenceModel.Tests.Sample.Sequences;

public class BasicSequence : Sequence
{
    public static void Create(SequencesModel model)
    {
        var user = model.GetParticipant<UserParticipant>();
        var system = model.GetParticipant<SystemOneParticipant>();
        var systemTwo = model.GetParticipant<SystemTwoParticipant>();
        var databaseParticipant = model.GetParticipant<DatabaseParticipant>();

        var builder = new SequenceBuilder<BasicSequence>("Basic");

        builder.AddSynchronousRequestMessage(user, "doSomething", new StringMessageParameter("123"), system);
        builder.AddSynchronousRequestMessage(system, "getData", new StringMessageParameter("123"), systemTwo);
        
        builder.AddSynchronousRequestMessage(systemTwo, "getData", new StringMessageParameter("SQL"), databaseParticipant);
        builder.AddSynchronousResponseMessage(databaseParticipant, "OK", new StringMessageParameter("data"), systemTwo);
        
        builder.AddSynchronousResponseMessage(systemTwo, "OK", new StringMessageParameter("data"), system);
        
        builder.AddSelfMessage(system, "Process", new StringMessageParameter("data"));
        builder.AddSynchronousResponseMessage(system, "OK", new NoMessageParameters(), user);

        var sequence = builder.Build();
        model.AddSequence(sequence);
    }
}