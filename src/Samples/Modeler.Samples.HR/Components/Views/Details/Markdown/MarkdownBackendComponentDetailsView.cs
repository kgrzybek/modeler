using Modeler.Samples.HR.Components.System.Backend;
using Modeler.Views.Components.Details.Markdown;

namespace Modeler.Samples.HR.Components.Views.Details.Markdown;

public class MarkdownBackendComponentDetailsView : MarkdownComponentDetailsView
{
    public MarkdownBackendComponentDetailsView(HRSystemComponentsModel model) : base(model.GetComponent<HRBackendApplication>())
    {
    }
}
