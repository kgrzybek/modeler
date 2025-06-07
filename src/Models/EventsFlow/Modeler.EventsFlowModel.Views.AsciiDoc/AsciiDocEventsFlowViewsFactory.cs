using System.Reflection;

namespace Modeler.EventsFlowModel.Views.AsciiDoc;

public class AsciiDocEventsFlowViewsFactory
{
    private readonly Model _model;
    private readonly List<AsciiDocEventFlowsView> _views;

    public AsciiDocEventsFlowViewsFactory(Model model, Assembly viewsAssembly)
    {
        _model = model;
        _views = new List<AsciiDocEventFlowsView>();
        InitializeViews(viewsAssembly);
    }

    public List<AsciiDocEventFlowsView> Views => _views.ToList();

    private void InitializeViews(Assembly viewsAssembly)
    {
        var types = viewsAssembly
            .GetTypes()
            .Where(t => typeof(AsciiDocEventFlowsViewDefinition).IsAssignableFrom(t))
            .ToList();

        foreach (var type in types)
        {
            var staticMethod = type.GetMethod("Create", BindingFlags.Static | BindingFlags.Public);
            if (staticMethod != null)
            {
                var view = staticMethod.Invoke(null, new object?[] { _model });
                _views.Add((AsciiDocEventFlowsView)view!);
            }
        }
    }
}
