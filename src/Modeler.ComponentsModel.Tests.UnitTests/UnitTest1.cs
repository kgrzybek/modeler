using Modeler.ComponentsModel.Tests.Sample;

namespace Modeler.ComponentsModel.Tests.UnitTests;

public class Tests
{
    [Test]
    public void Test1()
    {
        var model = SystemComponentsModel.GetInstance();
        var module = model.GetComponent<ModuleComponent>();
        var backend = model.GetComponent<BackendComponent>();
    }
}