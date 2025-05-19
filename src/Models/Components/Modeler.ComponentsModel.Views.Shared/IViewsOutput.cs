namespace Modeler.ComponentsModel.Views.Shared;

public interface IViewsOutput<T>
{
    public void Execute(List<ViewOutputItem<T>> views);
}

public record ViewOutputItem<T>(string Id, T View, string Content);