using System.Text;
using Modeler.Models.Components.Relationships;

namespace Modeler.Views.Components.Diagram;

public interface IPlantUmlComponentDiagramRelationshipGenerator
{
    public bool Generate(ComponentRelationship relationship, StringBuilder sb);
}