using Modeler.ConceptualModel.Relationships;
using Modeler.ConceptualModel.Relationships.Associations.Builder;
using Modeler.ConceptualModel.Relationships.Associations.Multiplicity;
using Modeler.ConceptualModel.Sample.Concepts.Entities;

namespace Modeler.ConceptualModel.Sample.Concepts;

public class OrganizationStructureRelationshipsModel : RelationshipsModel
{
    public static void Create(OrganizationStructureConceptualModel model)
    {
        var employee = model.GetEntity<Employee>();
        var manager = model.GetEntity<Manager>();
        var organizationUnit = model.GetEntity<OrganizationUnit>();

        model.AddAssociation(
            AssociationBuilder
                .Where(employee, "works_in", new One(), organizationUnit)
                .AndInOpposite("hires", new ZeroOrMany()));
        
        model.AddGeneralization(employee, manager);
        
        model.AddAssociation(
            AssociationBuilder
                .Where(manager, "manages", new One(), organizationUnit)
                .AndInOpposite("is_managed_by", new One()));
    }
}