using Modeler.Views.Common;

namespace Modeler.Full.Sample.Conceptual.Views.ConceptDiagrams;

public class PlantUmlConceptDiagramViewFileSystemViewsOutput : FileSystemMultipleViewsOutput
{
    public PlantUmlConceptDiagramViewFileSystemViewsOutput(string absoluteDirectoryPath, ViewsRegistry viewsRegistry) : base(absoluteDirectoryPath)
    {
        RelativePaths.Add(viewsRegistry.GetElement<OrganizationStructureConceptsView>(), "OrganizationStructure.puml");
    }
}