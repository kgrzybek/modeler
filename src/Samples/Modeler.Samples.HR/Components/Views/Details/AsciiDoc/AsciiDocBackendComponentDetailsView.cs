using Modeler.Samples.HR.Components.System.Backend;
using Modeler.Views.Components.Details.AsciiDoc;

namespace Modeler.Samples.HR.Components.Views.Details.AsciiDoc;

public class AsciiDocBackendComponentDetailsView : AsciiDocComponentDetailsView
{
    public AsciiDocBackendComponentDetailsView(HRSystemComponentsModel model) : base(model.GetComponent<HRBackendApplication>())
    {
    }
}