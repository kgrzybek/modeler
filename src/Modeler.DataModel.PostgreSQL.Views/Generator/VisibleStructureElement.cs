using Modeler.DataModel.Structure;

namespace Modeler.DataModel.PostgreSQL.Views.Generator;

public class VisibleStructureElement
{
    public VisibleStructureElement(StructureElement element, bool showColumns = true)
    {
        Element = element;
        ShowColumns = showColumns;
    }

    public StructureElement Element { get; }
    
    public bool ShowColumns { get; }
}