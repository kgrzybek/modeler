using Modeler.Samples.HR.Activities.Views.ActivityDiagrams;
using Modeler.Views.Common.Outputs;

namespace Modeler.Samples.HR.Activities.Views.ActivityDiagrams.PlantUml;

public class PlantUmlActivityDiagramsViewFileSystemViewsOutput : FileSystemMultipleViewsOutput
{
    public PlantUmlActivityDiagramsViewFileSystemViewsOutput(string absoluteDirectoryPath, ViewsRegistry viewsRegistry)
        : base(absoluteDirectoryPath)
    {
        RelativePaths.Add(
            viewsRegistry.GetElement<EmployeeOnboardingActivityDiagramView>(),
            "EmployeeOnboardingActivity.puml");
    }
}
