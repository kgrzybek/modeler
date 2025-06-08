using System.Reflection;

namespace Modeler.DataModel.PostgreSQL.Views.Mermaid;

public class MermaidDataModelViewsFactory
{
    private readonly DataModel _model;
    
    public MermaidDataModelViewsFactory(DataModel model)
    {
        _model = model;
        Views = new List<MermaidDataModelView>();
    }

    public void Initialize(Assembly modelAssembly)
    {
        InitializeViews(modelAssembly);
    }

    private void InitializeViews(Assembly modelAssembly)
    {
        Views = new List<MermaidDataModelView>();
        
        var types = modelAssembly
            .GetTypes()
            .Where(t =>
                typeof(MermaidDataModelViewFactory).IsAssignableFrom(t))
            .ToList();

        foreach (var type in types)
        {
            var staticMethod = type.GetMethod("Create", BindingFlags.Static | BindingFlags.Public);

            if (staticMethod != null)
            {
                var plantUmlView = staticMethod.Invoke(null, new object?[] {_model});
                Views.Add((MermaidDataModelView)plantUmlView!);
            }
        }
    }
    
    public List<MermaidDataModelView> Views { get; private set; }
}
