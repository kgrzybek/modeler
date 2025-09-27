using Modeler.Models.Common.Elements;

namespace Modeler.Models.Deployment;

public abstract class DeploymentRuntimeEnvironment : Element
{
    protected DeploymentRuntimeEnvironment(string name) : base(name)
    {
    }
}
