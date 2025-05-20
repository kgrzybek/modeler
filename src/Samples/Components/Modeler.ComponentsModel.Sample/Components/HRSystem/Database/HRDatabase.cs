using Modeler.ComponentsModel.Sample.Components.Types;

namespace Modeler.ComponentsModel.Sample.Components.HRSystem.Database;

public class HRDatabase : Component
{
    public const string ComponentName = "HR Database";
    
    public HRDatabase() : base(ComponentName, new DatabaseComponentType())
    {
    }
}