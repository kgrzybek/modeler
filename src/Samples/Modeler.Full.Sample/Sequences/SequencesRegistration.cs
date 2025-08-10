using Modeler.Full.Sample.Sequences.Flows;
using Modeler.Full.Sample.Sequences.Participants;

namespace Modeler.Full.Sample.Sequences;

internal static class SequencesRegistration
{
    internal static void RegisterSequences(this ElementsRegistry elementsRegistry)
    {
        elementsRegistry.AddElement(UserParticipant.Create());
        elementsRegistry.AddElement(HRSystemFlowSequence.Create(elementsRegistry));
    }
}