using System.Reflection;

namespace Modeler.SequenceModel.Views.PlantUml;

public class SequenceDiagramViewsFactory
{
    private readonly List<SequenceDiagramView> _views;

    private readonly Model _model;

    public SequenceDiagramViewsFactory(
        Model model,
        Assembly viewsAssembly)
    {
        _model = model;
        _views = new List<SequenceDiagramView>();
        InitializeViews(viewsAssembly);
    }

    public List<SequenceDiagramView> GetViews() => _views.ToList();

    private void InitializeViews(Assembly viewsAssembly)
    {
        var types = viewsAssembly
            .GetTypes()
            .Where(t =>
                typeof(SequenceDiagramViewDefinition).IsAssignableFrom(t))
            .ToList();

        foreach (var type in types)
        {
            var staticMethod = type.GetMethod("Create", BindingFlags.Static | BindingFlags.Public);

            if (staticMethod != null)
            {
                var plantUmlView = staticMethod.Invoke(null, new object?[] {_model});
                _views.Add((SequenceDiagramView) plantUmlView!);
            }
        }
    }
}