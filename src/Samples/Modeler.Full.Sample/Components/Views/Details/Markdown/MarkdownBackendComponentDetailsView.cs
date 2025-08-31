using Modeler.Full.Sample.Components.System.Backend;
using Modeler.Views.Components.Details.Markdown;

namespace Modeler.Full.Sample.Components.Views.Details.Markdown;

public class MarkdownBackendComponentDetailsView : MarkdownComponentDetailsView
{
    public MarkdownBackendComponentDetailsView(SystemComponentsModel model) : base(model.GetComponent<HRBackendApplication>())
    {
    }
}
