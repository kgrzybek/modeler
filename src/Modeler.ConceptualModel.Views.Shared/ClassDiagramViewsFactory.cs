using System.Reflection;

namespace Modeler.ConceptualModel.Views.Shared;

public class ClassDiagramViewsFactory
{
    private readonly List<ClassDiagramView> _views;

    private readonly Model _model;

    public ClassDiagramViewsFactory(
        Model model,
        Assembly viewsAssembly)
    {
        _model = model;
        _views = new List<ClassDiagramView>();
        InitializeViews(viewsAssembly);
    }

    public List<ClassDiagramView> GetViews() => _views.ToList();

    private void InitializeViews(Assembly viewsAssembly)
    {
        var types = viewsAssembly
            .GetTypes()
            .Where(t =>
                typeof(ClassDiagramViewDefinition).IsAssignableFrom(t))
            .ToList();

        foreach (var type in types)
        {
            var staticMethod = type.GetMethod("Create", BindingFlags.Static | BindingFlags.Public);

            if (staticMethod != null)
            {
                var plantUmlView = staticMethod.Invoke(null, new object?[] {_model});
                _views.Add((ClassDiagramView) plantUmlView!);
            }
        }
    }
}