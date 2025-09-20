using Modeler.Models.Components.Relationships;
using Modeler.Views.Components.Common;
using Modeler.Views.Components.Diagram;

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
        
        throw new NotSupportedException(relationship.GetType().Name);
    }
}