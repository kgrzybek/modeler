using Modeler.Views.Common;
using Modeler.Views.Common.Outputs;

namespace Modeler.Samples.HR.Sequences.Views.Outputs;

public class PlantUmlSequenceDiagramsViewFileSystemViewsOutput : FileSystemMultipleViewsOutput
{
    public PlantUmlSequenceDiagramsViewFileSystemViewsOutput(string absoluteDirectoryPath, ViewsRegistry viewsRegistry) : base(absoluteDirectoryPath)
    {
        RelativePaths.Add(viewsRegistry.GetElement<BasicSequenceView>(), "BasicSequence_full.puml");
        RelativePaths.Add(viewsRegistry.GetElement<BasicSequencePartView>(), "BasicSequencePart_full.puml");
    }
}