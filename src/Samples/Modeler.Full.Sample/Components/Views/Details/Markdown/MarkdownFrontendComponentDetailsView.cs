using Modeler.ComponentsModel.Views.Markdown.Details;
using Modeler.Full.Sample.Components.System.Frontend;

namespace Modeler.Full.Sample.Components.Views.Details.Markdown;

public class MarkdownFrontendComponentDetailsView : MarkdownComponentDetailsView
{
    public MarkdownFrontendComponentDetailsView(SystemComponentsModel model) : base(model.GetComponent<HRFrontendApplication>())
    {
    }
}