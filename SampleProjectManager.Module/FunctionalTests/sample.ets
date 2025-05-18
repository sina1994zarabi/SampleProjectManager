;#DropDB SampleProjectManagerEasyTest

#Application SampleProjectManager.Win
#Application SampleProjectManager.Web
#IfDef SampleProjectManager.Win

*Action About...
 
*Action OK

#EndIf

#IfDef SampleProjectManager.Web
!Action Navigation(My Details)
#EndIf
