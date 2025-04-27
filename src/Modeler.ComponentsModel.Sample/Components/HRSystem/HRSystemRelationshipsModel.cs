using Modeler.ComponentsModel.Sample.Components.ExternalSystems;
using Modeler.ComponentsModel.Sample.Components.HRSystem.Backend.Modules;
using Modeler.ComponentsModel.Sample.Components.HRSystem.Database;
using Modeler.ComponentsModel.Sample.Components.HRSystem.Frontend;

namespace Modeler.ComponentsModel.Sample.Components.HRSystem;

public class HRSystemRelationshipsModel : RelationshipsModel
{
    public static void Create(SystemComponentsModel model)
    {
        var api = model.GetComponent<HRBackendApiModule>();
        var frontend = model.GetComponent<HRFrontendApplication>();
        var database = model.GetComponent<HRDatabase>();
        var domain = model.GetComponent<HRBackendDomainModule>();
        var infrastructure = model.GetComponent<HRBackendInfrastructureModule>();
        var application = model.GetComponent<HRBackendApplicationModule>();
        var crm = model.GetComponent<CRMExternalSystem>();

        model.AddUsageRelationship(frontend, api);
        model.AddDependencyRelationship(api, application);
        model.AddDependencyRelationship(api, infrastructure);
        model.AddDependencyRelationship(application, domain);
        model.AddDependencyRelationship(infrastructure, domain);
        model.AddDependencyRelationship(infrastructure, application);
        model.AddUsageRelationship(infrastructure, database);
        model.AddUsageRelationship(infrastructure, crm);
    }
}