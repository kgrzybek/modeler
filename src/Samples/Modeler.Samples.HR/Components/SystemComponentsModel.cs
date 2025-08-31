using Modeler.Models.Common;
using Modeler.Models.Common.Elements;
using Modeler.Models.Components;

namespace Modeler.Samples.HR.Components;

public class SystemComponentsModel : Model
{
    public SystemComponentsModel(ModelElementsRegistry elementsRegistry) : base(elementsRegistry)
    {
        HRSystemRelationshipsModel.Create(this);
    }
}