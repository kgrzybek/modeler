using System.Text;
using Modeler.Attributes;
using Modeler.ConceptualModel.Views.Shared;
using Modeler.Relationships.Associations;
using Modeler.Relationships.Generalizations;
using Attribute = Modeler.Attributes.Attribute;

namespace Modeler.ConceptualModel.Views.PlantUml.PlantUml;

public class PlantUmlClassDiagramViewGenerator
{
    private readonly IViewTranslator _viewTranslator;

    private readonly IViewsOutput _viewsOutput;

    private readonly Model _model;

    private string _indentText = string.Empty;

    public PlantUmlClassDiagramViewGenerator(Model model, int indentSize, IViewTranslator viewTranslator, IViewsOutput viewsOutput)
    {
        _viewTranslator = viewTranslator;
        _viewsOutput = viewsOutput;
        _model = model;
        
        SetIndentText(indentSize);
    }

    public void Generate(
        List<ClassDiagramView> views)
    {
        var outputItems = new List<ViewOutputItem>();
        foreach (var view in views)
        {
            var sb = new StringBuilder();

            sb.AppendLine("@startuml");
            sb.AppendLine();

            GenerateEntities(sb, view);

            GenerateNonPrimitiveTypes(sb, view);

            GenerateRelationships(sb, view);

            sb.AppendLine();
            sb.AppendLine("@enduml");
            sb.AppendLine();

            var content = sb.ToString();
            
            outputItems.Add(new ViewOutputItem(view, content));
        }
        
        _viewsOutput.Execute(outputItems);
    }

    private void SetIndentText(int indentSize)
    {
        for (int i = 0; i < indentSize; i++)
        {
            _indentText += " ";
        }
    }

    private void GenerateNonPrimitiveTypes(StringBuilder sb, ClassDiagramView view)
    {
        var toGenerate = new List<AttributeType>();
        foreach (var entity in _model.GetEntities().OrderBy(x => x.Name))
        {
            var viewConcept = view.Entities.SingleOrDefault(x => x.Entity == entity);
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
                GenerateComplexAttributeType(sb, complexAttributeType);
                generated.Add(attributeType);
            }

            if (attributeType is EnumerationType enumerationType)
            {
                GenerateEnumerationType(sb, enumerationType);
                generated.Add(attributeType);
            }
        }
    }

    private void GenerateEnumerationType(
        StringBuilder sb,
        EnumerationType enumerationType)
    {
        sb.AppendLine($"enum \"{enumerationType.Name}\"" + " {");
        
        foreach (var literal in enumerationType.Values.OrderBy(x => x.Value))
        {
            sb.AppendLine($"{_indentText}{literal.Value}");
        }

        sb.AppendLine("}");
        sb.AppendLine();
    }

    private void GenerateComplexAttributeType(
        StringBuilder sb,
        ComplexAttributeType complexAttributeType)
    {
        sb.AppendLine($"class \"{complexAttributeType.Name}\"" + " {");

        foreach (var attribute in complexAttributeType.Attributes.OrderBy(x => x.Name))
        {
            var isRequiredString = attribute.IsRequired ? string.Empty : " [0..1]";
            sb.AppendLine($"{_indentText}{attribute.Name}: {attribute.Type.Name}{isRequiredString}");
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

    private void GenerateRelationships(StringBuilder sb, ClassDiagramView view)
    {
        foreach (var relationship in _model.GetRelationships())
        {
            if (view.Entities.All(x => !relationship.ForEntity(x.Entity)))
            {
                continue;
            }

            if (relationship is GeneralizationRelationship generalizationRelationship)
            {
                GenerateForGeneralization(
                    sb,
                    generalizationRelationship);
            }

            if (relationship is AssociationRelationship associationRelationship)
            {
                GenerateForAssociation(
                    sb,
                    associationRelationship);
            }
        }
    }

    private static void GenerateForGeneralization(StringBuilder sb, GeneralizationRelationship relationship)
    {
        sb.AppendLine(
            $"\"{relationship.General.Name}\" --|> \"{relationship.Specific.Name}\" ");
    }

    private void GenerateForAssociation(StringBuilder sb, AssociationRelationship relationship)
    {
        string relationshipLabel = relationship.SourceToTarget.Name;
        if (!string.IsNullOrEmpty(relationship.TargetToSource.Name))
        {
            relationshipLabel = $"{relationshipLabel} / {relationship.TargetToSource.Name}";
        }

        sb.AppendLine(
            $"\"{relationship.SourceToTarget.From.Name}\" \"{_viewTranslator.TranslateMultiplicity(relationship.TargetToSource.Multiplicity)}" +
            $"\" --> \"{_viewTranslator.TranslateMultiplicity(relationship.SourceToTarget.Multiplicity)}\" \"{relationship.SourceToTarget.To.Name}\" : \"{relationshipLabel}\" ");
    }


    private void GenerateEntities(
        StringBuilder sb,
        ClassDiagramView view)
    {
        foreach (var entity in _model.GetEntities().OrderBy(x => x.Name))
        {
            var viewConcept = view.Entities.SingleOrDefault(x => x.Entity == entity);
            if (viewConcept == null)
            {
                continue;
            }

            GenerateEntity(sb, entity, viewConcept);

            sb.AppendLine();
        }
    }

    private void GenerateEntity(
        StringBuilder sb,
        Entity entity,
        VisibleEntity viewEntity)
    {
        sb.AppendLine($"entity \"{entity.Name}\"" + " {");

        if (viewEntity.ShowAttributes)
        {
            foreach (var attribute in entity.Attributes.OrderBy(x => x.Name))
            {
                var isRequiredString = attribute.IsRequired ? string.Empty : " [0..1]";
                sb.AppendLine($"{_indentText}{attribute.Name}: {attribute.Type.Name}{isRequiredString}");
            }
        }

        sb.AppendLine("}");
    }
}