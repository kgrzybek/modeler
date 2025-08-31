using Modeler.Models.Common;
using Modeler.Models.Common.Elements;
using Modeler.Models.Sequence.Participants;
using Modeler.Samples.HR.Sequences.ParticipantTypes;

namespace Modeler.Samples.HR.Sequences.Participants;

public class UserParticipant : Participant
{
    public static IElement Create()
    {
        return new UserParticipant()
            .WithName("User")
            .OfType(new Actor());
    }
}