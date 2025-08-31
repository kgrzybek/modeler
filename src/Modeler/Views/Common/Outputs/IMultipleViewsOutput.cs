namespace Modeler.Views.Common.Outputs;

public interface IMultipleViewsOutput
{
    public void Execute(List<ViewOutputItem> items);
}