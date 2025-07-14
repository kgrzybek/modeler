using Modeler.ComponentsModel.Views.Markdown.Details;
using Modeler.Full.Sample.Components.System.Backend;

namespace Modeler.Full.Sample.Components.Views.Markdown.Details;

public class MarkdownBackendDetailsViewDefinition : MarkdownComponentDetailsViewDefinition
{
    public const string Id = "BackendDetailsView";
    public static MarkdownComponentDetailsView Create(SystemComponentsModel model)
    {
        return new MarkdownComponentDetailsView(Id, model.GetComponent<HRBackendApplication>());
    }
}
