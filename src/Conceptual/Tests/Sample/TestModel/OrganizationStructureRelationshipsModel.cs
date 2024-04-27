using Modeler.ConceptualModel.Relationships;
using Modeler.ConceptualModel.Relationships.Associations.Builder;
using Modeler.ConceptualModel.Relationships.Associations.Multiplicity;

namespace Modeler.ConceptualModel.Sample.TestModel;

public class OrganizationStructureRelationshipsModel : RelationshipsModel
{
    public static void Create(OrganizationStructureConceptualModel model)
    {
        var person = model.GetEntity<Employee>();
        var manager = model.GetEntity<Manager>();
        var organizationUnit = model.GetEntity<OrganizationUnit>();

        model.AddAssociation(
            AssociationBuilder
                .Where(person, "works_in", new One(), organizationUnit)
                .AndInOpposite("hires", new ZeroOrMany()));
        
        model.AddGeneralization(person, manager);
        
        model.AddAssociation(
            AssociationBuilder
                .Where(manager, "manages", new One(), organizationUnit)
                .AndInOpposite("is_managed_by", new One()));
    }
}