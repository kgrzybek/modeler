using Modeler.Models.Common.Elements;
using Modeler.Samples.HR.Components.System.Backend;
using Modeler.Samples.HR.Components.System.Database;
using Modeler.Samples.HR.Components.System.Frontend;
using Modeler.Samples.HR.Sequences.Flows;
using Modeler.Samples.HR.Sequences.Participants;
using Modeler.Views.Sequence.Diagram.Shared;

namespace Modeler.Samples.HR.Sequences.Views.SequenceDiagrams;

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
            model.GetParticipant<HRDatabaseComponent>()
        ];
    }
}