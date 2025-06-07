using System.Reflection;

namespace Modeler.ComponentsModel.Views.Markdown.Details;

public class MarkdownComponentsDetailsViewsFactory
{
    private readonly List<MarkdownComponentDetailsView> _views;
    private readonly Model _model;

    public MarkdownComponentsDetailsViewsFactory(Model model, Assembly viewsAssembly)
    {
        _model = model;
        _views = new List<MarkdownComponentDetailsView>();
        InitializeViews(viewsAssembly);
    }

    public List<MarkdownComponentDetailsView> GetViews() => _views.ToList();

    private void InitializeViews(Assembly viewsAssembly)
    {
        var types = viewsAssembly
            .GetTypes()
            .Where(t => typeof(MarkdownComponentDetailsViewDefinition).IsAssignableFrom(t))
            .ToList();

        foreach (var type in types)
        {
            var staticMethod = type.GetMethod("Create", BindingFlags.Static | BindingFlags.Public);
            if (staticMethod != null)
            {
                var view = staticMethod.Invoke(null, new object?[] { _model });
                _views.Add((MarkdownComponentDetailsView)view!);
            }
        }
    }
}
