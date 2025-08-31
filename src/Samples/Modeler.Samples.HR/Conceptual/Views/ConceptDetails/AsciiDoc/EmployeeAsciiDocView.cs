using Modeler.Models.Conceptual;
using Modeler.Samples.HR.Conceptual.Concepts.Entities;
using Modeler.Views.Conceptual.ConceptDetails.AsciiDoc;

namespace Modeler.Samples.HR.Conceptual.Views.ConceptDetails.AsciiDoc;

public class EmployeeAsciiDocView : AsciiDocConceptDetailsView
{
    public EmployeeAsciiDocView(Model model) : base(model.GetEntity<Employee>())
    {
    }
}