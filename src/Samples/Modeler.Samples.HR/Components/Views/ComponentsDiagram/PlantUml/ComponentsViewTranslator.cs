using Modeler.Models.Components.Relationships;
using Modeler.Samples.HR.Components.Relationships;
using Modeler.Views.Components.Common;

namespace Modeler.Samples.HR.Components.Views.ComponentsDiagram.PlantUml;

public class ComponentsViewTranslator : IComponentsViewTranslator
{
    public string TranslateSourceToTargetRelationshipName(ComponentRelationship relationship)
    {
        if (relationship is UsageComponentRelationship)
        {
            return "uses";
        }

        if (relationship is DependencyComponentRelationship)
        {
            return "depends";
        }

        if (relationship is AssociationComponentRelationship)
        {
            return string.Empty;
        }

        if (relationship is ContainsComponentRelationship)
        {
            return "contains";
        }
        
        if (relationship is PublishSubscribeRelationship)
        {
            return "pub/sub";
        }

        if (relationship is SqlRelationshipComponentRelationship sqlRelationship)
        {
            return PlantUmlComponentDiagramRelationshipsGenerator.GetLabel(sqlRelationship);
        }
        
        throw new NotSupportedException(relationship.GetType().Name);
    }

    public string TranslateTargetToSourceRelationshipName(ComponentRelationship relationship)
    {
        if (relationship is UsageComponentRelationship)
        {
            return "is used by";
        }

        if (relationship is DependencyComponentRelationship)
        {
            return "dependent of";
        }

        if (relationship is AssociationComponentRelationship)
        {
            return string.Empty;
        }

        if (relationship is ContainsComponentRelationship)
        {
            return "Is contained by";
        }
        
        if (relationship is PublishSubscribeRelationship)
        {
            return string.Empty;
        }
        
        if (relationship is SqlRelationshipComponentRelationship)
        {
            return string.Empty;
        }
        
        throw new NotSupportedException(relationship.GetType().Name);
    }
}