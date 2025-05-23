﻿using System.Text;
using Modeler.DataModel.PostgreSQL.Views.Shared;
using Modeler.DataModel.Structure;

namespace Modeler.DataModel.PostgreSQL.Views.AsciiDoc;

public static class DataModelAsciiDocGenerator
{
    public static void Generate(
        string absoluteModelsPath,
        string modelName,
        DataModel model,
        IViewTranslator viewTranslator)
    {
        var schemaNames = model.GetTables().Select(x => x.Schema.Name).Distinct();

        foreach (var schema in schemaNames)
        {
            var sb = new StringBuilder();
            sb.AppendLine("// Generated by conceptualizer - do not change.");
            GenerateTables(modelName, model, schema, sb, viewTranslator);
            GenerateViews(modelName, model, schema, sb);
            
            var content = sb.ToString();

            var path = Path.Combine(absoluteModelsPath, $"{modelName.ToUpper()}/{schema}_schema.adoc");
            var directoryPath = Path.GetDirectoryName(path)!;

            if (!Directory.Exists(directoryPath))
            {
                Directory.CreateDirectory(directoryPath);
            }

            File.WriteAllText(path, content, Encoding.UTF8);
        }
    }

    private static void GenerateTables(
        string modelName,
        DataModel model,
        string schema,
        StringBuilder sb,
        IViewTranslator viewTranslator)
    {
        sb.AppendLine($"[#data_model_{modelName.ToLower()}_{schema.ToLower()}_tables]");
        sb.AppendLine("=== Tables");
        sb.AppendLine();
        var tables = model.GetTables();

        foreach (var table in tables.Where(x => x.Schema.Name == schema).OrderBy(x => x.Name))
        {
            sb.AppendLine($"[#data_model_{modelName.ToLower()}_{schema}_tables_{table.Name.ToLower()}]");
            sb.AppendLine($"==== {table.Name}");
            sb.AppendLine();

            sb.AppendLine($".Tables - {table.Name} - columns");
            sb.AppendLine("[cols=4*]");
            sb.AppendLine("|===");
            sb.AppendLine("|Name| Type| Is required| Description");
            sb.AppendLine();

            foreach (var column in table.Columns
                         .Select(x => (TableColumn)x).OrderBy(x => !x.IsPrimaryKey)
                         .ThenBy(x => x.Name))
            {
                var name = column.IsPrimaryKey ? $"{column.Name} PK" : column.Name;
                sb.AppendLine($"|{name}");
                sb.AppendLine($"|{column.Type.Name}");
                sb.AppendLine($"|{(!column.IsNullable ? "YES" : "NO")}");
                sb.AppendLine($"|{column.Description}");
                sb.AppendLine();
            }

            sb.AppendLine("|===");

            var fromRelations = model.GetRelationships().Where(x => x.From == table).ToList();

            if (fromRelations.Any())
            {
                sb.AppendLine($".Tables - {table.Name} - relationships from");
                sb.AppendLine("[cols=5*]");
                sb.AppendLine("|===");
                sb.AppendLine("|From |Multiplicity |Column |Multiplicity |To");
                sb.AppendLine();

                foreach (var relation in fromRelations)
                {
                    var fromViewStereotype = relation.From is View ? " (view)" : string.Empty;
                    sb.AppendLine($"|{relation.From.Name}{fromViewStereotype}");
                    sb.AppendLine($"|{viewTranslator.TranslateMultiplicity(relation.FromMultiplicity)}");
                    sb.AppendLine($"|{relation.GetRelationshipName()}");
                    sb.AppendLine($"|{viewTranslator.TranslateMultiplicity(relation.ToMultiplicity)}");
                    var toViewStereotype = relation.To is View ? " (view)" : string.Empty;
                    sb.AppendLine($"|{relation.To.Name}{toViewStereotype}");
                    sb.AppendLine();
                }

                sb.AppendLine("|===");
                sb.AppendLine();
            }

            var toRelations = model.GetRelationships().Where(x => x.To == table).ToList();

            if (toRelations.Any())
            {
                sb.AppendLine($".Tables - {table.Name} - relationships to");
                sb.AppendLine("[cols=5*]");
                sb.AppendLine("|===");
                sb.AppendLine("|From |Multiplicity |Column |Multiplicity |To");
                sb.AppendLine();

                foreach (var relation in toRelations)
                {
                    var fromViewStereotype = relation.From is View ? " (view)" : string.Empty;
                    sb.AppendLine($"|{relation.From.Name}{fromViewStereotype}");
                    sb.AppendLine($"|{viewTranslator.TranslateMultiplicity(relation.FromMultiplicity)}");
                    sb.AppendLine($"|{relation.GetRelationshipName()}");
                    sb.AppendLine($"|{viewTranslator.TranslateMultiplicity(relation.ToMultiplicity)}");
                    var toViewStereotype = relation.To is View ? " (view)" : string.Empty;
                    sb.AppendLine($"|{relation.To.Name}{toViewStereotype}");
                    sb.AppendLine();
                }

                sb.AppendLine("|===");
                sb.AppendLine();
            }

            sb.AppendLine();
        }
    }

