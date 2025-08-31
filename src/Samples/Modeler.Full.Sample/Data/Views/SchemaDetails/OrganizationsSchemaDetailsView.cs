using Modeler.Full.Sample.Data.Structure.Schemas;
using Modeler.Views.Data.Shared;

namespace Modeler.Full.Sample.Data.Views.SchemaDetails;

public class OrganizationsSchemaDetailsView : DataModelSchemaDetailsView
{
    public OrganizationsSchemaDetailsView(DataModel.DataModel model)
    {
        Schema = model.GetSchema<OrganizationSchema>();
    }
}