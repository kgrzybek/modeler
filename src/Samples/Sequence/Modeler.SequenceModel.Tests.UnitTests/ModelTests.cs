using FluentAssertions;
using Modeler.SequenceModel.Sample.Models;

namespace Modeler.SequenceModel.Tests.UnitTests;

public class ModelTests
{
    [Test]
    public void Test()
    {
        var model = new HRSequencesModel();

        var sequences = model.GetSequences();
        var participants = model.GetParticipants();

        sequences.Should().HaveCount(1);
        participants.Should().HaveCount(4);
        
        var sequence = sequences[0];
        sequence.Name.Should().Be("Basic");

        var sequenceParticipants = sequence.GetParticipants();
        sequenceParticipants.Should().HaveCount(3);
    }
}