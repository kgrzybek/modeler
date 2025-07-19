namespace Modeler.Full.Sample.Sequences;

internal static class SequenceParticipantsRegistration
{
    internal static void RegisterSequenceParticipants(this ElementsRegistry elementsRegistry)
    {
        elementsRegistry.AddElement(UserParticipant.Create());
    }
}