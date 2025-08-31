using Modeler.Samples.HR.Sequences.Flows;
using Modeler.Samples.HR.Sequences.Participants;

namespace Modeler.Samples.HR.Sequences;

internal static class SequencesRegistration
{
    internal static void RegisterSequences(this ElementsRegistry elementsRegistry)
    {
        elementsRegistry.AddElement(UserParticipant.Create());
        elementsRegistry.AddElement(HRSystemFlowSequence.Create(elementsRegistry));
    }
}