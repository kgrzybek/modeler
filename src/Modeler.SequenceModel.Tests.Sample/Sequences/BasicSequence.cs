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

        var builder = new SequenceBuilder<BasicSequence>("Basic");

        builder.AddSynchronousRequestMessage(user, "doSomething", new StringMessageParameter("123"), system);
        builder.AddSynchronousRequestMessage(system, "doSomethingMore", new StringMessageParameter("123"), systemTwo);
        
        builder.AddSynchronousResponseMessage(systemTwo, "OK", new NoMessageParameters(), system);
        builder.AddSynchronousResponseMessage(system, "OK", new NoMessageParameters(), user);

        var sequence = builder.Build();
        model.AddSequence(sequence);
    }
}