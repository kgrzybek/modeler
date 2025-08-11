using Modeler.EventsFlowModel;
using Models.Elements;

namespace Modeler.Full.Sample.EventsFlow;

public class HREventsFlowModel : Model
{
    public HREventsFlowModel(ModelElementsRegistry elementsRegistry) : base(elementsRegistry)
    {
        HRFlowModel.Create(this);
    }
}