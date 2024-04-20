using FluentAssertions;
using Modeler.ConceptualModel.Sample.TestModel;
using Modeler.ConceptualModel.Sample.TestViews;
using Modeler.ConceptualModel.Views.PlantUml.PlantUml;
using Modeler.Relationships.Associations.Multiplicity;

namespace Modeler.ConceptualModel.UnitTests;

public class ViewsTests
{
    [Test]
    public void Test()
    {
        var model = OrganizationStructureConceptualModel.GetInstance();
        var views = OrganizationStructurePlantUmlModelViewsFactory.GetInstance();

        var dictionary = new MultiplicityTranslator();
        dictionary.AddTranslation(new One(), "1");
        dictionary.AddTranslation(new ZeroOrMany(), "0..*");
        
        PlantUmlGenerator.Generate(
            AppDomain.CurrentDomain.BaseDirectory, 
            model, 
            4, 
            views.Views,
            dictionary);
    }
}