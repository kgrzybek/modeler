using System.Reflection;

namespace Modeler.RestApiModel.Views.OpenApi;

public class OpenApiViewsFactory
{
    private readonly List<OpenApiView> _views;
    private readonly Model _model;

    public OpenApiViewsFactory(Model model, Assembly viewsAssembly)
    {
        _model = model;
        _views = new List<OpenApiView>();
        InitializeViews(viewsAssembly);
    }

    public List<OpenApiView> Views => _views.ToList();

    private void InitializeViews(Assembly viewsAssembly)
    {
        var types = viewsAssembly
            .GetTypes()
            .Where(t => typeof(OpenApiViewDefinition).IsAssignableFrom(t));
        foreach (var type in types)
        {
            var method = type.GetMethod("Create", BindingFlags.Static | BindingFlags.Public);
            if (method != null)
            {
                var view = method.Invoke(null, new object?[] { _model });
                _views.Add((OpenApiView)view!);
            }
        }
    }
}
