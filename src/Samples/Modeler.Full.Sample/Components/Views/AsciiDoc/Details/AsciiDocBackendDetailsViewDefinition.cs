using Modeler.ComponentsModel.Views.AsciiDoc.Details;
using Modeler.Full.Sample.Components.System.Backend;

namespace Modeler.Full.Sample.Components.Views.AsciiDoc.Details;

public class AsciiDocBackendDetailsViewDefinition : AsciiDocComponentDetailsViewDefinition
{
    public const string Id = "BackendDetailsView";
    public static AsciiDocComponentDetailsView Create(SystemComponentsModel model)
    {
        return new AsciiDocComponentDetailsView(Id, model.GetComponent<HRBackendApplication>());
    }
}