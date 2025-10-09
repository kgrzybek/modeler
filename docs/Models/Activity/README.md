# Activity

The Activity model describes workflows built from activity blocks and decision points, similar to UML activity diagrams. A flow is represented by an `ActivityFlow` composed of sequential `ActivityAction` blocks and branching `ActivityDecision` nodes.

## Example

A runnable example is available in the sample project at [`src/Samples/Modeler.Samples.HR/Activities`](../../../src/Samples/Modeler.Samples.HR/Activities). The `EmployeeOnboardingActivityFlow` demonstrates a realistic onboarding process with a verification decision and a remediation loop.

## Metamodel

The metamodel consists of the following core concepts:

* `ActivityFlow` – the aggregate that stores the flow name, start node, actions, decisions and transitions.
* `ActivityAction` – a single activity block that optionally connects to the next node in the flow.
* `ActivityDecision` – a branching node with two or more named branches represented by `ActivityDecisionBranch` instances.
* `ActivityTransition` – a read-only projection generated from the model, used by the views to create diagram edges.

The relationships between the elements are captured in [Activity_meta_model.puml](Activity_meta_model.puml).

## Designing a flow

The `ActivityFlowBuilder<T>` helper simplifies creating flows. Actions and decisions are added to the builder and then linked together:

```csharp
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
```

`Connect` creates sequential transitions, while `AddBranch` describes named decision branches. `ConnectToEnd` marks actions that finish the flow.

## Views

The PlantUML activity diagram generator translates any `ActivityDiagramView` into a diagram built from the model transitions. To define a view, inherit from `ActivityDiagramView` and select the flow you want to present:

```csharp
public class EmployeeOnboardingActivityDiagramView : ActivityDiagramView
{
    public EmployeeOnboardingActivityDiagramView(HRActivitiesModel model)
        : base(model.GetFlow<EmployeeOnboardingActivityFlow>())
    {
    }
}
```

The sample CLI generates the PlantUML diagram in `example-doc/Models/Activities/EmployeeOnboardingActivity.puml`.
