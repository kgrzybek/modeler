using Modeler.Models.Deployment;

namespace Modeler.Samples.HR.Deployment.RuntimeEnvironments;

public class ProductionBrokerRuntimeEnvironment : DeploymentRuntimeEnvironment
{
    public ProductionBrokerRuntimeEnvironment() : base("Kafka cluster")
    {
    }
}
