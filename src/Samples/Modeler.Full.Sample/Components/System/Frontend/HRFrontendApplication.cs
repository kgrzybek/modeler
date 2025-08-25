using Modeler.ComponentsModel;
using Modeler.Full.Sample.Apis;
using Modeler.Full.Sample.Components.Types;
using Modeler.Full.Sample.Sequences.ParticipantTypes;
using Modeler.RestApiModel;
using Modeler.SequenceModel;
using Modeler.SequenceModel.Participants;
using Models.Elements;

namespace Modeler.Full.Sample.Components.System.Frontend;

public class HRFrontendApplication : IComponent, ISequenceParticipant, IApiConsumer
{
    public static HRFrontendApplication Create(ElementsRegistry elementsRegistry)
    {
        return new HRFrontendApplication(elementsRegistry);
    }

    private HRFrontendApplication(ElementsRegistry elementsRegistry)
    {
        Name = "HRFrontendApplication";
        Id = ElementIdGenerator.GenerateElementId(GetType(), Name);
        Type = new ApplicationComponentType();
        ParticipantType = new Application();
        ConsumingApi = elementsRegistry.GetElement<HRRestApiModel>();
    }
    public string Name { get; }
    
    public string Id { get; }
    
    public ComponentType Type { get; }
    public ParticipantType ParticipantType { get; }
    
    public IApiModel ConsumingApi { get; }
}