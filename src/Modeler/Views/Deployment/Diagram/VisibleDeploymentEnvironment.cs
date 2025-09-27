using System;
using Modeler.Models.Deployment;

namespace Modeler.Views.Deployment.Diagram;

public class VisibleDeploymentEnvironment
{
    public VisibleDeploymentEnvironment(DeploymentEnvironment environment, int nestedLevel = 3)
    {
        Environment = environment;
        NestedLevel = Math.Max(0, nestedLevel);
    }

    public DeploymentEnvironment Environment { get; }

    public int NestedLevel { get; }
}
