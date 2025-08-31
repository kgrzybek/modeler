using Modeler.Views.Common;
using Modeler.Views.Common.Outputs;

namespace Modeler.Samples.HR.Sequences.Views.Outputs;

public class MermaidSequenceDiagramsViewFileSystemViewsOutput : FileSystemMultipleViewsOutput
{
    public MermaidSequenceDiagramsViewFileSystemViewsOutput(string absoluteDirectoryPath, ViewsRegistry viewsRegistry) : base(absoluteDirectoryPath)
    {
        RelativePaths.Add(viewsRegistry.GetElement<BasicSequenceView>(), "BasicSequence_full.mmd");
        RelativePaths.Add(viewsRegistry.GetElement<BasicSequencePartView>(), "BasicSequencePart_full.mmd");
    }
}