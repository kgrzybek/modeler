using Modeler.Full.Sample.Components.System.Backend;
using Modeler.Views.Components.Details.AsciiDoc;

namespace Modeler.Full.Sample.Components.Views.Details.AsciiDoc;

public class AsciiDocBackendComponentDetailsView : AsciiDocComponentDetailsView
{
    public AsciiDocBackendComponentDetailsView(SystemComponentsModel model) : base(model.GetComponent<HRBackendApplication>())
    {
    }
}