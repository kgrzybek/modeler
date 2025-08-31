using Modeler.Models.Common;
using Modeler.Models.Common.Elements;
using Modeler.Models.Data.Schemas;

namespace Modeler.Samples.HR.Data.Structure.Schemas;

public class OrganizationSchema : Schema
{
    public OrganizationSchema()
    {
        Name = "organizations";
        Id = ElementIdGenerator.GenerateElementId(GetType(), Name);
    }
}