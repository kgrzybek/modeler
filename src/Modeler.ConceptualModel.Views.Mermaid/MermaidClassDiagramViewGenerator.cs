using System.Text;
using Modeler.Attributes;
using Modeler.ConceptualModel.Views.Shared;
using Modeler.Relationships.Associations;
using Modeler.Relationships.Generalizations;
using Attribute = Modeler.Attributes.Attribute;

namespace Modeler.ConceptualModel.Views.Mermaid;

public class MermaidClassDiagramViewGenerator
{
    private readonly IViewTranslator _viewTranslator;

    private readonly IViewsOutput<ClassDiagramView> _viewsOutput;

    private readonly Model _model;

    private string _indentText = string.Empty;

    public MermaidClassDiagramViewGenerator(Model model, int indentSize, IViewTranslator viewTranslator, IViewsOutput<ClassDiagramView> viewsOutput)
    {
        _viewTranslator = viewTranslator;
        _viewsOutput = viewsOutput;
        _model = model;
        
        SetIndentText(indentSize);
    }

    public void Generate(
        List<ClassDiagramView> views)
    {
        var outputItems = new List<ViewOutputItem<ClassDiagramView>>();
        foreach (var view in views)
        {
            var sb = new StringBuilder();

            sb.AppendLine("classDiagram");
            sb.AppendLine();

            GenerateEntities(sb, view);

            GenerateNonPrimitiveTypes(sb, view);

            GenerateRelationships(sb, view);

            var content = sb.ToString();
            
            outputItems.Add(new ViewOutputItem<ClassDiagramView>(view.Id, view, content));
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
        sb.AppendLine($"class {enumerationType.Name} {{");
        sb.AppendLine("<<enumeration>>");
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
        sb.AppendLine($"class {complexAttributeType.Name} {{");

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
            $"{relationship.Specific.Name} --|> {relationship.General.Name} ");
    }

    private void GenerateForAssociation(StringBuilder sb, AssociationRelationship relationship)
    {
        string relationshipLabel = relationship.SourceToTarget.Name;
        if (!string.IsNullOrEmpty(relationship.TargetToSource.Name))
        {
            relationshipLabel = $"{relationshipLabel} / {relationship.TargetToSource.Name}";
        }

        sb.AppendLine(
            $"{relationship.SourceToTarget.From.Name} \"{_viewTranslator.TranslateMultiplicity(relationship.TargetToSource.Multiplicity)}\"" +
            $" --> \"{_viewTranslator.TranslateMultiplicity(relationship.SourceToTarget.Multiplicity)}\" {relationship.SourceToTarget.To.Name} : {relationshipLabel} ");
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
        if (entity.Attributes.Any() && viewEntity.ShowAttributes)
        {
            sb.AppendLine($"class {entity.Name} {{");

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
        else
        {
            sb.AppendLine($"class {entity.Name}");
        }
    }
}