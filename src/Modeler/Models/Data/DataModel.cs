using System.Reflection;
using Modeler.DataModel.Relationships;
using Modeler.DataModel.Relationships.Multiplicity;
using Modeler.DataModel.Schemas;
using Modeler.DataModel.Structure;
using Models.Elements;

namespace Modeler.DataModel;

public class DataModel : IModel
{
    protected DataModel(ModelElementsRegistry elementsRegistry)
    {
        _tables = elementsRegistry.GetElements<Table>();
        _views = elementsRegistry.GetElements<View>();
        _relationships = new List<StructureElementRelationship>();
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

    public Schema GetSchema<T>() where T : Schema
    {
        var schema = GetTables().Select(x => x.Schema).Distinct().OfType<T>().Single();

        if (schema == null)
        {
            throw new Exception($"Schema {typeof(T)} is not defined in the model");
        }

        return schema;
    }
}