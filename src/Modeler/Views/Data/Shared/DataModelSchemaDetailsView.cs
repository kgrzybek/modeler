using Modeler.Models.Common;
using Modeler.Models.Data.Schemas;
using Modeler.Views.Common;

namespace Modeler.Views.Data.Shared;

public abstract class DataModelSchemaDetailsView : IView
{
    public Schema Schema { get; protected init; } = null!;
}