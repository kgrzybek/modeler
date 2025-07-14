using Modeler.ComponentsModel.Views.AsciiDoc.Details;
using Modeler.Full.Sample.Components.System.Frontend;

namespace Modeler.Full.Sample.Components.Views.AsciiDoc.Details;

public class AsciiDocFrontendDetailsViewDefinition : AsciiDocComponentDetailsViewDefinition
{
    public const string Id = "FrontendDetailsView";
    public static AsciiDocComponentDetailsView Create(SystemComponentsModel model)
    {
        return new AsciiDocComponentDetailsView(Id, model.GetComponent<HRFrontendApplication>());
    }
}