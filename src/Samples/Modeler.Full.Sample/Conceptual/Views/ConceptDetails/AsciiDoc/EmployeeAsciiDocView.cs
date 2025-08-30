using Modeler.ConceptualModel;
using Modeler.ConceptualModel.Views.AsciiDoc.ConceptDetails;
using Modeler.Full.Sample.Conceptual.Concepts.Entities;

namespace Modeler.Full.Sample.Conceptual.Views.ConceptDetails.AsciiDoc;

public class EmployeeAsciiDocView : AsciiDocConceptDetailsView
{
    public EmployeeAsciiDocView(Model model) : base(model.GetEntity<Employee>())
    {
    }
}