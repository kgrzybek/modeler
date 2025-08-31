using Modeler.Samples.HR.Data.Structure.Schemas;
using Modeler.Samples.HR.Data.Structure.Tables;

namespace Modeler.Samples.HR.Data;

internal static class DataModelRegistration
{
    internal static void RegisterDataModelElements(this ElementsRegistry elementsRegistry)
    {
        elementsRegistry.AddElement(new OrganizationSchema());
        elementsRegistry.AddElement(EmployeesTable.Create(elementsRegistry));
        elementsRegistry.AddElement(OrganizationUnitTable.Create(elementsRegistry));
    }
}