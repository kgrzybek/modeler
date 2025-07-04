using System.Text;

namespace Modeler.EventsFlowModel.Views.AsciiDoc;

public class AsciiDocEventsFlowViewGenerator
{
    private readonly IAsciiDocEventsFlowViewsOutput<AsciiDocEventFlowsView> _viewsOutput;

    public AsciiDocEventsFlowViewGenerator(IAsciiDocEventsFlowViewsOutput<AsciiDocEventFlowsView> viewsOutput)
    {
        _viewsOutput = viewsOutput;
    }

    public void Generate(List<AsciiDocEventFlowsView> views)
    {
        var outputItems = new List<AsciiDocEventsFlowViewsOutputItem<AsciiDocEventFlowsView>>();
        foreach (var view in views)
        {
            var content = Generate(view);
            outputItems.Add(new AsciiDocEventsFlowViewsOutputItem<AsciiDocEventFlowsView>(view.Id, view, content));
        }

        _viewsOutput.Execute(outputItems);
    }

    private string Generate(AsciiDocEventFlowsView view)
    {
        var sb = new StringBuilder();
        sb.AppendLine("// Generated by Modeler - do not change.");
        sb.AppendLine("|===");
        sb.AppendLine("|Item|Triggered by|Triggers");
        sb.AppendLine();

        var model = view.Model;

        foreach (var command in model.GetCommands())
        {
            var triggeredBy = string.Join("<br>", model.GetEvents()
                .Where(e => e.CommandTriggers.Any(ct => ct.Command == command))
                .Select(e => $"Event {e.Name}"));

            var triggers = string.Join("<br>", command.EventTriggers.Select(et => $"Event {et.Event.Name}"));

            sb.AppendLine($"|Command {command.Name}");
            sb.AppendLine($"|{triggeredBy}");
            sb.AppendLine($"|{triggers}");
            sb.AppendLine();
        }

        foreach (var @event in model.GetEvents())
        {
            var triggeredBy = string.Join("<br>", model.GetCommands()
                .Where(c => c.EventTriggers.Any(et => et.Event == @event))
                .Select(c => $"Command {c.Name}"));

            var triggers = string.Join("<br>", @event.CommandTriggers.Select(ct => $"Command {ct.Command.Name}"));

            sb.AppendLine($"|Event {@event.Name}");
            sb.AppendLine($"|{triggeredBy}");
            sb.AppendLine($"|{triggers}");
            sb.AppendLine();
        }

        sb.AppendLine("|===");

        return sb.ToString();
    }
}
