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
        var order = new Dictionary<Type, int>
        {
            {typeof(UserParticipant), 1},
            {typeof(FrontendParticipant), 2},
            {typeof(BackendParticipant), 3},
            {typeof(BackendDatabaseParticipant), 4}
        };
        var view = new SequenceDiagramView(
            Id,
            model.GetSequence<BasicSequence>(),
            order,
            autonumberMessages: true);

        return view;
    }
}