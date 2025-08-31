using Modeler.Full.Sample.Components.ExternalSystems;
using Modeler.Full.Sample.Components.System.Backend;
using Modeler.Full.Sample.Components.System.Database;
using Modeler.Full.Sample.Components.System.Frontend;
using Modeler.Full.Sample.Sequences.Flows;
using Modeler.Full.Sample.Sequences.Participants;
using Modeler.SequenceModel;
using Modeler.SequenceModel.Participants;
using Modeler.SequenceModel.Sequences;
using Modeler.SequenceModel.Views.Shared;
using Models.Elements;

namespace Modeler.Full.Sample.Sequences.Views;

public class BasicSequenceView :  SequenceDiagramView
{
    public const string Id = "BasicSequence";

    public BasicSequenceView(
        ModelElementsRegistry elementsRegistry,
        HRSequencesModel model)
        : base(elementsRegistry.GetElement<HRSystemFlowSequence>(), true)
    {
        ParticipantsToShow =
        [
            model.GetParticipant<UserParticipant>(),
            model.GetParticipant<HRFrontendApplication>(),
            model.GetParticipant<HRBackendApplication>(),
            model.GetParticipant<HRDatabase>(),
            model.GetParticipant<CRM>()
        ];
    }
}