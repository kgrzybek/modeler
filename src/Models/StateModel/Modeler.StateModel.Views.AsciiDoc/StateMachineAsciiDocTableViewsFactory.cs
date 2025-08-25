using System.Reflection;

namespace Modeler.StateModel.Views.AsciiDoc;

public class StateMachineAsciiDocTableViewsFactory
{
    private readonly List<StateMachineAsciiDocTableView> _views;

    private readonly StateMachineModel _stateMachineModel;

    public StateMachineAsciiDocTableViewsFactory(
        StateMachineModel stateMachineModel,
        Assembly viewsAssembly)
    {
        _stateMachineModel = stateMachineModel;
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
                var plantUmlView = staticMethod.Invoke(null, new object?[] {_stateMachineModel});
                _views.Add((StateMachineAsciiDocTableView) plantUmlView!);
            }
        }
    }
}