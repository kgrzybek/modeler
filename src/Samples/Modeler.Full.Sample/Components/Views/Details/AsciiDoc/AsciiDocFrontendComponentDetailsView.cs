using Modeler.Full.Sample.Components.System.Frontend;
using Modeler.Views.Components.Details.AsciiDoc;

namespace Modeler.Full.Sample.Components.Views.Details.AsciiDoc;

public class AsciiDocFrontendComponentDetailsView : AsciiDocComponentDetailsView
{
    public AsciiDocFrontendComponentDetailsView(SystemComponentsModel model) : base(model.GetComponent<HRFrontendApplication>())
    {
    }
}