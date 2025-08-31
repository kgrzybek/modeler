using Modeler.ConceptualModel;
using Modeler.Full.Sample.Conceptual.Concepts.Entities;
using Modeler.Views.Conceptual.ConceptDetails.AsciiDoc;

namespace Modeler.Full.Sample.Conceptual.Views.ConceptDetails.AsciiDoc;

public class EmployeeAsciiDocView : AsciiDocConceptDetailsView
{
    public EmployeeAsciiDocView(Model model) : base(model.GetEntity<Employee>())
    {
    }
}