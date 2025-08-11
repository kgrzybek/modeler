using Models.Elements;

namespace Modeler.EventsFlowModel;

public abstract class Model : IModel
{
    private readonly List<Command> _commands;

    private readonly List<Event> _events;
    
    protected Model(ModelElementsRegistry elementsRegistry)
    {
        _events = elementsRegistry.GetElements<Event>();
        _commands = elementsRegistry.GetElements<Command>();
    }

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
}