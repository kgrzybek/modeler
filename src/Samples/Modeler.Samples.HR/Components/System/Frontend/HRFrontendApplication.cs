using Modeler.Models.Common;
using Modeler.Models.Common.Elements;
using Modeler.Models.Components;
using Modeler.Models.RestApi;
using Modeler.Models.Sequence.Participants;
using Modeler.Samples.HR.Apis;
using Modeler.Samples.HR.Components.Types;
using Modeler.Samples.HR.Sequences.ParticipantTypes;

namespace Modeler.Samples.HR.Components.System.Frontend;

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