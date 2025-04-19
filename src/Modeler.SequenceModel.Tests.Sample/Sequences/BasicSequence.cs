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

        builder.AddMessage(user, "hello system one", new StringMessageParameter("hi"), system);
        builder.AddMessage(system, "welcome from system one", new NoMessageParameters(), user);
        
        builder.AddMessage(user, "hello two", new StringMessageParameter("input"), systemTwo);
        builder.AddMessage(systemTwo, "welcome from system two", new NoMessageParameters(), user);

        var sequence = builder.Build();
        model.AddSequence(sequence);
    }
}