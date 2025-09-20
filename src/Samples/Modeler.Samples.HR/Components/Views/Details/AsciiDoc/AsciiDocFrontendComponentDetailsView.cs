using Modeler.Samples.HR.Components.System.Frontend;
using Modeler.Views.Components.Details.AsciiDoc;

namespace Modeler.Samples.HR.Components.Views.Details.AsciiDoc;

public class AsciiDocFrontendComponentDetailsView : AsciiDocComponentDetailsView
{
    public AsciiDocFrontendComponentDetailsView(HRSystemComponentsModel model) : base(model.GetComponent<HRFrontendApplication>())
    {
    }
}