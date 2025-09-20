using Modeler.Models.Common.Elements;
using Modeler.Models.Data.Schemas;

namespace Modeler.Samples.HR.Components.System.Database.Structure.Schemas;

public class OrganizationSchema : Schema
{
    public OrganizationSchema()
    {
        Name = "organizations";
        Id = ElementIdGenerator.GenerateElementId(GetType(), Name);
    }
}