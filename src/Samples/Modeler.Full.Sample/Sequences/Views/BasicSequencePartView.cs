using Modeler.Full.Sample.Components.System.Backend;
using Modeler.Full.Sample.Components.System.Database;
using Modeler.Full.Sample.Components.System.Frontend;
using Modeler.Full.Sample.Sequences.Flows;
using Modeler.Full.Sample.Sequences.Participants;
using Modeler.SequenceModel;
using Modeler.SequenceModel.Participants;
using Modeler.SequenceModel.Views.Shared;
using Models.Elements;

namespace Modeler.Full.Sample.Sequences.Views;

public class BasicSequencePartView : IView
{
    public const string Id = "BasicSequencePart";
    
    public static SequenceDiagramView Create(HRSequencesModel model)
    {
        var participantsToShow = new List<ISequenceParticipant>
        {
            model.GetParticipant<UserParticipant>(),
            model.GetParticipant<HRFrontendApplication>(),
            model.GetParticipant<HRBackendApplication>(),
            model.GetParticipant<HRDatabase>()
        };
        var view = new SequenceDiagramView(
            Id,
            model.GetSequence<HRSystemFlowSequence>(),
            participantsToShow,
            autonumberMessages: true);

        return view;
    }
}