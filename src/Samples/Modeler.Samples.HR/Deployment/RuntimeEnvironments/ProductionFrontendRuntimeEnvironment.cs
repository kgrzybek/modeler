using Modeler.Models.Deployment;

namespace Modeler.Samples.HR.Deployment.RuntimeEnvironments;

public class ProductionFrontendRuntimeEnvironment : DeploymentRuntimeEnvironment
{
    public ProductionFrontendRuntimeEnvironment() : base("Static hosting: HR Frontend")
    {
    }
}
