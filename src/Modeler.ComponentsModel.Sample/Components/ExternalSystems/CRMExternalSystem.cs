using Modeler.ComponentsModel.Sample.Components.Types;

namespace Modeler.ComponentsModel.Sample.Components.ExternalSystems;

public class CRMExternalSystem : Component
{
    public static Component Create() => new CRMExternalSystem();
    
    private CRMExternalSystem() : base("CRM System", new ExternalSystemComponentType())
    {
    }
}