using System.Text;
using Modeler.ConceptualModel.Attributes;
using Modeler.ConceptualModel.Relationships.Associations;
using Modeler.ConceptualModel.Views.Shared;

namespace Modeler.ConceptualModel.Views.Markdown;

public class MarkdownViewsGenerator
{
    private readonly IViewTranslator _viewTranslator;

    private readonly IViewsOutput<MarkdownView> _viewsOutput;

    private readonly Model _model;

    private readonly MarkdownViewTranslationDictionary _translationDictionary;

    public MarkdownViewsGenerator(
        Model model,
        IViewTranslator viewTranslator,
        IViewsOutput<MarkdownView> viewsOutput,
        MarkdownViewTranslationDictionary? translationDictionary = null)
    {
        _viewTranslator = viewTranslator;
        _model = model;
        _viewsOutput = viewsOutput;
        _translationDictionary = translationDictionary ?? new MarkdownViewTranslationDictionary();
    }

    public void Generate(
        List<MarkdownView> views)
    {
        var outputItems = new List<ViewOutputItem<MarkdownView>>();
        foreach (var view in views)
        {
            var content = Generate(view);
            
            outputItems.Add(new ViewOutputItem<MarkdownView>(view.Id, view, content));
        }
        
        _viewsOutput.Execute(outputItems);
    }

    private string Generate(MarkdownView view)
    {
        return view.Concept switch
        {
            Entity entityConcept => GenerateEntity(entityConcept),
            EnumerationType enumConcept => Generate(enumConcept),
            ComplexAttributeType enumConcept => GenerateComplexType(enumConcept),
            _ => throw new ArgumentException("Invalid view")
        };
    }

    private string GenerateEntity(
        Entity entityConcept)
    {
        var sb = new StringBuilder();

        sb.AppendLine("<!-- Generated by Modeler - do not change. -->");
        sb.AppendLine($"### {_translationDictionary.AttributesText} - {entityConcept.Name}");
        sb.AppendLine($"|{_translationDictionary.NameHeaderText}|{_translationDictionary.TypeHeaderText}|{_translationDictionary.IsRequiredHeaderText}|");
        sb.AppendLine("|---|---|---|");

        var generalizationConcept = GetGeneralizationConcept(entityConcept);

        if (generalizationConcept != null)
        {
            foreach (var attribute in (generalizationConcept).Attributes.OrderBy(x => x.Name))
            {
                sb.AppendLine($"|({generalizationConcept.Name}) {attribute.Name}|{attribute.Type.Name}|{(attribute.IsRequired ? _translationDictionary.IsRequiredYesValueText : _translationDictionary.IsRequiredNoValueText)}|");
            }
        }

        foreach (var attribute in entityConcept.Attributes.OrderBy(x => x.Name))
        {
            sb.AppendLine($"|{attribute.Name}|{attribute.Type.Name}|{(attribute.IsRequired ? _translationDictionary.IsRequiredYesValueText : _translationDictionary.IsRequiredNoValueText)}|");
        }

        sb.AppendLine();

        GenerateRelations(entityConcept, sb);

        return sb.ToString();
    }
    
    private string GenerateComplexType(
        ComplexAttributeType complexAttributeType)
    {
        var sb = new StringBuilder();

        sb.AppendLine("<!-- Generated by Modeler - do not change. -->");
        sb.AppendLine($"### {_translationDictionary.AttributesText} - {complexAttributeType.Name}");
        sb.AppendLine($"|{_translationDictionary.NameHeaderText}|{_translationDictionary.TypeHeaderText}|{_translationDictionary.IsRequiredHeaderText}|");
        sb.AppendLine("|---|---|---|");

        foreach (var attribute in complexAttributeType.Attributes.OrderBy(x => x.Name))
        {
            sb.AppendLine($"|{attribute.Name}|{attribute.Type.Name}|{(attribute.IsRequired ? _translationDictionary.IsRequiredYesValueText : _translationDictionary.IsRequiredNoValueText)}|");
        }

        sb.AppendLine();

        return sb.ToString();
    }

    private Entity? GetGeneralizationConcept(Entity entityConcept)
    {
        var generalizationConcept = _model.GetGeneralizations()
            .Where(x => Equals(x.Specific, entityConcept))
            .Select(x => x.General)
            .SingleOrDefault();

        return generalizationConcept;
    }

    private void GenerateRelations(Entity concept, StringBuilder sb)
    {
        sb.AppendLine($"### {_translationDictionary.RelationsText} - {concept.Name}");
        sb.AppendLine($"|{_translationDictionary.RelationsFromHeaderText}|{_translationDictionary.RelationsNameHeaderText}|{_translationDictionary.RelationsMultiplicityHeaderText}|{_translationDictionary.RelationsToHeaderText}|{_translationDictionary.RelationsDescriptionHeaderText}|");
        sb.AppendLine("|---|---|---|---|---|");
        
        var generalizationConcept = GetGeneralizationConcept(concept);

        if (generalizationConcept != null)
        {
            GenerateRelationsForConcept(generalizationConcept, sb, true);
        }

        GenerateRelationsForConcept(concept, sb, false);
    }

    private void GenerateRelationsForConcept(Entity concept, StringBuilder sb, bool inherited)
    {
        var relationships =
            _model.GetAssociations().Where(x => Equals(x.SourceToTarget.From, concept) ||
                                               Equals(x.TargetToSource.From, concept)).ToList();
        if (inherited)
        {
            var generalizationEntity = _model.GetGeneralizationEntity(concept);
            if (generalizationEntity != null)
            {
                var generalizationRelationships =
                    _model.GetAssociations().Where(x => Equals(x.SourceToTarget.From, generalizationEntity) ||
                                                        Equals(x.TargetToSource.From, generalizationEntity));
                relationships.AddRange(generalizationRelationships);
            }
        }

        foreach (var relationship in relationships)
        {
            AssociationDirectedRelationship firstRelation;
            AssociationDirectedRelationship secondRelation;

            if (Equals(relationship.SourceToTarget.From, concept))
            {
                firstRelation = relationship.SourceToTarget;
                secondRelation = relationship.TargetToSource;
            }
            else
            {
                firstRelation = relationship.TargetToSource;
                secondRelation = relationship.SourceToTarget;
            }

            var inheritedFromName = inherited ? $"({concept.Name}) " : string.Empty;

            sb.AppendLine($"|{inheritedFromName}{firstRelation.From.Name}|{firstRelation.Name}|{_viewTranslator.TranslateMultiplicity(firstRelation.Multiplicity)}|*{firstRelation.To.Name}*|{firstRelation.Description}|");

            sb.AppendLine($"|*{inheritedFromName}{secondRelation.From.Name}*|{secondRelation.Name}|{_viewTranslator.TranslateMultiplicity(secondRelation.Multiplicity)}|{secondRelation.To.Name}|{secondRelation.Description}|");
        }
    }

    private string Generate(
        EnumerationType enumConcept)
    {
        var sb = new StringBuilder();

        sb.AppendLine($"### {_translationDictionary.EnumerationValuesText} - {enumConcept.Name}");
        sb.AppendLine($"|{_translationDictionary.EnumerationNameText}|");
        sb.AppendLine("|---|");

        foreach (var value in enumConcept.Values.OrderBy(x => x.Value))
        {
            sb.AppendLine($"|{value.Value}|");
        }

        sb.AppendLine();

        return sb.ToString();
    }
}
