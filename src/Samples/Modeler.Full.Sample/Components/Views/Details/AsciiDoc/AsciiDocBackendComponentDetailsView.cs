using Modeler.ComponentsModel.Views.AsciiDoc.Details;
using Modeler.Full.Sample.Components.System.Backend;

namespace Modeler.Full.Sample.Components.Views.Details.AsciiDoc;

public class AsciiDocBackendComponentDetailsView : AsciiDocComponentDetailsView
{
    public AsciiDocBackendComponentDetailsView(SystemComponentsModel model) : base(model.GetComponent<HRBackendApplication>())
    {
    }
}