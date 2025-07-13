using Modeler.ComponentsModel.Sample.Components.HRSystem.Backend;
using Modeler.ComponentsModel.Sample.Components.Types;
using Models.Elements;

namespace Modeler.ComponentsModel.Sample.Components.HRSystem.Database;

public class HRDatabase : Component
{
    public static IElement Create()
    {
        return new HRDatabase();
    }
    
    public const string ComponentName = "HR Database";
    
    public HRDatabase() : base(ComponentName, new DatabaseComponentType())
    {
    }
}