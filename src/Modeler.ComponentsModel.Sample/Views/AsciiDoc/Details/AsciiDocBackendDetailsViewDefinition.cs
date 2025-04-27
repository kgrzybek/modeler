using Modeler.ComponentsModel.Sample.Components;
using Modeler.ComponentsModel.Sample.Components.HRSystem.Backend;
using Modeler.ComponentsModel.Views.AsciiDoc.Details;

namespace Modeler.ComponentsModel.Sample.Views.AsciiDoc.Details;

public class AsciiDocBackendDetailsViewDefinition : AsciiDocComponentDetailsViewDefinition
{
    public const string Id = "BackendDetailsView";
    public static AsciiDocComponentDetailsView Create(SystemComponentsModel model)
    {
        return new AsciiDocComponentDetailsView(Id, model.GetComponent<HRBackendApplication>());
    }
}