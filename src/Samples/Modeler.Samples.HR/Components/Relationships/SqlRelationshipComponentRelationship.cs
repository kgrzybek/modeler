using Modeler.Models.Components;
using Modeler.Models.Components.Relationships;

namespace Modeler.Samples.HR.Components.Relationships;

public class SqlRelationshipComponentRelationship : ComponentRelationship
{
    public SqlRelationshipComponentRelationship(IComponent source, IComponent target, bool write, bool read) : base(source, target)
    {
        Write = write;
        Read = read;
    }
    
    public bool Write { get; }
    
    public bool Read { get; }
}