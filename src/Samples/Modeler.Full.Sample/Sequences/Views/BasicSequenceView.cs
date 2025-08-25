using Modeler.Full.Sample.Components.ExternalSystems;
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

public class BasicSequenceView
{
    public const string Id = "BasicSequence";
    
    public static SequenceDiagramView Create(HRSequencesModel model)
    {
        var participantsToShow = new List<ISequenceParticipant>
        {
            model.GetParticipant<UserParticipant>(),
            model.GetParticipant<HRFrontendApplication>(),
            model.GetParticipant<HRBackendApplication>(),
            model.GetParticipant<HRDatabase>(),
            model.GetParticipant<CRM>()
        };
        var view = new SequenceDiagramView(
            Id,
            model.GetSequence<HRSystemFlowSequence>(),
            participantsToShow,
            autonumberMessages: true);

        return view;
    }
}