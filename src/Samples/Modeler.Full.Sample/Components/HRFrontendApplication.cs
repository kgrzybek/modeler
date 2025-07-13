using Modeler.ComponentsModel;
using Modeler.Full.Sample.Components.Types;
using Modeler.Full.Sample.ParticipantTypes;
using Modeler.SequenceModel;
using Models.Elements;

namespace Modeler.Full.Sample.Components;

public class HRFrontendApplication : IComponent, ISequenceParticipant
{
    public HRFrontendApplication()
    {
        Name = "HRFrontendApplication";
        Id = ElementIdGenerator.GenerateElementId(GetType(), Name);
        Type = new ApplicationComponentType();
        ParticipantType = new Application();
    }
    public string Name { get; }
    public string Id { get; }
    public ComponentType Type { get; }
    public ParticipantType ParticipantType { get; }
}