namespace Modeler.StateModel.Tests.Sample;

public class AnsweredEvent : TransitionEvent
{
    public static AnsweredEvent Create() => new AnsweredEvent();

    public AnsweredEvent() : base("Answered")
    {
    }
}