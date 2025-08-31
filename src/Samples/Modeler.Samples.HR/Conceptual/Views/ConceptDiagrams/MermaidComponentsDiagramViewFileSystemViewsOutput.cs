using Modeler.Views.Common;
using Modeler.Views.Common.Outputs;

namespace Modeler.Samples.HR.Conceptual.Views.ConceptDiagrams;

public class MermaidConceptDiagramViewFileSystemViewsOutput : FileSystemMultipleViewsOutput
{
    public MermaidConceptDiagramViewFileSystemViewsOutput(string absoluteDirectoryPath, ViewsRegistry viewsRegistry) : base(absoluteDirectoryPath)
    {
        RelativePaths.Add(viewsRegistry.GetElement<OrganizationStructureConceptsView>(), "OrganizationStructure.mmd");
    }
}