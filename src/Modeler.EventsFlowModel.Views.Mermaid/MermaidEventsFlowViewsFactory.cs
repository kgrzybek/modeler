using System.Reflection;

namespace Modeler.EventsFlowModel.Views.Mermaid;

public class MermaidEventsFlowViewsFactory
{
    private readonly Model _model;
    
    public MermaidEventsFlowViewsFactory(Model model, Assembly viewsAssembly)
    {
        _model = model;
        Views = new List<MermaidEventFlowsView>();
        InitializeViews(viewsAssembly);
    }

    private void InitializeViews(Assembly modelAssembly)
    {
        Views = new List<MermaidEventFlowsView>();
        
        var types = modelAssembly
            .GetTypes()
            .Where(t =>
                typeof(MermaidEventFlowsViewDefinition).IsAssignableFrom(t))
            .ToList();

        foreach (var type in types)
        {
            var staticMethod = type.GetMethod("Create", BindingFlags.Static | BindingFlags.Public);

            if (staticMethod != null)
            {
                var plantUmlView = staticMethod.Invoke(null, new object?[] {_model});
                Views.Add((MermaidEventFlowsView)plantUmlView!);
            }
        }
    }
    
    public List<MermaidEventFlowsView> Views { get; private set; }
}