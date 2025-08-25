namespace Modeler.ComponentsModel.Views.PlantUml;

public interface IComponentsDiagramViewLayout
{
    public string GetComponentTypeColor(ComponentType componentType);
    
    public int IndentSize { get; }
}