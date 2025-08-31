using Modeler.Models.Common;
using Modeler.Models.Common.Elements;
using Modeler.Samples.HR.Apis;
using Modeler.Samples.HR.Components;
using Modeler.Samples.HR.Conceptual.Concepts;
using Modeler.Samples.HR.Data;
using Modeler.Samples.HR.EventsFlow;
using Modeler.Samples.HR.Messaging;
using Modeler.Samples.HR.Sequences;
using Modeler.Samples.HR.State;

namespace Modeler.Samples.HR;

public class ElementsRegistry : ModelElementsRegistry
{
    public void RegisterElements()
    {
        this.RegisterHRApiElements();
        this.RegisterComponents();
        this.RegisterMessagingElements();
        this.RegisterSequences();
        this.RegisterConcepts();
        this.RegisterDataModelElements();
        this.RegisterStateMachineElements();
        this.RegisterEventsFlowElements();
    }
}