using Modeler.Models.Common.Elements;
using Modeler.Models.Data;
using Modeler.Models.Sequence.Participants;
using Modeler.Samples.HR.Components.System.Database.Structure;
using Modeler.Samples.HR.Components.Types;

namespace Modeler.Samples.HR.Components.System.Database;

public class HRDatabaseComponent : DatabaseComponent, ISequenceParticipant
{
    public HRDatabaseComponent(ModelElementsRegistry elementsRegistry) 
        : base(elementsRegistry,"HR Database", new DatabaseComponentType())
    {
        OrganizationsDataModel.Create(this);
        ParticipantType = new Sequences.ParticipantTypes.Database();
    }

    public ParticipantType ParticipantType { get; }
}