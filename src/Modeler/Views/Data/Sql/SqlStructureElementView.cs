using Modeler.DataModel.Structure;
using Models.Elements;

namespace Modeler.Views.Data.Sql;

public abstract class SqlStructureElementView : IView
{
    protected SqlStructureElementView(StructureElement element)
    {
        Element = element;
    }

    public StructureElement Element { get; }
}