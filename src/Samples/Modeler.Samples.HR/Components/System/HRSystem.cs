using Modeler.Models.Components;
using Modeler.Samples.HR.Components.Types;

namespace Modeler.Samples.HR.Components.System;

public class HRSystem : Component
{
    public HRSystem() : base("HR System", new SystemComponentType())
    {
    }
}