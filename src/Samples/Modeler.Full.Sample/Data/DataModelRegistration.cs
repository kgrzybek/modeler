using Modeler.Full.Sample.Data.Structure.Schemas;
using Modeler.Full.Sample.Data.Structure.Tables;

namespace Modeler.Full.Sample.Data;

internal static class DataModelRegistration
{
    internal static void RegisterDataModelElements(this ElementsRegistry elementsRegistry)
    {
        elementsRegistry.AddElement(new OrganizationSchema());
        elementsRegistry.AddElement(EmployeesTable.Create(elementsRegistry));
        elementsRegistry.AddElement(OrganizationUnitTable.Create(elementsRegistry));
    }
}