using System.Reflection;

namespace Modeler.DataModel.PostgreSQL.Views.PlantUml;

public class PlantUmlDataModelViewsFactory
{
    private readonly DataModel _model;
    
    public PlantUmlDataModelViewsFactory(DataModel model)
    {
        _model = model;
        Views = new List<PlantUmlDataModelView>();
    }

    public void Initialize(Assembly modelAssembly)
    {
        InitializeViews(modelAssembly);
    }

    private void InitializeViews(Assembly modelAssembly)
    {
        Views = new List<PlantUmlDataModelView>();
        
        var types = modelAssembly
            .GetTypes()
            .Where(t =>
                typeof(PlantUmlDataModelViewFactory).IsAssignableFrom(t))
            .ToList();

        foreach (var type in types)
        {
            var staticMethod = type.GetMethod("Create", BindingFlags.Static | BindingFlags.Public);

            if (staticMethod != null)
            {
                var plantUmlView = staticMethod.Invoke(null, new object?[] {_model});
                Views.Add((PlantUmlDataModelView)plantUmlView!);
            }
        }
    }
    
    public List<PlantUmlDataModelView> Views { get; private set; }
}