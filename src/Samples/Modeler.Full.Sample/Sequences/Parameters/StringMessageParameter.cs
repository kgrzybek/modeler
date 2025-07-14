using Modeler.SequenceModel;

namespace Modeler.Full.Sample.Sequences.Parameters;

public class StringMessageParameter : MessageParameters
{
    public StringMessageParameter(string name)
    {
        Name = name;
    }

    public string Name { get; }
}