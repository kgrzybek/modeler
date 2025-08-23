using Modeler.Full.Sample.Components;
using Modeler.Full.Sample.Conceptual.Concepts;
using Modeler.Full.Sample.Data.Structure;
using Modeler.Full.Sample.EventsFlow;
using Modeler.Full.Sample.Messaging;
using Modeler.Full.Sample.Sequences;
using Modeler.Full.Sample.State.Models;
using Models.Elements;

namespace Modeler.Full.Sample;

public class ModelsRegistry : ModelsRegistryBase
{
    public void RegisterModels(ElementsRegistry elementsRegistry)
    {
        AddElement(new HRSequencesModel(elementsRegistry));
        AddElement(new SystemComponentsModel(elementsRegistry));
        AddElement(new OrganizationStructureConceptualModel(elementsRegistry));
        AddElement(new HRDataModel(elementsRegistry));
        AddElement(new HRStateModel(elementsRegistry));
        AddElement(new HREventsFlowModel(elementsRegistry));
        AddElement(new HRBrokerModel(elementsRegistry));
    }
}