using Modeler.Models.Deployment;

namespace Modeler.Samples.HR.Deployment.Environments;

public class ProductionEnvironment : DeploymentEnvironment
{
    public ProductionEnvironment() : base("Production")
    {
    }
}
