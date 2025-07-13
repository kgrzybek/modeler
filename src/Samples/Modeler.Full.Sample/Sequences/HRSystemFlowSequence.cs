using Modeler.Full.Sample.Components;
using Modeler.SequenceModel;
using Modeler.SequenceModel.Sample.Models.Parameters;

namespace Modeler.Full.Sample.Sequences;

public class HRSystemFlowSequence : Sequence
{
    public static void Create(HRSequencesModel model)
    {
        var backend = model.GetParticipant<BackendApplication>();
        var frontend = model.GetParticipant<HRFrontendApplication>();

        var builder = new SequenceBuilder<HRSystemFlowSequence>("HR System Flow Sequence");

        builder.AddSynchronousRequestMessage(backend, "addEmployee", new StringMessageParameter("SQL"), frontend);
        builder.AddSynchronousResponseMessage(frontend, "OK", new NoMessageParameters(), backend);

        var sequence = builder.Build();
        model.AddSequence(sequence);
    }
}