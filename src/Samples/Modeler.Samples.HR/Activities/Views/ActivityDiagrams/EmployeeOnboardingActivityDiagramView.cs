using Modeler.Samples.HR.Activities;
using Modeler.Samples.HR.Activities.Flows;
using Modeler.Views.Activity.Diagram.Shared;

namespace Modeler.Samples.HR.Activities.Views.ActivityDiagrams;

public class EmployeeOnboardingActivityDiagramView : ActivityDiagramView
{
    public EmployeeOnboardingActivityDiagramView(HRActivitiesModel model)
        : base(model.GetFlow<EmployeeOnboardingActivityFlow>())
    {
    }
}
