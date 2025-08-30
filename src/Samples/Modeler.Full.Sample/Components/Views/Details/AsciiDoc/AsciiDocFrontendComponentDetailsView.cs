using Modeler.ComponentsModel.Views.AsciiDoc.Details;
using Modeler.Full.Sample.Components.System.Frontend;

namespace Modeler.Full.Sample.Components.Views.Details.AsciiDoc;

public class AsciiDocFrontendComponentDetailsView : AsciiDocComponentDetailsView
{
    public AsciiDocFrontendComponentDetailsView(SystemComponentsModel model) : base(model.GetComponent<HRFrontendApplication>())
    {
    }
}