using Modeler.ComponentsModel.Sample.Components;
using Modeler.ComponentsModel.Sample.Components.HRSystem.Frontend;
using Modeler.ComponentsModel.Views.AsciiDoc.Details;

namespace Modeler.ComponentsModel.Sample.Views.AsciiDoc.Details;

public class AsciiDocFrontendDetailsViewDefinition : AsciiDocComponentDetailsViewDefinition
{
    public const string Id = "FrontendDetailsView";
    public static AsciiDocComponentDetailsView Create(SystemComponentsModel model)
    {
        return new AsciiDocComponentDetailsView(Id, model.GetComponent<HRFrontendApplication>());
    }
}