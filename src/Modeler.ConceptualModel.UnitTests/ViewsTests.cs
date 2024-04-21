using System.Reflection;
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
        var viewsFactory = new PlantUmlModelViewsFactory(
            model,
            Assembly.GetAssembly(typeof(OrganizationStructureView))!);

        var dictionary = new MultiplicityTranslator();
        dictionary.AddTranslation(new One(), "1");
        dictionary.AddTranslation(new ZeroOrMany(), "0..*");
        
        PlantUmlGenerator.Generate(
            AppDomain.CurrentDomain.BaseDirectory, 
            model, 
            4, 
            viewsFactory.GetViews(),
            dictionary);
    }
}