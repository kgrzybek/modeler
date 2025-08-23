using Modeler.Full.Sample.Components.ExternalSystems;
using Modeler.Full.Sample.Components.System.Backend;
using Modeler.Messaging;
using Models.Elements;

namespace Modeler.Full.Sample.Messaging;

public class HRBrokerModel : BrokerModel
{
    public HRBrokerModel(ModelElementsRegistry elementsRegistry) : base(elementsRegistry)
    {
        var sampleQueue = elementsRegistry.GetElement<SampleQueue>();
        var personAddedEventMessage = elementsRegistry.GetElement<PersonAddedEventMessage>();
        var backendApplication = elementsRegistry.GetElement<HRBackendApplication>();
        var crm = elementsRegistry.GetElement<CRM>();
        
        AddQueue(sampleQueue);
        PublishMessage(backendApplication, sampleQueue, personAddedEventMessage);
        SubscribeToMessage(crm, sampleQueue, personAddedEventMessage);
    }
}