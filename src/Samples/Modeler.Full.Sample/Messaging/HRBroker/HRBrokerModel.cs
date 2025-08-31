using Modeler.Full.Sample.Components.ExternalSystems;
using Modeler.Full.Sample.Components.System.Backend;
using Modeler.Full.Sample.Messaging.HRBroker.Events;
using Modeler.Full.Sample.Messaging.HRBroker.Queues;
using Modeler.Messaging;
using Models.Elements;

namespace Modeler.Full.Sample.Messaging.HRBroker;

public class HRBrokerModel : BrokerModel
{
    public HRBrokerModel(ModelElementsRegistry elementsRegistry) : base(elementsRegistry)
    {
        var sampleQueue = elementsRegistry.GetElement<SampleQueue>();
        var personAddedEventMessage = elementsRegistry.GetElement<EmployeeAddedEventMessage>();
        var backendApplication = elementsRegistry.GetElement<HRBackendApplication>();
        var crm = elementsRegistry.GetElement<CRM>();
        
        AddQueue(sampleQueue);
        PublishMessage(backendApplication, sampleQueue, personAddedEventMessage);
        SubscribeToMessage(crm, sampleQueue, personAddedEventMessage);
    }
}