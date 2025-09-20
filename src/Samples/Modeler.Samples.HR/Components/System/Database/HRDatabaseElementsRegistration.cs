using Modeler.Samples.HR.Components.System.Database.Structure.Schemas;
using Modeler.Samples.HR.Components.System.Database.Structure.Tables;

namespace Modeler.Samples.HR.Components.System.Database;

internal static class HRDatabaseElementsRegistration
{
    internal static void RegisterHRDatabaseElements(this ElementsRegistry elementsRegistry)
    {
        elementsRegistry.AddElement(new OrganizationSchema());
        elementsRegistry.AddElement(EmployeesTable.Create(elementsRegistry));
        elementsRegistry.AddElement(OrganizationUnitTable.Create(elementsRegistry));
    }
}