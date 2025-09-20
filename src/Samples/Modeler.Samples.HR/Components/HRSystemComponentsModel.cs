using Modeler.Models.Common.Elements;
using Modeler.Models.Components;

namespace Modeler.Samples.HR.Components;

public class HRSystemComponentsModel : Model
{
    public HRSystemComponentsModel(ModelElementsRegistry elementsRegistry) : base(elementsRegistry)
    {
        HRSystemComponentsRelationshipsModel.Create(this);
    }
}