    private static void GenerateViews(
        string modelName,
        DataModel model,
        string schema,
        StringBuilder sb)
    {
        sb.AppendLine($"[#data_model_{modelName.ToLower()}_{schema.ToLower()}_views]");
        sb.AppendLine("==== Views");
        sb.AppendLine();
        var views = model.GetViews();

        foreach (var view in views.OrderBy(x => x.Name))
        {
            sb.AppendLine($"[#data_model_{modelName.ToLower()}_{schema.ToLower()}_views_{view.Name.ToLower()}]");
            sb.AppendLine($"===== {view.Name}");
            sb.AppendLine();

            sb.AppendLine($".View - {view.Name} - columns");
            sb.AppendLine("[cols=2*]");
            sb.AppendLine("|===");
            sb.AppendLine("|Name| Type");
            sb.AppendLine();

            foreach (var column in view.Columns.OrderBy(x => x.Name))
            {
                sb.AppendLine($"|{column.Name}");
                sb.AppendLine($"|{column.Type.Name}");
                sb.AppendLine();
            }

            sb.AppendLine("|===");

            var fromRelations = model.GetRelationships().Where(x => x.From == view).ToList();

            if (fromRelations.Any())
            {
                sb.AppendLine($".View - {view.Name} - relationships from");
                sb.AppendLine("[cols=5*]");
                sb.AppendLine("|===");
                sb.AppendLine("|From |Multiplicity |Column |Multiplicity |To");
                sb.AppendLine();

                foreach (var relation in fromRelations)
                {
                    var fromViewStereotype = relation.From is View ? " (view)" : string.Empty;
                    sb.AppendLine($"|{relation.From.Name}{fromViewStereotype}");
                    sb.AppendLine($"|{relation.FromMultiplicity}");
                    sb.AppendLine($"|{relation.GetRelationshipName()}");
                    sb.AppendLine($"|{relation.ToMultiplicity}");
                    var toViewStereotype = relation.To is View ? " (view)" : string.Empty;
                    sb.AppendLine($"|{relation.To.Name}{toViewStereotype}");
                    sb.AppendLine();
                }

                sb.AppendLine("|===");
                sb.AppendLine();
            }

            var toRelations = model.GetRelationships().Where(x => x.To == view).ToList();

            if (toRelations.Any())
            {
                sb.AppendLine($".View - {view.Name} - relationships to");
                sb.AppendLine("[cols=5*]");
                sb.AppendLine("|===");
                sb.AppendLine("|From |Multiplicity |Column |Multiplicity |To");
                sb.AppendLine();

                foreach (var relation in toRelations)
                {
                    var fromViewStereotype = relation.From is View ? " (view)" : string.Empty;
                    sb.AppendLine($"|{relation.From.Name}{fromViewStereotype}");
                    sb.AppendLine($"|{relation.FromMultiplicity}");
                    sb.AppendLine($"|{relation.GetRelationshipName()}");
                    sb.AppendLine($"|{relation.ToMultiplicity}");
                    var toViewStereotype = relation.To is View ? " (view)" : string.Empty;
                    sb.AppendLine($"|{relation.To.Name}{toViewStereotype}");
                    sb.AppendLine();
                }

                sb.AppendLine("|===");
                sb.AppendLine();
            }

            sb.AppendLine();
        }
    }
}