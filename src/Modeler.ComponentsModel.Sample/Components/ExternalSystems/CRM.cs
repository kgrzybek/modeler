using Modeler.ComponentsModel.Sample.Components.Types;

namespace Modeler.ComponentsModel.Sample.Components.ExternalSystems;

public class CRM : Component
{
    public const string ComponentName = "CRM";
    
    public static Component Create() => new CRM();
    
    private CRM() : base(ComponentName, new ExternalSystemComponentType())
    {
    }
}