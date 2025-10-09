using Modeler.Models.Activity;

namespace Modeler.Samples.HR.Activities.Flows;

public class EmployeeOnboardingActivityFlow : ActivityFlow
{
    public static EmployeeOnboardingActivityFlow Create()
    {
        var builder = new ActivityFlowBuilder<EmployeeOnboardingActivityFlow>("Employee Onboarding");

        var collectDocuments = builder.AddAction("Collect employee documents");
        var verifyData = builder.AddAction("Verify submitted data");
        var decision = builder.AddDecision("Documents complete?");
        var requestMissing = builder.AddAction("Request missing information");
        var createAccount = builder.AddAction("Create system accounts");
        var scheduleTraining = builder.AddAction("Schedule onboarding training");

        builder.Connect(collectDocuments, verifyData);
        builder.Connect(verifyData, decision);

        builder.AddBranch(decision, "Yes", createAccount);
        builder.AddBranch(decision, "No", requestMissing);

        builder.Connect(requestMissing, collectDocuments);

        builder.Connect(createAccount, scheduleTraining);
        builder.ConnectToEnd(scheduleTraining);

        return builder.Build();
    }
}
