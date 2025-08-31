using Modeler.Models.Common;
using Modeler.Models.Common.Elements;
using Modeler.Models.Data;

namespace Modeler.Samples.HR.Data.Structure;

public class HRDataModel : DataModel
{
    public HRDataModel(ModelElementsRegistry elementsRegistry) : base(elementsRegistry)
    {
        OrganizationsDataModel.Create(this);
    }
}