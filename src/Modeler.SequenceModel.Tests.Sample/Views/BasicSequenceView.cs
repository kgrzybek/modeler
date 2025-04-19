using Modeler.SequenceModel.Tests.Sample.Sequences;
using Modeler.SequenceModel.Views.PlantUml;

namespace Modeler.SequenceModel.Tests.Sample.Views;

public class BasicSequenceView : SequenceDiagramViewDefinition
{
    public const string Id = "BasicSequence";
    
    public static SequenceDiagramView Create(SequencesModel model)
    {
        var view = new SequenceDiagramView(Id, model.GetSequence<BasicSequence>());

        return view;
    }
}