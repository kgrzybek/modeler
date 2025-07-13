namespace Modeler.SequenceModel.Sample.Models.Parameters;

public class StringMessageParameter : MessageParameters
{
    public StringMessageParameter(string name)
    {
        Name = name;
    }

    public string Name { get; }
}