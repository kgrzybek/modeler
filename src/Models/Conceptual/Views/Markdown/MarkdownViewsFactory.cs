using System.Reflection;

namespace Modeler.ConceptualModel.Views.Markdown;

public class MarkdownViewsFactory
{
    private readonly List<MarkdownView> _views;

    private readonly Model _model;

    public MarkdownViewsFactory(
        Model model,
        Assembly viewsAssembly)
    {
        _model = model;
        _views = new List<MarkdownView>();
        InitializeViews(viewsAssembly);
    }

    public List<MarkdownView> GetViews() => _views.ToList();

    private void InitializeViews(Assembly viewsAssembly)
    {
        var types = viewsAssembly
            .GetTypes()
            .Where(t =>
                typeof(MarkdownViewDefinition).IsAssignableFrom(t))
            .ToList();

        foreach (var type in types)
        {
            var staticMethod = type.GetMethod("Create", BindingFlags.Static | BindingFlags.Public);

            if (staticMethod != null)
            {
                var plantUmlView = staticMethod.Invoke(null, new object?[] {_model});
                _views.Add((MarkdownView) plantUmlView!);
            }
        }
    }
}
