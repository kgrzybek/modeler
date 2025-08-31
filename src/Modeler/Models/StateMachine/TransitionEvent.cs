using Modeler.Models.Common.Elements;

namespace Modeler.Models.StateMachine;

public abstract class TransitionEvent : IElement
{
    protected TransitionEvent(string name)
    {
        Name = name;
        Id = ElementIdGenerator.GenerateElementId(GetType(), name);
    }

    public string Name { get; }
    public string Id { get; }
}