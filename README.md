# qccl.qmsservice

## QlikView task automation 
The qccl.qmsservice is a REST WebService that serves as wrapper for the QlikView Server QMS API interface. In addition to the web service itself, a QlikView function library is provided to make it easier to call the service functions. 
For example, a task can be started or stopped from a normal QlikView script.

The aim of the project is to keep the operation of a QlikView environment as autonomous as possible. QlikView can monitor the data of the source systems independently and start loading processes when needed without being dependent on triggers from the source systems.

Inspired by [Rikard Braathen's](https://github.com/braathen) [qv-edx-trigger](https://github.com/braathen/qv-edx-trigger), a REST based advanced tool has been developed.


### functional scope 
All functions are located in the namespace "qccl.qmsapi" and can be called directly in a QlikView script with the listed parameters. The result is always a table with a column containing the return value.

| Function | Description |
|--------|--------|
|**GetAllServers**|get all available server instances for this cluster.  |
|**GetDSCServers**|get all available directory DSC instances for this cluster.|
|**GetQDSServers**|get all available QDS instances for this cluster.|
|**GetQMSServers**|get all available QMS instances for this cluster.|
|**GetQVSServers**|get all available QVS instances for this cluster.|
|**GetQWSServers**|get all available QWS instances for this cluster.|
|**GetRMSServers**|get all available RMS instances for this cluster.|
|**GetCategories**|get all available categories for this cluster.|
|**CountRunningTasks**|count all currently running tasks on this cluster.|
|**CountRunningTasksByCategory**|count all currently running tasks for a specific category.|
|**GetRunningTasks**|get all currently running tasks on this cluster.|
|**GetRunningTasksByCategory**|count all currently running tasks on a specific qds node of this cluster.|
|**TaskStatus**|get the current status of a specific Task.|
|**StartTask**|start a specific Task.|
|**AbortTask**|abort a specific Task.|
|**GetAllSourceDocumentsByQds**|get all mounted sourcedocuments on a specific qds node of this cluster.|
|**GetAllTasks**|get all tasks of this cluster.|
|**GetAllTasksByQds**|get all tasks on a specific qds node of this cluster.|
|**GetTaskByID**|get a task by its id.|
|**GetTriggersByTask**|get all triggers by taskname.|
|**SendMail**|send a mail to a specific receipient.|

### Setup
Setup the compiled WebService as a new Web Application on your IIS.
Adjust the Web.Config File in order to reach your QMS Service:

QMS Binding:
```
<client>
      <endpoint address="http://localhost:4799/QMS/Service" binding="basicHttpBinding" bindingConfiguration="BasicHttpBinding_IQMS" contract="IQMSAPI.IQMS" name="BasicHttpBinding_IQMS" behaviorConfiguration="ServiceKeyEndpointBehavior" />
      <endpoint address="http://localhost:4799/ANY/Service" binding="basicHttpBinding" bindingConfiguration="BasicHttpBinding_IQTService" contract="IQMSAPI.IQTService" name="BasicHttpBinding_IQTService" behaviorConfiguration="ServiceKeyEndpointBehavior" />
</client>
```

Application Settings:
```
<applicationSettings>
    <qccl.qmsservice.Properties.Settings>
      <setting name="Password" serializeAs="String">
        <value>test</value>
      </setting>
      <setting name="SmtpHost" serializeAs="String">
        <value>groupsmtprelay.company.com</value>
      </setting>
      <setting name="SmtpPort" serializeAs="String">
        <value>25</value>
      </setting>
      <setting name="SmtpSender" serializeAs="String">
        <value>mail@service.com</value>
      </setting>
      <setting name="SmtpUseSSL" serializeAs="String">
        <value>False</value>
      </setting>
    </qccl.qmsservice.Properties.Settings>
  </applicationSettings>
```


