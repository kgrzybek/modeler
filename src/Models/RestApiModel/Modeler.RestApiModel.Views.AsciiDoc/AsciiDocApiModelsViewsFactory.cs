using System.Reflection;

namespace Modeler.RestApiModel.Views.AsciiDoc;

public class AsciiDocApiModelsViewsFactory
{
    private readonly List<AsciiDocApiModelsView> _views;
    private readonly Model _model;

    public AsciiDocApiModelsViewsFactory(Model model, Assembly viewsAssembly)
    {
        _model = model;
        _views = new List<AsciiDocApiModelsView>();
        InitializeViews(viewsAssembly);
    }

    public List<AsciiDocApiModelsView> Views => _views.ToList();

    private void InitializeViews(Assembly viewsAssembly)
    {
        var types = viewsAssembly
            .GetTypes()
            .Where(t => typeof(AsciiDocApiModelsViewDefinition).IsAssignableFrom(t));
        foreach (var type in types)
        {
            var method = type.GetMethod("Create", BindingFlags.Static | BindingFlags.Public);
            if (method != null)
            {
                var view = method.Invoke(null, new object?[] { _model });
                _views.Add((AsciiDocApiModelsView)view!);
            }
        }
    }
}
