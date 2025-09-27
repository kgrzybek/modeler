using System.Collections.Generic;
using Modeler.Models.Components;
using Modeler.Models.Deployment;
using Modeler.Views.Common;

namespace Modeler.Views.Deployment.Diagram;

public abstract class PlantUmlDeploymentDiagramView : IView
{
    public List<VisibleDeploymentEnvironment> VisibleEnvironments { get; protected init; } = [];

    public List<DeploymentServer> HiddenServers { get; protected init; } = [];

    public List<DeploymentRuntimeEnvironment> HiddenRuntimeEnvironments { get; protected init; } = [];

    public List<IComponent> HiddenComponents { get; protected init; } = [];
}
