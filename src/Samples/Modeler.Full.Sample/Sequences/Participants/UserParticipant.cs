using Modeler.Full.Sample.Sequences.ParticipantTypes;
using Modeler.SequenceModel;
using Models.Elements;

namespace Modeler.Full.Sample.Sequences.Participants;

public class UserParticipant : Participant
{
    public static IElement Create()
    {
        return new UserParticipant()
            .WithName("User")
            .OfType(new Actor());
    }
}