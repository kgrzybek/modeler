using System.Reflection;

namespace Modeler.ComponentsModel.Views.PlantUml;

public class ComponentsDiagramViewsFactory
{
    private readonly List<ComponentsDiagramView> _views;

    private readonly Model _model;

    public ComponentsDiagramViewsFactory(
        Model model,
        Assembly viewsAssembly)
    {
        _model = model;
        _views = new List<ComponentsDiagramView>();
        InitializeViews(viewsAssembly);
    }

    public List<ComponentsDiagramView> GetViews() => _views.ToList();

    private void InitializeViews(Assembly viewsAssembly)
    {
        var types = viewsAssembly
            .GetTypes()
            .Where(t =>
                typeof(ComponentsDiagramViewDefinition).IsAssignableFrom(t))
            .ToList();

        foreach (var type in types)
        {
            var staticMethod = type.GetMethod("Create", BindingFlags.Static | BindingFlags.Public);

            if (staticMethod != null)
            {
                var plantUmlView = staticMethod.Invoke(null, new object?[] {_model});
                _views.Add((ComponentsDiagramView) plantUmlView!);
            }
        }
    }
}