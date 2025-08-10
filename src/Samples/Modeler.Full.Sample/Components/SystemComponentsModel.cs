using Modeler.ComponentsModel;
using Models.Elements;

namespace Modeler.Full.Sample.Components;

public class SystemComponentsModel : Model
{
    public SystemComponentsModel(ModelElementsRegistry elementsRegistry) : base(elementsRegistry)
    {
        HRSystemRelationshipsModel.Create(this);
    }
}