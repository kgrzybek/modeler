using System.Reflection;

namespace Modeler.RestApiModel.Views.AsciiDoc;

public class AsciiDocEndpointsViewsFactory
{
    private readonly List<AsciiDocEndpointsView> _views;
    private readonly Model _model;

    public AsciiDocEndpointsViewsFactory(Model model, Assembly viewsAssembly)
    {
        _model = model;
        _views = new List<AsciiDocEndpointsView>();
        InitializeViews(viewsAssembly);
    }

    public List<AsciiDocEndpointsView> Views => _views.ToList();

    private void InitializeViews(Assembly viewsAssembly)
    {
        var types = viewsAssembly
            .GetTypes()
            .Where(t => typeof(AsciiDocEndpointsViewDefinition).IsAssignableFrom(t));
        foreach (var type in types)
        {
            var method = type.GetMethod("Create", BindingFlags.Static | BindingFlags.Public);
            if (method != null)
            {
                var view = method.Invoke(null, new object?[] { _model });
                _views.Add((AsciiDocEndpointsView)view!);
            }
        }
    }
}
