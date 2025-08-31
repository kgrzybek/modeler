using Modeler.Full.Sample.Components.System.Backend;
using Modeler.Full.Sample.Components.System.Database;
using Modeler.Full.Sample.Components.System.Frontend;
using Modeler.Full.Sample.Sequences.Flows;
using Modeler.Full.Sample.Sequences.Participants;
using Modeler.SequenceModel.Views.Shared;
using Models.Elements;

namespace Modeler.Full.Sample.Sequences.Views;

public class BasicSequencePartView :  SequenceDiagramView
{
    public const string Id = "BasicSequencePart";

    public BasicSequencePartView(
        ModelElementsRegistry elementsRegistry,
        HRSequencesModel model)
        : base(elementsRegistry.GetElement<HRSystemFlowSequence>(), true)
    {        
        ParticipantsToShow =
        [
            model.GetParticipant<UserParticipant>(),
            model.GetParticipant<HRFrontendApplication>(),
            model.GetParticipant<HRBackendApplication>(),
            model.GetParticipant<HRDatabase>()
        ];
    }
}