namespace Modeler.SequenceModel.Tests.Sample.ParticipantTypes;

public class Actor : ParticipantType
{
    public static Actor Create() => new Actor();
}

public class Database : ParticipantType
{
    public static Database Create() => new Database();
}