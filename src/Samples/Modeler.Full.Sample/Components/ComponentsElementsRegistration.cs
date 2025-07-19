using Modeler.Full.Sample.Components.ExternalSystems;
using Modeler.Full.Sample.Components.System;
using Modeler.Full.Sample.Components.System.Backend;
using Modeler.Full.Sample.Components.System.Backend.Modules;
using Modeler.Full.Sample.Components.System.Database;
using Modeler.Full.Sample.Components.System.Frontend;

namespace Modeler.Full.Sample.Components;

internal static class ComponentsElementsRegistration
{
    internal static void RegisterComponents(this ElementsRegistry elementsRegistry)
    {
        elementsRegistry.AddElement(CRM.Create());
        elementsRegistry.AddElement(HRBackendApplication.Create());
        elementsRegistry.AddElement(HRBackendApiModule.Create());
        elementsRegistry.AddElement(HRBackendApplicationModule.Create());
        elementsRegistry.AddElement(HRBackendDomainModule.Create());
        elementsRegistry.AddElement(HRBackendInfrastructureModule.Create());
        elementsRegistry.AddElement(HRDatabase.Create());
        elementsRegistry.AddElement(HRFrontendApplication.Create());
        elementsRegistry.AddElement(HRSystemBoundary.Create());
    }
}