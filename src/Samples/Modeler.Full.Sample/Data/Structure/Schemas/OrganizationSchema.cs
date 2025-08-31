using Modeler.DataModel.Schemas;
using Models.Elements;

namespace Modeler.Full.Sample.Data.Structure.Schemas;

public class OrganizationSchema : Schema
{
    public OrganizationSchema()
    {
        Name = "organizations";
        Id = ElementIdGenerator.GenerateElementId(GetType(), Name);
    }
}