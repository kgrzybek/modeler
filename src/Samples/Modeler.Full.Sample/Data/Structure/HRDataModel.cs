using Models.Elements;

namespace Modeler.Full.Sample.Data.Structure;

public class HRDataModel : DataModel.DataModel
{
    public HRDataModel(ModelElementsRegistry elementsRegistry) : base(elementsRegistry)
    {
        OrganizationsDataModel.Create(this);
    }
}