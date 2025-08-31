using Modeler.DataModel.PostgreSQL.Views.Shared;
using Modeler.Full.Sample.Data.Structure.Schemas;

namespace Modeler.Full.Sample.Data.Views.SchemaDetails;

public class OrganizationsSchemaDetailsView : DataModelSchemaDetailsView
{
    public OrganizationsSchemaDetailsView(DataModel.DataModel model)
    {
        Schema = model.GetSchema<OrganizationSchema>();
    }
}