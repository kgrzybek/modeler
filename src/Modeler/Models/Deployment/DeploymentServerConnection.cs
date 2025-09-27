namespace Modeler.Models.Deployment;

public record DeploymentServerConnection(
    DeploymentServer Source,
    DeploymentServer Target,
    string? Protocol,
    int? Port
);
