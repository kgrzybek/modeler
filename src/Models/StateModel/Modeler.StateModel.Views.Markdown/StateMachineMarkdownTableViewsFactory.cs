using System.Reflection;

namespace Modeler.StateModel.Views.Markdown;

public class StateMachineMarkdownTableViewsFactory
{
    private readonly List<StateMachineMarkdownTableView> _views;
    private readonly StateMachineModel _stateMachineModel;

    public StateMachineMarkdownTableViewsFactory(StateMachineModel stateMachineModel, Assembly viewsAssembly)
    {
        _stateMachineModel = stateMachineModel;
        _views = new List<StateMachineMarkdownTableView>();
        InitializeViews(viewsAssembly);
    }

    public List<StateMachineMarkdownTableView> GetViews() => _views.ToList();

    private void InitializeViews(Assembly viewsAssembly)
    {
        var types = viewsAssembly
            .GetTypes()
            .Where(t => typeof(StateMachineMarkdownTableViewDefinition).IsAssignableFrom(t))
            .ToList();

        foreach (var type in types)
        {
            var staticMethod = type.GetMethod("Create", BindingFlags.Static | BindingFlags.Public);
            if (staticMethod != null)
            {
                var view = staticMethod.Invoke(null, new object?[] { _stateMachineModel });
                _views.Add((StateMachineMarkdownTableView)view!);
            }
        }
    }
}
