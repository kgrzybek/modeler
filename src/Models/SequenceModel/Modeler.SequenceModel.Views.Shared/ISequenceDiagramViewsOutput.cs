namespace Modeler.SequenceModel.Views.Shared;

public interface ISequenceDiagramViewsOutput<T>
{
    public void Execute(List<SequenceDiagramViewOutputItem<T>> views);
}

public record SequenceDiagramViewOutputItem<T>(string Id, T View, string Content);