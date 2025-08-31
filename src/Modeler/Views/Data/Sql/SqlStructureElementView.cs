using Modeler.DataModel.Structure;
using Models.Elements;

namespace Modeler.DataModel.PostgreSQL.Views.SQL.Generator;

public abstract class SqlStructureElementView : IView
{
    protected SqlStructureElementView(StructureElement element)
    {
        Element = element;
    }

    public StructureElement Element { get; }
}