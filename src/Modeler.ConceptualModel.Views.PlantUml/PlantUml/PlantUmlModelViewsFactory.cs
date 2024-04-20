using System.Reflection;

namespace Modeler.ConceptualModel.Views.PlantUml.PlantUml;

public abstract class PlantUmlModelViewsFactory
{
    private static PlantUmlModelViewsFactory? _instance;

    protected PlantUmlModelViewsFactory()
    {
        Views = new List<PlantUmlView>();
        InitializeViews();
    }

    private void InitializeViews()
    {
        var assembly = Assembly.GetAssembly(this.GetType())!;
        var types = assembly
            .GetTypes()
            .Where(t =>
                typeof(PlantUmlViewFactory).IsAssignableFrom(t))
            .ToList();

        foreach (var type in types)
        {
            var staticMethod = type.GetMethod("Create", BindingFlags.Static | BindingFlags.Public);

            if (staticMethod != null)
            {
                var plantUmlView = staticMethod.Invoke(null, null);
                Views.Add((PlantUmlView) plantUmlView!);
            }
        }
    }

    public List<PlantUmlView> Views { get; }
}