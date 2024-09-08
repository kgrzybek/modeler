using Modeler.DataModel.PostgreSQL.Views;
using Modeler.DataModel.PostgreSQL.Views.Generator;

namespace Modeler.DataModel.Tests.Sample;

public class FileSystemOutput : IViewsOutput
{
    private readonly string _path;

    public FileSystemOutput(string path)
    {
        _path = path;
    }

    public void Execute(List<StructureItemViewItem> views)
    {
        foreach (var view in views)
        {
            var destination = Path.Combine(_path, $"{view.StructureName}.sql");
            File.WriteAllText(destination, view.Content); 
        }
    }
}