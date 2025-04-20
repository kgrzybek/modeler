using Modeler.SequenceModel.Tests.Sample.Participants;
using Modeler.SequenceModel.Tests.Sample.Sequences;
using Modeler.SequenceModel.Views.PlantUml;
using Type = System.Type;

namespace Modeler.SequenceModel.Tests.Sample.Views;

public class BasicSequenceView : SequenceDiagramViewDefinition
{
    public const string Id = "BasicSequence";
    
    public static SequenceDiagramView Create(SequencesModel model)
    {
        var participantsToShow = new List<Participant>
        {
            model.GetParticipant<UserParticipant>(),
            model.GetParticipant<FrontendParticipant>(),
            model.GetParticipant<BackendParticipant>(),
            model.GetParticipant<BackendDatabaseParticipant>(),
            model.GetParticipant<CrmParticipant>()
        };
        var view = new SequenceDiagramView(
            Id,
            model.GetSequence<BasicSequence>(),
            participantsToShow,
            autonumberMessages: true);

        return view;
    }
}