using Modeler.Models.Common;
using Modeler.Models.Common.Elements;
using Modeler.Models.Components;
using Modeler.Models.Messaging;
using Modeler.Models.Sequence.Participants;
using Modeler.Samples.HR.Components.Types;
using Modeler.Samples.HR.Sequences.ParticipantTypes;

namespace Modeler.Samples.HR.Components.System.Backend;

public class HRBackendApplication : IComponent, ISequenceParticipant, IMessagesPublisher
{
    public static HRBackendApplication Create()
    {
        return new HRBackendApplication();
    }
    private HRBackendApplication()
    {
        Name = "Backend";
        Id = ElementIdGenerator.GenerateElementId(GetType(), Name);
        Type = new ApplicationComponentType();
        ParticipantType = new Application();
    }
    public string Name { get; }
    public string Id { get; }
    public ComponentType Type { get; }
    public ParticipantType ParticipantType { get; set; }
}