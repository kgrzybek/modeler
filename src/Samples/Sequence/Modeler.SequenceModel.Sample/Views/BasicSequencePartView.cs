using Modeler.SequenceModel.Sample.Models;
using Modeler.SequenceModel.Sample.Models.Participants;
using Modeler.SequenceModel.Sample.Models.Sequences;
using Modeler.SequenceModel.Views.Shared;

namespace Modeler.SequenceModel.Sample.Views;

public class BasicSequencePartView : SequenceDiagramViewDefinition
{
    public const string Id = "BasicSequencePart";
    
    public static SequenceDiagramView Create(HRSequencesModel model)
    {
        var participantsToShow = new List<Participant>
        {
            model.GetParticipant<UserParticipant>(),
            model.GetParticipant<FrontendParticipant>(),
            model.GetParticipant<HRBackendParticipant>(),
            model.GetParticipant<HRDatabaseParticipant>()
        };
        var view = new SequenceDiagramView(
            Id,
            model.GetSequence<HRSystemFlowSequence>(),
            participantsToShow,
            autonumberMessages: true);

        return view;
    }
}