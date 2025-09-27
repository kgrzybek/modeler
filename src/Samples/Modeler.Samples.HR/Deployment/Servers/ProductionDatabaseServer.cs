using Modeler.Models.Deployment;

namespace Modeler.Samples.HR.Deployment.Servers;

public class ProductionDatabaseServer : DeploymentServer
{
    public ProductionDatabaseServer() : base("Database server")
    {
    }
}
