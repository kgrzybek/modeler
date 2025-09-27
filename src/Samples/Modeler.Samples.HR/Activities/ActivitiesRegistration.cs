using Modeler.Samples.HR.Activities.Flows;

namespace Modeler.Samples.HR.Activities;

internal static class ActivitiesRegistration
{
    internal static void RegisterActivityFlows(this ElementsRegistry elementsRegistry)
    {
        elementsRegistry.AddElement(EmployeeOnboardingActivityFlow.Create());
    }
}
