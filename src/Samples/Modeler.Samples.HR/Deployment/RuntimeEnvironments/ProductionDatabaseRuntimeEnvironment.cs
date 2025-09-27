using Modeler.Models.Deployment;

namespace Modeler.Samples.HR.Deployment.RuntimeEnvironments;

public class ProductionDatabaseRuntimeEnvironment : DeploymentRuntimeEnvironment
{
    public ProductionDatabaseRuntimeEnvironment() : base("PostgreSQL 15")
    {
    }
}
