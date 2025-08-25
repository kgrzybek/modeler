using System.Reflection;

namespace Modeler.StateModel.Views.PlantUml;

public class StateMachineViewsFactory
{
    private readonly List<StateMachineView> _views;

    private readonly StateMachineModel _stateMachineModel;

    public StateMachineViewsFactory(
        StateMachineModel stateMachineModel,
        Assembly viewsAssembly)
    {
        _stateMachineModel = stateMachineModel;
        _views = new List<StateMachineView>();
        InitializeViews(viewsAssembly);
    }

    public List<StateMachineView> GetViews() => _views.ToList();

    private void InitializeViews(Assembly viewsAssembly)
    {
        var types = viewsAssembly
            .GetTypes()
            .Where(t =>
                typeof(StateMachineViewDefinition).IsAssignableFrom(t))
            .ToList();

        foreach (var type in types)
        {
            var staticMethod = type.GetMethod("Create", BindingFlags.Static | BindingFlags.Public);

            if (staticMethod != null)
            {
                var plantUmlView = staticMethod.Invoke(null, new object?[] {_stateMachineModel});
                _views.Add((StateMachineView) plantUmlView!);
            }
        }
    }
}