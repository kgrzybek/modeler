using System.Text;
using Modeler.Models.Components.Relationships;
using Modeler.Samples.HR.Components.Relationships;
using Modeler.Views.Components.Diagram;

namespace Modeler.Samples.HR.Components.Views.ComponentsDiagram.PlantUml;

public class PlantUmlComponentDiagramRelationshipsGenerator : IPlantUmlComponentDiagramRelationshipGenerator
{
    public bool Generate(ComponentRelationship relationship, StringBuilder sb)
    {
        if (relationship is SqlRelationshipComponentRelationship sqlRelationship)
        {
            GenerateForSql(sqlRelationship, sb);
            return true;
        }

        return false;
    }

    private static void GenerateForSql(SqlRelationshipComponentRelationship relationship, StringBuilder sb)
    {
        sb.AppendLine(
            $"\"{relationship.Source.Name}\" --> \"{relationship.Target.Name}\" : {GetLabel(relationship)}");
    }

    public static string GetLabel(SqlRelationshipComponentRelationship relationship)
    {
        string label;
        if (relationship is {Read: true, Write: true})
        {
            label = "SQL(read, write)";
        }
        else if (relationship.Write)
        {
            label = "SQL(write)";
        }
        else
        {
            label = "SQL(read)";
        }

        return label;
    }
}