using Modeler.Models.Deployment;

namespace Modeler.Samples.HR.Deployment.RuntimeEnvironments;

public class ProductionBackendRuntimeEnvironment : DeploymentRuntimeEnvironment
{
    public ProductionBackendRuntimeEnvironment() : base("Docker: HR Backend")
    {
    }
}
