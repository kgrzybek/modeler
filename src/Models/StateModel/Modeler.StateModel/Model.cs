using System.Reflection;

namespace Modeler.StateModel;

public abstract class Model
{
    private readonly List<TransitionEvent> _events;
    
    private readonly List<StateMachine> _stateMachines;

    protected Model()
    {
        _events = new List<TransitionEvent>();
        _stateMachines = new List<StateMachine>();
        RegisterTransitionEvents();
        RegisterStateMachines();
    }
    
    public TransitionEvent GetEvent<T>() where T: TransitionEvent
    {
        var type = _events.OfType<T>().SingleOrDefault();
        
        if (type == null)
        {
            throw new Exception($"Type {typeof(T)} is not defined in the model");
        }

        return type;
    }
    
    public StateMachine GetStateMachine<T>() where T: StateMachine
    {
        var type = _stateMachines.OfType<T>().SingleOrDefault();
        
        if (type == null)
        {
            throw new Exception($"Type {typeof(T)} is not defined in the model");
        }

        return type;
    }

    public void AddStateMachine(StateMachine stateMachine)
    {
        _stateMachines.Add(stateMachine);
    }
    
    // private void RegisterStates()
    // {
    //     var assembly = Assembly.GetAssembly(this.GetType());
    //     var types = assembly!
    //         .GetTypes()
    //         .Where(t =>
    //             typeof(State).IsAssignableFrom(t))
    //         .ToList();
    //     
    //     foreach (var type in types)
    //     {
    //         var staticMethod = type.GetMethod("Create", BindingFlags.Static | BindingFlags.Public);
    //
    //         if (staticMethod != null)
    //         {
    //             var entity = staticMethod.Invoke(null, null);
    //             _states.Add((State) entity!);
    //         }
    //     }
    // }
    
    private void RegisterTransitionEvents()
    {
        var assembly = Assembly.GetAssembly(this.GetType());
        var types = assembly!
            .GetTypes()
            .Where(t =>
                typeof(TransitionEvent).IsAssignableFrom(t))
            .ToList();
        
        foreach (var type in types)
        {
            var staticMethod = type.GetMethod("Create", BindingFlags.Static | BindingFlags.Public);

            if (staticMethod != null)
            {
                var entity = staticMethod.Invoke(null, null);
                _events.Add((TransitionEvent) entity!);
            }
        }
    }
    
    private void RegisterStateMachines()
    {
        var assembly = Assembly.GetAssembly(this.GetType());
        
        var types = assembly!
            .GetTypes()
            .Where(t =>
                typeof(StateMachine).IsAssignableFrom(t))
            .ToList();
        
        foreach (var type in types)
        {
            var staticMethod = type.GetMethod("Create", BindingFlags.Static | BindingFlags.Public);

            if (staticMethod != null)
            {
                var stateMachine = staticMethod.Invoke(null, new object?[]{ this }) as StateMachine;
                _stateMachines.Add(stateMachine!);
            }
        }
    }
}