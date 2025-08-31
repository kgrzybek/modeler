using Modeler.Samples.HR.Conceptual.Concepts.Entities;

namespace Modeler.Samples.HR.Conceptual.Concepts;

internal static class ConceptsRegistration
{
    internal static void RegisterConcepts(this ElementsRegistry elementsRegistry)
    {
        elementsRegistry.AddElement(Employee.Create());
        elementsRegistry.AddElement(Manager.Create());
        elementsRegistry.AddElement(OrganizationUnit.Create());
    }
}