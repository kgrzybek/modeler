using Modeler.DataModel.PostgreSQL.Views.SQL;
using Modeler.DataModel.PostgreSQL.Views.SQL.Generator;

namespace Modeler.DataModel.Sample.Views.Outputs;

public class FileSystemOutput : IViewsOutput
{
    private readonly string _path;

    public FileSystemOutput(string path)
    {
        _path = path;
    }

    public void Execute(List<StructureItemViewItem> views)
    {
        if (!Directory.Exists(_path))
        {
            Directory.CreateDirectory(_path);
        }
        
        foreach (var view in views)
        {
            var destination = Path.Combine(_path, $"{view.StructureName}.sql");
            File.WriteAllText(destination, view.Content); 
        }
    }
}