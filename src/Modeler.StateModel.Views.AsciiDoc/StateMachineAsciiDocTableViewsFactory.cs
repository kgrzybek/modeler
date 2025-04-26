using System.Reflection;

namespace Modeler.StateModel.Views.AsciiDoc;

public class StateMachineAsciiDocTableViewsFactory
{
    private readonly List<StateMachineAsciiDocTableView> _views;

    private readonly Model _model;

    public StateMachineAsciiDocTableViewsFactory(
        Model model,
        Assembly viewsAssembly)
    {
        _model = model;
        _views = new List<StateMachineAsciiDocTableView>();
        InitializeViews(viewsAssembly);
    }

    public List<StateMachineAsciiDocTableView> GetViews() => _views.ToList();

    private void InitializeViews(Assembly viewsAssembly)
    {
        var types = viewsAssembly
            .GetTypes()
            .Where(t =>
                typeof(StateMachineAsciiDocTableViewDefinition).IsAssignableFrom(t))
            .ToList();

        foreach (var type in types)
        {
            var staticMethod = type.GetMethod("Create", BindingFlags.Static | BindingFlags.Public);

            if (staticMethod != null)
            {
                var plantUmlView = staticMethod.Invoke(null, new object?[] {_model});
                _views.Add((StateMachineAsciiDocTableView) plantUmlView!);
            }
        }
    }
}