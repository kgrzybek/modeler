# State Machine

## Example

See full example [here](../../../src/Samples/State/Modeler.StateModel.Sample).

## Design

### Events

Events are defined by inheriting from `TransitionEvent`:

```csharp
public class SentToDecisionEvent : TransitionEvent
{
    public static SentToDecisionEvent Create() => new SentToDecisionEvent();

    private SentToDecisionEvent() : base("Sent To Decision")
    {
    }
}
```

### States

States are defined by inheriting from `State`:

```csharp
public class RegisteredState : State
{
    public RegisteredState() : base("Registered")
    {
    }
}
```

### State machine

A state machine organizes states and transitions:

```csharp
public class AbsenceStateMachine : StateMachine
{
    public static StateMachine Create(HRStateModel model)
    {
        var stateMachine = new AbsenceStateMachine();
        var registeredState = new RegisteredState();
        var toDecideState = new ToDecideState();
        var needsClarificationState = new NeedsClarificationState();
        var acceptedState = new AcceptedState();
        var rejectedState = new RejectedState();

        var sentToDecisionEvent = model.GetEvent<SentToDecisionEvent>();
        var acceptedEvent = model.GetEvent<AcceptedEvent>();
        var rejectedEvent = model.GetEvent<RejectedEvent>();
        var answeredEvent = model.GetEvent<ClarificationRequestedEvent>();

        stateMachine.StartFrom(registeredState);
        stateMachine.AddTransition(registeredState, sentToDecisionEvent, toDecideState);
        stateMachine.AddTransition(toDecideState, answeredEvent, needsClarificationState);
        stateMachine.AddTransition(needsClarificationState, sentToDecisionEvent, toDecideState);
        stateMachine.AddTransition(toDecideState, acceptedEvent, acceptedState);
        stateMachine.AddTransition(toDecideState, rejectedEvent, rejectedState);
        stateMachine.SetAsEnd(acceptedState);
        stateMachine.SetAsEnd(rejectedState);

        return stateMachine;
    }
}
```

## Views

### PlantUML

#### State machine diagram

Use `StateMachineViewDefinition` to generate a PlantUML diagram:

```csharp
public class AbsenceStateMachinePlantUmlViewDefinition : StateMachineViewDefinition
{
    public const string Id = "AbsenceStateMachine";

    public static StateMachineView Create(HRStateModel model)
    {
        var view = new StateMachineView(
            Id,
            model.GetStateMachine<StateMachine>());

        return view;
    }
}
```

Output: [PlantUML diagram](AbsenceStateMachine.puml)

### AsciiDoc

Generate a transitions table using `StateMachineAsciiDocTableViewDefinition`.

### Markdown

Generate the same table in Markdown using `StateMachineMarkdownTableViewDefinition`.
