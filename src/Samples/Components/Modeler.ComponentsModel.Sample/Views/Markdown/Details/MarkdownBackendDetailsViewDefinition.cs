using Modeler.ComponentsModel.Sample.Components;
using Modeler.ComponentsModel.Sample.Components.HRSystem.Backend;
using Modeler.ComponentsModel.Views.Markdown.Details;

namespace Modeler.ComponentsModel.Sample.Views.Markdown.Details;

public class MarkdownBackendDetailsViewDefinition : MarkdownComponentDetailsViewDefinition
{
    public const string Id = "BackendDetailsView";
    public static MarkdownComponentDetailsView Create(SystemComponentsModel model)
    {
        return new MarkdownComponentDetailsView(Id, model.GetComponent<HRBackendApplication>());
    }
}
