using Modeler.ComponentsModel;
using Modeler.Full.Sample.Components.Types;
using Modeler.Full.Sample.Sequences.ParticipantTypes;
using Modeler.SequenceModel;
using Models.Elements;

namespace Modeler.Full.Sample.Components.System.Backend;

public class HRBackendApplication : IComponent, ISequenceParticipant
{
    public static IElement Create()
    {
        return new HRBackendApplication();
    }
    public HRBackendApplication()
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