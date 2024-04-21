using System.Reflection;

namespace Modeler.ConceptualModel.Views.PlantUml.PlantUml;

public class PlantUmlModelViewsFactory
{
    private readonly List<PlantUmlView> _views;

    private readonly Model _model;

    public PlantUmlModelViewsFactory(
        Model model,
        Assembly viewsAssembly)
    {
        _model = model;
        _views = new List<PlantUmlView>();
        InitializeViews(viewsAssembly);
    }

    public List<PlantUmlView> GetViews() => _views.ToList();

    private void InitializeViews(Assembly viewsAssembly)
    {
        var types = viewsAssembly
            .GetTypes()
            .Where(t =>
                typeof(PlantUmlViewFactory).IsAssignableFrom(t))
            .ToList();

        foreach (var type in types)
        {
            var staticMethod = type.GetMethod("Create", BindingFlags.Static | BindingFlags.Public);

            if (staticMethod != null)
            {
                var plantUmlView = staticMethod.Invoke(null, new object?[] {_model});
                _views.Add((PlantUmlView) plantUmlView!);
            }
        }
    }
}