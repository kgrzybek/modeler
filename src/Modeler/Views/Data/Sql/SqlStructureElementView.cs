using Modeler.Models.Common;
using Modeler.Models.Data.Structure;
using Modeler.Views.Common;

namespace Modeler.Views.Data.Sql;

public abstract class SqlStructureElementView : IView
{
    protected SqlStructureElementView(StructureElement element)
    {
        Element = element;
    }

    public StructureElement Element { get; }
}