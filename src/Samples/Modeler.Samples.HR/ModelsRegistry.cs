using Modeler.Models.Common;
using Modeler.Models.Common.Models;
using Modeler.Samples.HR.Apis;
using Modeler.Samples.HR.Messaging;
using Modeler.Samples.HR.Components;
using Modeler.Samples.HR.Conceptual.Concepts;
using Modeler.Samples.HR.EventsFlow;
using Modeler.Samples.HR.Sequences;
using Modeler.Samples.HR.State.Models;

namespace Modeler.Samples.HR;

public class ModelsRegistry : ModelsRegistryBase
{
    public void RegisterModels(ElementsRegistry elementsRegistry)
    {
        AddElement(new HRSequencesModel(elementsRegistry));
        AddElement(new SystemComponentsModel(elementsRegistry));
        AddElement(new OrganizationStructureConceptualModel(elementsRegistry));
        AddElement(new HRStateStateMachineModel(elementsRegistry));
        AddElement(new HREventsFlowModel(elementsRegistry));
    }
}