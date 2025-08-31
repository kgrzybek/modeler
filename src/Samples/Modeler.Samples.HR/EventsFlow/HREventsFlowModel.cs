using Modeler.Models.Common;
using Modeler.Models.Common.Elements;
using Modeler.Models.EventsFlow;

namespace Modeler.Samples.HR.EventsFlow;

public class HREventsFlowModel : Model
{
    public HREventsFlowModel(ModelElementsRegistry elementsRegistry) : base(elementsRegistry)
    {
        HRFlowModel.Create(this);
    }
}