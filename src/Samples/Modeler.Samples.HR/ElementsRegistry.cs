using Modeler.Models.Common;
using Modeler.Models.Common.Elements;
using Modeler.Samples.HR.Components;
using Modeler.Samples.HR.Components.HRBroker;
using Modeler.Samples.HR.Components.System.Backend.Modules.Api;
using Modeler.Samples.HR.Components.System.Database;
using Modeler.Samples.HR.Conceptual.Concepts;
using Modeler.Samples.HR.EventsFlow;
using Modeler.Samples.HR.Sequences;
using Modeler.Samples.HR.State;

namespace Modeler.Samples.HR;

public class ElementsRegistry : ModelElementsRegistry
{
    public void RegisterElements()
    {
        this.RegisterHRApiElements();
        this.RegisterHRBrokerElements();
        this.RegisterHRDatabaseElements();
        this.RegisterComponents();
        this.RegisterSequences();
        this.RegisterConcepts();
        
        this.RegisterStateMachineElements();
        this.RegisterEventsFlowElements();
    }
}