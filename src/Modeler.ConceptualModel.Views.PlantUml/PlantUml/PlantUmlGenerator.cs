using System.Text;
using Modeler.Attributes;
using Modeler.Relationships.Associations;
using Modeler.Relationships.Associations.Multiplicity;
using Modeler.Relationships.Generalizations;
using Attribute = Modeler.Attributes.Attribute;

namespace Modeler.ConceptualModel.Views.PlantUml.PlantUml;

public static class PlantUmlGenerator
{
    public static void Generate(
        string absoluteModelsPath,
        Model model,
        int indentSize,
        List<PlantUmlView> views,
        MultiplicityTranslator multiplicityTranslator)
    {
        foreach (var view in views)
        {
            var sb = new StringBuilder();

            sb.AppendLine("@startuml");
            sb.AppendLine();

            GenerateEntities(sb, model, indentSize, view);

            GenerateTypes(sb, model, indentSize, view);

            GenerateRelationships(sb, model, view, multiplicityTranslator);

            sb.AppendLine();
            sb.AppendLine("@enduml");
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

    private static void GenerateTypes(StringBuilder sb, Model model, int indentSize, PlantUmlView view)
    {
        var indent = string.Empty;
        for (int i = 0; i < indentSize; i++)
        {
            indent += " ";
        }

        var toGenerate = new List<AttributeType>();
        foreach (var entity in model.GetEntities().OrderBy(x => x.Name))
        {
            var viewConcept = view.Entities.SingleOrDefault(x => x.Concept == entity);
            if (viewConcept == null)
            {
                continue;
            }

            toGenerate.AddRange(GetAttributesToGenerate(entity.Attributes));
        }

        var generated = new List<AttributeType>();
        foreach (var attributeType in toGenerate)
        {
            if (generated.Any(x => x.GetType() == attributeType.GetType()))
            {
                continue;
            }
            
            if (attributeType is ComplexAttributeType complexAttributeType)
            {
                GenerateComplexAttributeType(sb, complexAttributeType, indent);
                generated.Add(attributeType);
            }

            if (attributeType is EnumerationType enumerationType)
            {
                GenerateEnumerationType(sb, indent, enumerationType);
                generated.Add(attributeType);
            }
        }
    }

    private static void GenerateEnumerationType(
        StringBuilder sb,
        string indent,
        EnumerationType enumerationType)
    {
        sb.AppendLine($"enum \"{enumerationType.Name}\"" + " {");
        
        foreach (var literal in enumerationType.Values.OrderBy(x => x.Value))
        {
            sb.AppendLine($"{indent}{literal.Value}");
        }

        sb.AppendLine("}");
        sb.AppendLine();
    }

    private static void GenerateComplexAttributeType(
        StringBuilder sb,
        ComplexAttributeType complexAttributeType,
        string indent)
    {
        sb.AppendLine($"class \"{complexAttributeType.Name}\"" + " {");

        foreach (var attribute in complexAttributeType.Attributes.OrderBy(x => x.Name))
        {
            var isRequiredString = attribute.IsRequired ? string.Empty : " [0..1]";
            sb.AppendLine($"{indent}{attribute.Name}: {attribute.Type.Name}{isRequiredString}");
        }

        sb.AppendLine("}");
        sb.AppendLine();
    }

    private static List<AttributeType> GetAttributesToGenerate(List<Attribute> attributes)
    {
        var toGenerate = new List<AttributeType>();
        foreach (var attribute in attributes)
        {
            if (attribute.Type is ComplexAttributeType complexAttributeType)
            {
                toGenerate.Add(complexAttributeType);

                toGenerate.AddRange(GetAttributesToGenerate(complexAttributeType.Attributes));
            }

            if (attribute.Type is EnumerationType enumerationType)
            {
                toGenerate.Add(enumerationType);
            }
        }

        return toGenerate;
    }

    private static void GenerateRelationships(StringBuilder sb, Model model, PlantUmlView view,
        MultiplicityTranslator multiplicityTranslator)
    {
        foreach (var relationship in model.GetRelationships())
        {
            if (view.Entities.All(x => !relationship.ForEntity(x.Concept)))
            {
                continue;
            }

            if (relationship is GeneralizationRelationship generalizationRelationship)
            {
                GenerateForGeneralization(
                    sb,
                    generalizationRelationship,
                    model);
            }

            if (relationship is AssociationRelationship associationRelationship)
            {
                GenerateForAssociation(
                    sb,
                    associationRelationship,
                    model,
                    multiplicityTranslator);
            }
        }
    }

    private static void GenerateForGeneralization(StringBuilder sb, GeneralizationRelationship relationship,
        Model model)
    {
        sb.AppendLine(
            $"\"{relationship.General.Name}\" --|> \"{relationship.Specific.Name}\" ");
    }

    private static void GenerateForAssociation(StringBuilder sb, AssociationRelationship relationship, Model model,
        MultiplicityTranslator multiplicityTranslator)
    {
        string relationshipLabel = relationship.SourceToTarget.Name;
        if (!string.IsNullOrEmpty(relationship.TargetToSource.Name))
        {
            relationshipLabel = $"{relationshipLabel} / {relationship.TargetToSource.Name}";
        }

        sb.AppendLine(
            $"\"{relationship.SourceToTarget.From.Name}\" \"{multiplicityTranslator.Translate(relationship.TargetToSource.Multiplicity)}" +
            $"\" --> \"{multiplicityTranslator.Translate(relationship.SourceToTarget.Multiplicity)}\" \"{relationship.SourceToTarget.To.Name}\" : \"{relationshipLabel}\" ");
    }


    private static void GenerateEntities(
        StringBuilder sb,
        Model model,
        int indentSize,
        PlantUmlView view)
    {
        var indent = string.Empty;
        for (int i = 0; i < indentSize; i++)
        {
            indent += " ";
        }

        foreach (var entity in model.GetEntities().OrderBy(x => x.Name))
        {
            var viewConcept = view.Entities.SingleOrDefault(x => x.Concept == entity);
            if (viewConcept == null)
            {
                continue;
            }

            GenerateConcept(sb, entity, viewConcept, indent);

            sb.AppendLine();
        }
    }

    private static void GenerateConcept(
        StringBuilder sb,
        Entity entity,
        VisibleEntity viewEntity,
        string indent)
    {
        sb.AppendLine($"entity \"{entity.Name}\"" + " {");

        if (viewEntity.ShowAttributes)
        {
            foreach (var attribute in entity.Attributes.OrderBy(x => x.Name))
            {
                var isRequiredString = attribute.IsRequired ? string.Empty : " [0..1]";
                sb.AppendLine($"{indent}{attribute.Name}: {attribute.Type.Name}{isRequiredString}");
            }
        }

        sb.AppendLine("}");
    }
}