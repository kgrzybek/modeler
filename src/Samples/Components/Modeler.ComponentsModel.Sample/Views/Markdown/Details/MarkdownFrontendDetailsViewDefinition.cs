using Modeler.ComponentsModel.Sample.Components;
using Modeler.ComponentsModel.Sample.Components.HRSystem.Frontend;
using Modeler.ComponentsModel.Views.Markdown.Details;

namespace Modeler.ComponentsModel.Sample.Views.Markdown.Details;

public class MarkdownFrontendDetailsViewDefinition : MarkdownComponentDetailsViewDefinition
{
    public const string Id = "FrontendDetailsView";
    public static MarkdownComponentDetailsView Create(SystemComponentsModel model)
    {
        return new MarkdownComponentDetailsView(Id, model.GetComponent<HRFrontendApplication>());
    }
}
