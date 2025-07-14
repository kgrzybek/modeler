using Modeler.ComponentsModel.Views.Markdown.Details;
using Modeler.Full.Sample.Components.System.Frontend;

namespace Modeler.Full.Sample.Components.Views.Markdown.Details;

public class MarkdownFrontendDetailsViewDefinition : MarkdownComponentDetailsViewDefinition
{
    public const string Id = "FrontendDetailsView";
    public static MarkdownComponentDetailsView Create(SystemComponentsModel model)
    {
        return new MarkdownComponentDetailsView(Id, model.GetComponent<HRFrontendApplication>());
    }
}
