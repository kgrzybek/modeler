using System.Reflection;

namespace Modeler.ConceptualModel.Views.AsciiDoc;

public class AsciiDocViewsFactory
{
    private readonly List<AsciiDocView> _views;

    private readonly Model _model;

    public AsciiDocViewsFactory(
        Model model,
        Assembly viewsAssembly)
    {
        _model = model;
        _views = new List<AsciiDocView>();
        InitializeViews(viewsAssembly);
    }

    public List<AsciiDocView> GetViews() => _views.ToList();

    private void InitializeViews(Assembly viewsAssembly)
    {
        var types = viewsAssembly
            .GetTypes()
            .Where(t =>
                typeof(AsciiDocViewDefinition).IsAssignableFrom(t))
            .ToList();

        foreach (var type in types)
        {
            var staticMethod = type.GetMethod("Create", BindingFlags.Static | BindingFlags.Public);

            if (staticMethod != null)
            {
                var plantUmlView = staticMethod.Invoke(null, new object?[] {_model});
                _views.Add((AsciiDocView) plantUmlView!);
            }
        }
    }
}