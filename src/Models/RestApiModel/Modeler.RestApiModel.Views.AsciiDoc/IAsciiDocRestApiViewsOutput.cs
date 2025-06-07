namespace Modeler.RestApiModel.Views.AsciiDoc;

public interface IAsciiDocRestApiViewsOutput<T>
{
    void Execute(List<AsciiDocRestApiViewsOutputItem<T>> views);
}

public record AsciiDocRestApiViewsOutputItem<T>(string Id, T View, string Content);
