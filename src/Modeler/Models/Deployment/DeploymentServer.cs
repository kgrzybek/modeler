using Modeler.Models.Common.Elements;

namespace Modeler.Models.Deployment;

public abstract class DeploymentServer : Element
{
    protected DeploymentServer(string name) : base(name)
    {
    }
}
