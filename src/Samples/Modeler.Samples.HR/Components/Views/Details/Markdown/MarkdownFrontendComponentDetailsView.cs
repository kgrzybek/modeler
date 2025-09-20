using Modeler.Samples.HR.Components.System.Frontend;
using Modeler.Views.Components.Details.Markdown;

namespace Modeler.Samples.HR.Components.Views.Details.Markdown;

public class MarkdownFrontendComponentDetailsView : MarkdownComponentDetailsView
{
    public MarkdownFrontendComponentDetailsView(HRSystemComponentsModel model) : base(model.GetComponent<HRFrontendApplication>())
    {
    }
}