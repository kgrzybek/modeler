
using Modeler.ComponentsModel;
using Modeler.Full.Sample.Components.Types;
using Modeler.Full.Sample.ParticipantTypes;
using Modeler.SequenceModel;
using Models.Elements;

namespace Modeler.Full.Sample.Components;

public class BackendApplication : IComponent, ISequenceParticipant
{
    public BackendApplication()
    {
        this.Name = "Backend";
        this.Id = ElementIdGenerator.GenerateElementId(this.GetType(), Name);
        Type = new ApplicationComponentType();
        ParticipantType = new Application();
    }
    public string Name { get; }
    public string Id { get; }
    public ComponentType Type { get; }
    public ParticipantType ParticipantType { get; set; }
}