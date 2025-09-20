using Modeler.Models.Data;
using Modeler.Samples.HR.Components.System.Database.Structure.Schemas;
using Modeler.Views.Data.Shared;

namespace Modeler.Samples.HR.Components.System.Database.Views.SchemaDetails;

public class OrganizationsSchemaDetailsView : DataModelSchemaDetailsView
{
    public OrganizationsSchemaDetailsView(DatabaseComponent model)
    {
        Schema = model.GetSchema<OrganizationSchema>();
    }
}