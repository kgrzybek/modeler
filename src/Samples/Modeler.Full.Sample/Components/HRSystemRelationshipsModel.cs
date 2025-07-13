using Modeler.ComponentsModel;

namespace Modeler.Full.Sample.Components;

public class HRSystemRelationshipsModel : RelationshipsModel
{
    public static void Create(SystemComponentsModel model)
    {
        var api = model.GetComponent<BackendApplication>();
        var frontend = model.GetComponent<HRFrontendApplication>();

        model.AddUsageRelationship(frontend, api);
    }
}