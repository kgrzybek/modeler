using Modeler.Models.Common;
using Modeler.Models.Common.Elements;
using Modeler.Models.Messaging;
using Modeler.Samples.HR.Components.ExternalSystems;
using Modeler.Samples.HR.Components.System.Backend;
using Modeler.Samples.HR.Messaging.HRBroker.Events;
using Modeler.Samples.HR.Messaging.HRBroker.Queues;

namespace Modeler.Samples.HR.Messaging.HRBroker;

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