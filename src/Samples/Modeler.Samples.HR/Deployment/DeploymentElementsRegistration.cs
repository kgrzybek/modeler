using Modeler.Samples.HR.Deployment.Environments;
using Modeler.Samples.HR.Deployment.RuntimeEnvironments;
using Modeler.Samples.HR.Deployment.Servers;

namespace Modeler.Samples.HR.Deployment;

internal static class DeploymentElementsRegistration
{
    internal static void RegisterDeploymentElements(this ElementsRegistry elementsRegistry)
    {
        elementsRegistry.AddElement(new ProductionEnvironment());

        elementsRegistry.AddElement(new ProductionFrontendServer());
        elementsRegistry.AddElement(new ProductionBackendServer());
        elementsRegistry.AddElement(new ProductionDatabaseServer());
        elementsRegistry.AddElement(new ProductionIntegrationServer());

        elementsRegistry.AddElement(new ProductionFrontendRuntimeEnvironment());
        elementsRegistry.AddElement(new ProductionBackendRuntimeEnvironment());
        elementsRegistry.AddElement(new ProductionDatabaseRuntimeEnvironment());
        elementsRegistry.AddElement(new ProductionBrokerRuntimeEnvironment());
    }
}
