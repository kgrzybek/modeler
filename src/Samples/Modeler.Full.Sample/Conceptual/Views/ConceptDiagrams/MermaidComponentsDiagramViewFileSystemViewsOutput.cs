using Modeler.Views.Common;

namespace Modeler.Full.Sample.Conceptual.Views.ConceptDiagrams;

public class MermaidConceptDiagramViewFileSystemViewsOutput : FileSystemMultipleViewsOutput
{
    public MermaidConceptDiagramViewFileSystemViewsOutput(string absoluteDirectoryPath, ViewsRegistry viewsRegistry) : base(absoluteDirectoryPath)
    {
        RelativePaths.Add(viewsRegistry.GetElement<OrganizationStructureConceptsView>(), "OrganizationStructure.mmd");
    }
}