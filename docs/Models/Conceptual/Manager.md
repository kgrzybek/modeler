<!-- Generated by Modeler - do not change. -->
### Attributes - Manager
|Name|Type|Is required|
|---|---|---|
|(Employee) FirstName|Text|Yes|
|(Employee) Gender|Gender|Yes|
|(Employee) LastName|Text|Yes|
|(Employee) ResidentialAddress|Address|Yes|
|ManagesFromDate|Date|Yes|

### Relations - Manager
|From|Name|Multiplicity|To|Description|
|---|---|---|---|---|
|(Employee) Employee|works_in|1|*Organization_Unit*|
|*(Employee) Organization_Unit*|hires|0..*|Employee|
|Manager|manages|1|*Organization_Unit*|
|*Organization_Unit*|is_managed_by|1|Manager|

