using Modeler.ComponentsModel.Sample;
using Modeler.ComponentsModel.Sample.Components;
using Modeler.ComponentsModel.Sample.Components.HRSystem.Backend;
using Modeler.ComponentsModel.Sample.Components.HRSystem.Backend.Modules;

namespace Modeler.ComponentsModel.Tests.UnitTests;

public class Tests
{
    [Test]
    public void Test1()
    {
        var model = SystemComponentsModel.GetInstance();
        var module = model.GetComponent<HRBackendDomainModule>();
        var backend = model.GetComponent<HRBackendApplication>();
    }
}