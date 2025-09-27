using Modeler.Models.Common.Elements;

namespace Modeler.Models.Deployment;

public abstract class DeploymentEnvironment : Element
{
    protected DeploymentEnvironment(string name) : base(name)
    {
    }
}
