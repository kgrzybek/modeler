using System.Reflection;
using Modeler.DataModel.Relationships;
using Modeler.DataModel.Relationships.Multiplicity;
using Modeler.DataModel.Structure;

namespace Modeler.DataModel;

public class DataModel
{
    private void InitializeTables()
    {
        var assembly = Assembly.GetAssembly(this.GetType())!;
        var types = assembly
            .GetTypes()
            .Where(t =>
                typeof(Table).IsAssignableFrom(t))
            .ToList();

        foreach (var type in types)
        {
            var staticMethod = type.GetMethod("Create", BindingFlags.Static | BindingFlags.Public);

            if (staticMethod != null)
            {
                var concept = staticMethod.Invoke(null, null);
                _tables.Add((Table)concept!);
            }
        }
    }

    private void InitializeViews()
    {
        var assembly = Assembly.GetAssembly(this.GetType())!;
        var types = assembly
            .GetTypes()
            .Where(t =>
                typeof(View).IsAssignableFrom(t))
            .ToList();

        foreach (var type in types)
        {
            var staticMethod = type.GetMethod("Create", BindingFlags.Static | BindingFlags.Public);

            if (staticMethod != null)
            {
                var concept = staticMethod.Invoke(null, null);
                _views.Add((View)concept!);
            }
        }
    }

    private void InitializeModels()
    {
        var assembly = Assembly.GetAssembly(this.GetType())!;
        var types = assembly
            .GetTypes()
            .Where(t =>
                typeof(TableRelationshipsModel).IsAssignableFrom(t))
            .ToList();

        foreach (var type in types)
        {
            var staticMethod = type.GetMethod("Create", BindingFlags.Static | BindingFlags.Public);

            if (staticMethod != null)
            {
                staticMethod.Invoke(null, new object?[]{ this });
            }
        }
    }

    protected DataModel()
    {
        _tables = new List<Table>();
        _views = new List<View>();
        _relationships = new List<StructureElementRelationship>();
        InitializeTables();
        InitializeViews();
        InitializeModels();
    }

    private List<Table> _tables;

    private List<View> _views;

    private List<StructureElementRelationship> _relationships;

    public T GetTable<T>()
        where T : Table
    {
        var concept = _tables.OfType<T>().SingleOrDefault();

        if (concept == null)
        {
            throw new Exception($"Table {typeof(T)} is not defined in the model");
        }

        return concept;
    }
    
    public T GetView<T>()
        where T : View
    {
        var concept = _views.OfType<T>().SingleOrDefault();

        if (concept == null)
        {
            throw new Exception($"View {typeof(T)} is not defined in the model");
        }

        return concept;
    }

    public void AddRelationship(
        Table from,
        string fromColumnName,
        RelationshipMultiplicity fromMultiplicity,
        Table to,
        string toColumnName,
        RelationshipMultiplicity toMultiplicity)
    {
        _relationships.Add(new StructureElementRelationship(
            from,
            fromColumnName,
            fromMultiplicity,
            to,
            toColumnName,
            toMultiplicity));
    }

    public List<StructureElementRelationship> GetRelationships() => _relationships.ToList();

    public List<Table> GetTables() => _tables.ToList();

    public List<View> GetViews() => _views.ToList();
}