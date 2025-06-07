using System.Reflection;

namespace Modeler.EventsFlowModel.Views.Markdown;

public class MarkdownEventsFlowViewsFactory
{
    private readonly Model _model;
    private readonly List<MarkdownEventFlowsView> _views;

    public MarkdownEventsFlowViewsFactory(Model model, Assembly viewsAssembly)
    {
        _model = model;
        _views = new List<MarkdownEventFlowsView>();
        InitializeViews(viewsAssembly);
    }

    public List<MarkdownEventFlowsView> Views => _views.ToList();

    private void InitializeViews(Assembly viewsAssembly)
    {
        var types = viewsAssembly
            .GetTypes()
            .Where(t => typeof(MarkdownEventFlowsViewDefinition).IsAssignableFrom(t))
            .ToList();

        foreach (var type in types)
        {
            var staticMethod = type.GetMethod("Create", BindingFlags.Static | BindingFlags.Public);
            if (staticMethod != null)
            {
                var view = staticMethod.Invoke(null, new object?[] { _model });
                _views.Add((MarkdownEventFlowsView)view!);
            }
        }
    }
}
