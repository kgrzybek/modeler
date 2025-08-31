using Modeler.Models.Data;
using Modeler.Samples.HR.Data.Structure.Schemas;
using Modeler.Views.Data.Shared;

namespace Modeler.Samples.HR.Data.Views.SchemaDetails;

public class OrganizationsSchemaDetailsView : DataModelSchemaDetailsView
{
    public OrganizationsSchemaDetailsView(DataModel model)
    {
        Schema = model.GetSchema<OrganizationSchema>();
    }
}