using Modeler.Models.Common.Elements;
using Modeler.Models.Deployment;
using Modeler.Samples.HR.Components.HRBroker;
using Modeler.Samples.HR.Components.System.Backend;
using Modeler.Samples.HR.Components.System.Backend.Modules;
using Modeler.Samples.HR.Components.System.Database;
using Modeler.Samples.HR.Components.System.Frontend;
using Modeler.Samples.HR.Deployment.Environments;
using Modeler.Samples.HR.Deployment.RuntimeEnvironments;
using Modeler.Samples.HR.Deployment.Servers;

namespace Modeler.Samples.HR.Deployment;

public class HRDeploymentModel : Model
{
    public HRDeploymentModel(ModelElementsRegistry elementsRegistry) : base(elementsRegistry)
    {
        var production = GetEnvironment<ProductionEnvironment>();

        var frontendServer = GetServer<ProductionFrontendServer>();
        var backendServer = GetServer<ProductionBackendServer>();
        var databaseServer = GetServer<ProductionDatabaseServer>();
        var integrationServer = GetServer<ProductionIntegrationServer>();

        AddServer(production, frontendServer);
        AddServer(production, backendServer);
        AddServer(production, databaseServer);
        AddServer(production, integrationServer);

        var frontendRuntime = GetRuntimeEnvironment<ProductionFrontendRuntimeEnvironment>();
        var backendRuntime = GetRuntimeEnvironment<ProductionBackendRuntimeEnvironment>();
        var databaseRuntime = GetRuntimeEnvironment<ProductionDatabaseRuntimeEnvironment>();
        var brokerRuntime = GetRuntimeEnvironment<ProductionBrokerRuntimeEnvironment>();

        AddRuntime(frontendServer, frontendRuntime);
        AddRuntime(backendServer, backendRuntime);
        AddRuntime(databaseServer, databaseRuntime);
        AddRuntime(integrationServer, brokerRuntime);

        DeployComponent(frontendRuntime, GetComponent<HRFrontendApplication>());
        DeployComponent(backendRuntime, GetComponent<HRBackendApplication>());
        DeployComponent(backendRuntime, GetComponent<HRBackendApiModule>());
        DeployComponent(backendRuntime, GetComponent<HRBackendApplicationModule>());
        DeployComponent(backendRuntime, GetComponent<HRBackendDomainModule>());
        DeployComponent(backendRuntime, GetComponent<HRBackendInfrastructureModule>());
        DeployComponent(databaseRuntime, GetComponent<HRDatabaseComponent>());
        DeployComponent(brokerRuntime, GetComponent<HRBrokerComponent>());
    }
}
