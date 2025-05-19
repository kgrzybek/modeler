using System.Reflection;

namespace Modeler.ComponentsModel.Views.AsciiDoc.Details;

public class AsciiDocComponentsDetailsViewsFactory
{
    private readonly List<AsciiDocComponentDetailsView> _views;

    private readonly Model _model;

    public AsciiDocComponentsDetailsViewsFactory(
        Model model,
        Assembly viewsAssembly)
    {
        _model = model;
        _views = new List<AsciiDocComponentDetailsView>();
        InitializeViews(viewsAssembly);
    }

    public List<AsciiDocComponentDetailsView> GetViews() => _views.ToList();

    private void InitializeViews(Assembly viewsAssembly)
    {
        var types = viewsAssembly
            .GetTypes()
            .Where(t =>
                typeof(AsciiDocComponentDetailsViewDefinition).IsAssignableFrom(t))
            .ToList();

        foreach (var type in types)
        {
            var staticMethod = type.GetMethod("Create", BindingFlags.Static | BindingFlags.Public);

            if (staticMethod != null)
            {
                var plantUmlView = staticMethod.Invoke(null, new object?[] {_model});
                _views.Add((AsciiDocComponentDetailsView) plantUmlView!);
            }
        }
    }
}