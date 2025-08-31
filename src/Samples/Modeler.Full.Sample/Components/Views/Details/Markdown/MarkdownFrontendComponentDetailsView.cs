using Modeler.Full.Sample.Components.System.Frontend;
using Modeler.Views.Components.Details.Markdown;

namespace Modeler.Full.Sample.Components.Views.Details.Markdown;

public class MarkdownFrontendComponentDetailsView : MarkdownComponentDetailsView
{
    public MarkdownFrontendComponentDetailsView(SystemComponentsModel model) : base(model.GetComponent<HRFrontendApplication>())
    {
    }
}