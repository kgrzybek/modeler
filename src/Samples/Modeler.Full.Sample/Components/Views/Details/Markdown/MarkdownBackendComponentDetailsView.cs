using Modeler.ComponentsModel.Views.Markdown.Details;
using Modeler.Full.Sample.Components.System.Backend;

namespace Modeler.Full.Sample.Components.Views.Details.Markdown;

public class MarkdownBackendComponentDetailsView : MarkdownComponentDetailsView
{
    public MarkdownBackendComponentDetailsView(SystemComponentsModel model) : base(model.GetComponent<HRBackendApplication>())
    {
    }
}
