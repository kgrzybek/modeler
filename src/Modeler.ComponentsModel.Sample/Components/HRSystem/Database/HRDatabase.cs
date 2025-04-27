using Modeler.ComponentsModel.Sample.Components.Types;

namespace Modeler.ComponentsModel.Sample.Components.HRSystem.Database;

public class HRDatabase : Component
{
    public HRDatabase() : base("HR Database", new DatabaseComponentType())
    {
    }
}