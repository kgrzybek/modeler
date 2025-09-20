using Modeler.Models.Components.Relationships;

namespace Modeler.Views.Components.Common;

public interface IComponentsViewTranslator
{
    string TranslateSourceToTargetRelationshipName(ComponentRelationship relationship);
    
    string TranslateTargetToSourceRelationshipName(ComponentRelationship relationship);
}