using Modeler.Samples.HR.Components.ExternalSystems;
using Modeler.Samples.HR.Components.HRBroker;
using Modeler.Samples.HR.Components.Relationships;
using Modeler.Samples.HR.Components.System;
using Modeler.Samples.HR.Components.System.Backend;
using Modeler.Samples.HR.Components.System.Backend.Modules;
using Modeler.Samples.HR.Components.System.Backend.Modules.Api;
using Modeler.Samples.HR.Components.System.Database;
using Modeler.Samples.HR.Components.System.Frontend;

namespace Modeler.Samples.HR.Components;

public static class HRSystemComponentsRelationshipsModel
{
    public static void Create(HRSystemComponentsModel model)
    {
        var backendApplication = model.GetComponent<HRBackendApplication>();
        var api = model.GetComponent<HRBackendApiModule>();
        var frontendApplication = model.GetComponent<HRFrontendApplication>();
        var database = model.GetComponent<HRDatabaseComponent>();
        var domain = model.GetComponent<HRBackendDomainModule>();
        var infrastructure = model.GetComponent<HRBackendInfrastructureModule>();
        var application = model.GetComponent<HRBackendApplicationModule>();
        var crm = model.GetComponent<CRM>();
        var systemBoundary = model.GetComponent<HRSystem>();
        var messagesBroker = model.GetComponent<HRBrokerComponent>();
        var restApi = model.GetComponent<HRRestApiComponent>();

        model.AddContainsRelationship(systemBoundary, frontendApplication);
        model.AddContainsRelationship(systemBoundary, backendApplication);
        model.AddContainsRelationship(systemBoundary, database);
        
        model.AddUsageRelationship(frontendApplication, api);
        model.AddUsageRelationship(frontendApplication, restApi);
        model.AddUsageRelationship(systemBoundary, crm);
        model.AddUsageRelationship(backendApplication, crm);
        model.AddUsageRelationship(backendApplication, database);
        model.AddUsageRelationship(frontendApplication, backendApplication);
        model.AddDependencyRelationship(api, application);
        model.AddDependencyRelationship(api, infrastructure);
        model.AddDependencyRelationship(application, domain);
        model.AddDependencyRelationship(infrastructure, domain);
        model.AddDependencyRelationship(infrastructure, application);
        model.AddRelationship(new SqlRelationshipComponentRelationship(infrastructure, database, true, true));
        model.AddUsageRelationship(infrastructure, crm);
        
        model.AddContainsRelationship(backendApplication, api);
        model.AddContainsRelationship(api, restApi);
        model.AddContainsRelationship(backendApplication, application);
        model.AddContainsRelationship(backendApplication, infrastructure);
        model.AddContainsRelationship(backendApplication, domain);
        
        model.AddPublishSubscribeRelationship(infrastructure, messagesBroker);
        model.AddPublishSubscribeRelationship(backendApplication, messagesBroker);
        model.AddPublishSubscribeRelationship(crm, messagesBroker);
    }
}