using Modeler.Full.Sample.Data.Structure.Tables;

namespace Modeler.Full.Sample.Data;

internal static class DataModelRegistration
{
    internal static void RegisterDataModelElements(this ElementsRegistry elementsRegistry)
    {
        elementsRegistry.AddElement(EmployeesTable.Create());
        elementsRegistry.AddElement(OrganizationUnitTable.Create());
    }
}