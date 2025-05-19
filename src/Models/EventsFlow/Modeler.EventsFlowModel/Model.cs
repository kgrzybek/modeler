using System.Reflection;

namespace Modeler.EventsFlowModel;

public abstract class Model
{
    private List<Command> _commands;

    private List<Event> _events;
    
    public Command GetCommand<T>() where T: Command
    {
        var type = _commands.OfType<T>().SingleOrDefault();
        
        if (type == null)
        {
            throw new Exception($"Type {typeof(T)} is not defined in the model");
        }

        return type;
    }
    
    public Event GetEvent<T>() where T: Event
    {
        var type = _events.OfType<T>().SingleOrDefault();
        
        if (type == null)
        {
            throw new Exception($"Type {typeof(T)} is not defined in the model");
        }

        return type;
    }

    public List<Command> GetCommands()
    {
        return _commands.ToList();
    }
    
    public List<Event> GetEvents()
    {
        return _events.ToList();
    }
    
    private void InitializeFlowModels()
    {
        var assembly = Assembly.GetAssembly(this.GetType())!;
        var types = assembly
            .GetTypes()
            .Where(t =>
                typeof(FlowModel).IsAssignableFrom(t))
            .ToList();

        foreach (var type in types)
        {
            var staticMethod = type.GetMethod("Create", BindingFlags.Static | BindingFlags.Public);

            if (staticMethod != null)
            {
                staticMethod.Invoke(null, new object?[]{ this });
            }
        }
    }

    protected Model()
    {
        _events = new List<Event>();
        _commands = new List<Command>();
        
        RegisterEvents();
        RegisterCommands();
        InitializeFlowModels();
    }

    private void RegisterEvents()
    {
        var assembly = Assembly.GetAssembly(this.GetType());
        _events = new List<Event>();
        var types = assembly!
            .GetTypes()
            .Where(t =>
                typeof(Event).IsAssignableFrom(t))
            .ToList();
        
        foreach (var type in types)
        {
            var staticMethod = type.GetMethod("Create", BindingFlags.Static | BindingFlags.Public);

            if (staticMethod != null)
            {
                var entity = staticMethod.Invoke(null, null);
                _events.Add((Event) entity!);
            }
        }
    }
    
    private void RegisterCommands()
    {
        var assembly = Assembly.GetAssembly(this.GetType());
        _commands = new List<Command>();
        var types = assembly!
            .GetTypes()
            .Where(t =>
                typeof(Command).IsAssignableFrom(t))
            .ToList();
        
        foreach (var type in types)
        {
            var staticMethod = type.GetMethod("Create", BindingFlags.Static | BindingFlags.Public);

            if (staticMethod != null)
            {
                var entity = staticMethod.Invoke(null, null);
                _commands.Add((Command) entity!);
            }
        }
    }
}