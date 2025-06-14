using System.Text;
using Modeler.DataModel.PostgreSQL.Views.Shared;
using Modeler.DataModel.Structure;

namespace Modeler.DataModel.PostgreSQL.Views.Mermaid;

public static class MermaidDataModelGenerator
{
    public static void Generate(
        string absoluteModelsPath,
        DataModel model,
        int indentSize,
        List<MermaidDataModelView> views,
        IViewTranslator viewTranslator)
    {
        foreach (var view in views)
        {
            var sb = new StringBuilder();

            sb.AppendLine("classDiagram");
            sb.AppendLine("%% Generated by Modeler - do not change.");
            sb.AppendLine();

            GenerateTables(sb, model, indentSize, view);
            GenerateViews(sb, model, indentSize, view);
            
            GenerateRelationships(sb, model, view, viewTranslator);

            sb.AppendLine();

            var content = sb.ToString();
            
            var path = Path.Combine(absoluteModelsPath, view.Path);
            var directoryPath = Path.GetDirectoryName(path)!;
            
            if (!Directory.Exists(directoryPath))
            {
                Directory.CreateDirectory(directoryPath);
            }

            File.WriteAllText(path, content);
        }
    }

    private static void GenerateRelationships(
        StringBuilder sb,
        DataModel model,
        MermaidDataModelView view,
        IViewTranslator viewTranslator)
    {
        foreach (var relationship in model.GetRelationships())
        {
            if (view.VisibleStructureElements.All(x => x.Element != relationship.From) ||
                view.VisibleStructureElements.All(x => x.Element != relationship.To))
            {
                continue;
            }

            const string relationshipType = "-->";

            sb.AppendLine(
                $"{relationship.From.Name} \"{viewTranslator.TranslateMultiplicity(relationship.FromMultiplicity)}\"" +
                $" {relationshipType} \"{viewTranslator.TranslateMultiplicity(relationship.ToMultiplicity)}\" {relationship.To.Name} : {relationship.GetRelationshipName()}");
        }
    }

    private static void GenerateTables(
        StringBuilder sb,
        DataModel model,
        int indentSize,
        MermaidDataModelView view)
    {
        var indent = string.Empty;
        for (int i = 0; i < indentSize; i++)
        {
            indent += " ";
        }

        foreach (var table in model.GetTables().OrderBy(x => x.Name))
        {
            var viewTable = view.VisibleStructureElements.SingleOrDefault(x => x.Element == table);
            if (viewTable == null)
            {
                continue;
            }
            
            GenerateTable(sb, viewTable, indent);
            sb.AppendLine();
        }
    }
    
    private static void GenerateViews(
        StringBuilder sb,
        DataModel model,
        int indentSize,
        MermaidDataModelView view)
    {
        var indent = string.Empty;
        for (int i = 0; i < indentSize; i++)
        {
            indent += " ";
        }

        foreach (var viewElement in model.GetViews().OrderBy(x => x.Name))
        {
            var viewTable = view.VisibleStructureElements.SingleOrDefault(x => x.Element == viewElement);
            if (viewTable == null)
            {
                continue;
            }
            
            GenerateView(sb, viewTable, indent);
            sb.AppendLine();
        }
    }

    private static void GenerateTable(
        StringBuilder sb,
        VisibleStructureElement visibleStructureElement,
        string indent)
    {
            sb.AppendLine($"class {visibleStructureElement.Element.Name} {{");

        var table = (Table)visibleStructureElement.Element;
        if (visibleStructureElement.ShowColumns)
        {
            foreach (var column in table.Columns.Select(x => x).OrderByDescending(x => x.IsPrimaryKey).ThenBy(x => x.Name))
            {
                var isNullString = column.IsPrimaryKey ? string.Empty : 
                    column.IsNullable ? "NULL" : "NOT NULL";
                var isPrimaryKeyString = column.IsPrimaryKey ? "PK" : string.Empty;
                sb.AppendLine($"{indent}{column.Name}: {column.Type.Name.Replace("(", "[").Replace(")", "]")} {isNullString} {isPrimaryKeyString}");
            }
        }

        sb.AppendLine("}");
    }
    
    private static void GenerateView(
        StringBuilder sb,
        VisibleStructureElement visibleStructureElement,
        string indent)
    {
        sb.AppendLine($"class {visibleStructureElement.Element.Name} {{");
        sb.AppendLine("<<view>>");

        var table = (View)visibleStructureElement.Element;
        if (visibleStructureElement.ShowColumns)
        {
            foreach (var column in table.Columns.OrderBy(x => x.Name))
            {
                sb.AppendLine($"{indent}{column.Name}: {column.Type.Name}");
            }
        }

        sb.AppendLine("}");
    }
}
