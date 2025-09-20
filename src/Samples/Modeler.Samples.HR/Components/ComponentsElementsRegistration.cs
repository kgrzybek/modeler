using Modeler.Samples.HR.Components.ExternalSystems;
using Modeler.Samples.HR.Components.HRBroker;
using Modeler.Samples.HR.Components.System;
using Modeler.Samples.HR.Components.System.Backend;
using Modeler.Samples.HR.Components.System.Backend.Modules;
using Modeler.Samples.HR.Components.System.Database;
using Modeler.Samples.HR.Components.System.Frontend;

namespace Modeler.Samples.HR.Components;

internal static class ComponentsElementsRegistration
{
    internal static void RegisterComponents(this ElementsRegistry elementsRegistry)
    {
        elementsRegistry.AddElement(CRM.Create());
        elementsRegistry.AddElement(HRBackendApplication.Create());
        elementsRegistry.AddElement(HRBackendApiModule.Create(elementsRegistry));
        elementsRegistry.AddElement(HRBackendApplicationModule.Create());
        elementsRegistry.AddElement(HRBackendDomainModule.Create());
        elementsRegistry.AddElement(HRBackendInfrastructureModule.Create());
        elementsRegistry.AddElement(new HRDatabaseComponent(elementsRegistry));
        elementsRegistry.AddElement(HRFrontendApplication.Create(elementsRegistry));
        elementsRegistry.AddElement(new HRSystem());
        elementsRegistry.AddElement(new HRBrokerComponent(elementsRegistry));
    }
}