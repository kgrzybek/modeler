using Modeler.ComponentsModel;
using Modeler.Full.Sample.Components.Types;
using Models.Elements;

namespace Modeler.Full.Sample.Components.System;

public class HRSystemBoundary : Component
{
    public static IElement Create()
    {
        return new HRSystemBoundary();
    }
    private HRSystemBoundary() : base("HR System", new BoundaryComponentType())
    {
    }
}