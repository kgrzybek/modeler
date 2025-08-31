using Modeler.Samples.HR.Components.ExternalSystems;
using Modeler.Samples.HR.Components.System;
using Modeler.Samples.HR.Components.System.Backend;
using Modeler.Samples.HR.Components.System.Backend.Modules;
using Modeler.Samples.HR.Components.System.Database;
using Modeler.Samples.HR.Components.System.Frontend;

namespace Modeler.Samples.HR.Components;

public static class HRSystemRelationshipsModel
{
    public static void Create(SystemComponentsModel model)
    {
        var backendApplication = model.GetComponent<HRBackendApplication>();
        var api = model.GetComponent<HRBackendApiModule>();
        var frontendApplication = model.GetComponent<HRFrontendApplication>();
        var database = model.GetComponent<HRDatabase>();
        var domain = model.GetComponent<HRBackendDomainModule>();
        var infrastructure = model.GetComponent<HRBackendInfrastructureModule>();
        var application = model.GetComponent<HRBackendApplicationModule>();
        var crm = model.GetComponent<CRM>();
        var systemBoundary = model.GetComponent<HRSystemBoundary>();

        model.AddContainsRelationship(systemBoundary, frontendApplication);
        model.AddContainsRelationship(systemBoundary, backendApplication);
        
        model.AddUsageRelationship(frontendApplication, api);
        model.AddDependencyRelationship(api, application);
        model.AddDependencyRelationship(api, infrastructure);
        model.AddDependencyRelationship(application, domain);
        model.AddDependencyRelationship(infrastructure, domain);
        model.AddDependencyRelationship(infrastructure, application);
        model.AddUsageRelationship(infrastructure, database);
        model.AddUsageRelationship(infrastructure, crm);
        
        model.AddContainsRelationship(backendApplication, api);
        model.AddContainsRelationship(backendApplication, application);
        model.AddContainsRelationship(backendApplication, infrastructure);
        model.AddContainsRelationship(backendApplication, domain);
    }
}