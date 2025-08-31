using Modeler.Models.Common;
using Modeler.Models.Common.Elements;
using Modeler.Models.Components;
using Modeler.Samples.HR.Components.Types;

namespace Modeler.Samples.HR.Components.System;

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