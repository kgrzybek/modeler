using Modeler.Full.Sample.Conceptual.Concepts.Entities;

namespace Modeler.Full.Sample.Conceptual.Concepts;

internal static class ConceptsRegistration
{
    internal static void RegisterConcepts(this ElementsRegistry elementsRegistry)
    {
        elementsRegistry.AddElement(Employee.Create());
        elementsRegistry.AddElement(Manager.Create());
        elementsRegistry.AddElement(OrganizationUnit.Create());
    }
}