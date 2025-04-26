namespace Modeler.ComponentsModel.Sample.Components;

public class ComponentsRelationshipsModel : RelationshipsModel
{
    public static void Create(SystemComponentsModel model)
    {
        var api = model.GetComponent<ApiComponent>();
        var frontend = model.GetComponent<FrontendComponent>();
        var database = model.GetComponent<DatabaseComponent>();
        var domain = model.GetComponent<DomainComponent>();
        var infrastructure = model.GetComponent<InfrastructureComponent>();
        var application = model.GetComponent<ApplicationComponent>();

        model.AddUsageRelationship(frontend, api);
        model.AddDependencyRelationship(api, application);
        model.AddDependencyRelationship(api, infrastructure);
        model.AddDependencyRelationship(application, domain);
        model.AddDependencyRelationship(infrastructure, domain);
        model.AddDependencyRelationship(infrastructure, application);
        model.AddUsageRelationship(infrastructure, database);
    }
}