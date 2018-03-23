# qccl.qmsservice

## QlikView task automation 
The qccl.qmsservice is a REST WebService that serves as wrapper for the QlikView Server QMS API interface. In addition to the web service itself, a QlikView function library is provided to make it easier to call the service functions. 
For example, a task can be started or stopped from a normal QlikView script.

The aim of the project is to keep the operation of a QlikView environment as autonomous as possible. QlikView can monitor the data of the source systems independently and start loading processes when needed without being dependent on triggers from the source systems.

Inspired by [Rikard Braathen's](https://github.com/braathen) [qv-edx-trigger](https://github.com/braathen/qv-edx-trigger), a REST based advanced tool has been developed.


### functional scope 
All functions are located in the namespace "qccl.qmsapi" and can be called directly in a QlikView script with the listed parameters. The result is always a table with a column containing the return value.

| Function | Description |
|:--------|:--------|
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

### Examples

#### Setup qccl.qmsservice
In order to execute a funtion you need to connect to the service.
All following examples are reusing the variable created in the setup snippet for the server connection.
```
// Setup the api
// ---------------------------------------------------------------------------------------------
// #CMT# global variables:
// ---------------------------------------------------------------------------------------------
LET vService = '$(v.ph.servername):$(v.ph.port)/qmsservice.asmx';
LET vServiceURL = 'http://$(vService)/qvs/qccl.qmsapi.qvs';
// ---------------------------------------------------------------------------------------------
// #CMT# Include the online qvs file to access the latest qmsapi
$(Must_Include=$(vServiceURL));
```

#### qccl.qmsapi.GetAllServers
Command to get all available server instances for this cluster.
> Parameter
1. p1 : "[server]:[port]"	servername and port of the current qccl.qmsservice
```
call qccl.qmsapi.GetAllServers('$(vService)');
if qccl.qmsapi.GetAllServers.Result.Error = 1 then
	// #CMT# Handle Error Message
	// qccl.qmsapi.GetAllServers.Result.Error
	// qccl.qmsapi.GetAllServers.Result.Error.Message
else
	// #CMT# Work with Result
end if;
```

#### qccl.qmsapi.GetDSCServers
Command to get all available directory DSC instances for this cluster.
> Parameter
1. p1 : "[server]:[port]"	servername and port of the current qccl.qmsservice
```
call qccl.qmsapi.GetDSCServers('$(vService)');
if qccl.qmsapi.GetDSCServers.Result.Error = 1 then
	// #CMT# Handle Error Message
	// qccl.qmsapi.GetDSCServers.Result.Error
	// qccl.qmsapi.GetDSCServers.Result.Error.Message
else
	// #CMT# Work with Result
end if;
```

#### qccl.qmsapi.GetQDSServers
Command to get all available QDS instances for this cluster.
> Parameter
1. p1 : "[server]:[port]"	servername and port of the current qccl.qmsservice
```
call qccl.qmsapi.GetQDSServers('$(vService)');
if qccl.qmsapi.GetQDSServers.Result.Error = 1 then
	// #CMT# Handle Error Message
	// qccl.qmsapi.GetQDSServers.Result.Error
	// qccl.qmsapi.GetQDSServers.Result.Error.Message
else
	// #CMT# Work with Result
end if;
```

#### qccl.qmsapi.GetQMSServers
Command to get all available QMS instances for this cluster.
> Parameter
1. p1 : "[server]:[port]"	servername and port of the current qccl.qmsservice
```
call qccl.qmsapi.GetQMSServers('$(vService)');
if qccl.qmsapi.GetQMSServers.Result.Error = 1 then
	// #CMT# Handle Error Message
	// qccl.qmsapi.GetQMSServers.Result.Error
	// qccl.qmsapi.GetQMSServers.Result.Error.Message
else
	// #CMT# Work with Result
end if;
```

#### qccl.qmsapi.GetQVSServers
Command to get all available QVS instances for this cluster.
> Parameter
1. p1 : "[server]:[port]"	servername and port of the current qccl.qmsservice
```
call qccl.qmsapi.GetQVSServers('$(vService)');
if qccl.qmsapi.GetQVSServers.Result.Error = 1 then
	// #CMT# Handle Error Message
	// qccl.qmsapi.GetQVSServers.Result.Error
	// qccl.qmsapi.GetQVSServers.Result.Error.Message
else
	// #CMT# Work with Result
end if;
```

#### qccl.qmsapi.GetQWSServers
Command to get all available QWS instances for this cluster.
> Parameter
1. p1 : "[server]:[port]"	servername and port of the current qccl.qmsservice
```
call qccl.qmsapi.GetQWSServers('$(vService)');
if qccl.qmsapi.GetQWSServers.Result.Error = 1 then
	// #CMT# Handle Error Message
	// qccl.qmsapi.GetQWSServers.Result.Error
	// qccl.qmsapi.GetQWSServers.Result.Error.Message
else
	// #CMT# Work with Result
end if;
```

#### qccl.qmsapi.GetRMSServers
Command to get all available RMS instances for this cluster.
> Parameter
1. p1 : "[server]:[port]"	servername and port of the current qccl.qmsservice
```
call qccl.qmsapi.GetRMSServers('$(vService)');
if qccl.qmsapi.GetRMSServers.Result.Error = 1 then
	// #CMT# Handle Error Message
	// qccl.qmsapi.GetRMSServers.Result.Error
	// qccl.qmsapi.GetRMSServers.Result.Error.Message
else
	// #CMT# Work with Result
end if;
```

#### qccl.qmsapi.GetCategories
Command to get all available categories for this cluster.
> Parameter
1. p1 : "[server]:[port]"	servername and port of the current qccl.qmsservice
```
call qccl.qmsapi.GetCategories('$(vService)');
if qccl.qmsapi.GetCategories.Result.Error = 1 then
	// #CMT# Handle Error Message
	// qccl.qmsapi.GetCategories.Result.Error
	// qccl.qmsapi.GetCategories.Result.Error.Message
else
	// #CMT# Work with Result
end if;
```

#### qccl.qmsapi.CountRunningTasks
Command to count all currently running tasks on this cluster
> Parameter
1. p1 : "[server]:[port]"	servername and port of the current qccl.qmsservice
```
call qccl.qmsapi.CountRunningTasks('$(vService)');
if qccl.qmsapi.CountRunningTasks.Result.Error = 1 then
	// #CMT# Handle Error Message
	// qccl.qmsapi.CountRunningTasks.Result.Error
	// qccl.qmsapi.CountRunningTasks.Result.Error.Message
else
	// #CMT# Work with Result
end if;
```

#### qccl.qmsapi.CountRunningTasksByCategory
Command to count all currently running tasks for a specific category
> Parameter
1. p1 : "[server]:[port]"	servername and port of the current qccl.qmsservice
2. p2 : "[category]" 		QDS category
```
LET vCurCategory = '$(v.ph.category)';
call qccl.qmsapi.CountRunningTasksByCategory('$(vService)', vCurCategory);
if qccl.qmsapi.CountRunningTasksByCategory.Result.Error = 1 then
	// #CMT# Handle Error Message
	// qccl.qmsapi.CountRunningTasksByCategory.Result.Error
	// qccl.qmsapi.CountRunningTasksByCategory.Result.Error.Message
else
	// #CMT# Work with Result
end if;
```

#### qccl.qmsapi.GetRunningTasks
Command to get all currently running tasks on this cluster
> Parameter
1. p1 : "[server]:[port]"	servername and port of the current qccl.qmsservice
```
call qccl.qmsapi.GetRunningTasks('$(vService)');
if qccl.qmsapi.GetRunningTasks.Result.Error = 1 then
	// #CMT# Handle Error Message
	// qccl.qmsapi.GetRunningTasks.Result.Error
	// qccl.qmsapi.GetRunningTasks.Result.Error.Message
else
	// #CMT# Work with Result
end if;
```

#### qccl.qmsapi.GetRunningTasksByCategory
Command to count all currently running tasks on a specific qds node of this cluster
> Parameter
1. p1 : "[server]:[port]"	servername and port of the current qccl.qmsservice
2. p2 : "[category]" 		QDS category
```
LET vCurCategory = '$(v.ph.category)';
call qccl.qmsapi.GetRunningTasksByCategory('$(vService)', vCurCategory);
if qccl.qmsapi.GetRunningTasksByCategory.Result.Error = 1 then
	// #CMT# Handle Error Message
	// qccl.qmsapi.GetRunningTasksByCategory.Result.Error
	// qccl.qmsapi.GetRunningTasksByCategory.Result.Error.Message
else
	// #CMT# Work with Result
end if;
```

#### qccl.qmsapi.TaskStatus
Command to get the current status of a specific Task
> Parameter
1. p1 : "[server]:[port]"	servername and port of the current qccl.qmsservice
2. p2 : "[taskname]" 		name of the specific task
```
LET vCurTask = '$(v.ph.taskname)';
call qccl.qmsapi.TaskStatus('$(vService)', vCurTask);
if qccl.qmsapi.TaskStatus.Result.Error = 1 then
	// #CMT# Handle Error Message
	// qccl.qmsapi.TaskStatus.Result.Error
	// qccl.qmsapi.TaskStatus.Result.Error.Message
else
	// #CMT# Work with Result
end if;
```

#### qccl.qmsapi.StartTask
Command to start a specific Task
> Parameter
1. p1 : "[server]:[port]"	servername and port of the current qccl.qmsservice
2. p2 : "[taskname]" 		name of the specific task
```
LET vCurTask = '$(v.ph.taskname)';
call qccl.qmsapi.StartTask('$(vService)', vCurTask);
if qccl.qmsapi.StartTask.Result.Error = 1 then
	// #CMT# Handle Error Message
	// qccl.qmsapi.StartTask.Result.Error
	// qccl.qmsapi.StartTask.Result.Error.Message
else
	// #CMT# Work with Result
end if;
```

#### qccl.qmsapi.AbortTask
Command to abort a specific Task
> Parameter
1. p1 : "[server]:[port]"	servername and port of the current qccl.qmsservice
2. p2 : "[taskname]" 		name of the specific task
```
LET vCurTask = '$(v.ph.taskname)';
call qccl.qmsapi.AbortTask('$(vService)', vCurTask);
if qccl.qmsapi.AbortTask.Result.Error = 1 then
	// #CMT# Handle Error Message
	// qccl.qmsapi.AbortTask.Result.Error
	// qccl.qmsapi.AbortTask.Result.Error.Message
else
	// #CMT# Work with Result
end if;
```

#### qccl.qmsapi.GetAllSourceDocumentsByQds
Command to get all mounted sourcedocuments on a specific qds node of this cluster
> Parameter
1. p1 : "[server]:[port]"	servername and port of the current qccl.qmsservice
2. p2 : "[qdsname]" 		name of the specific QDS engine
```
LET vCurQDSEngine = '$(v.ph.qdsname)';
call qccl.qmsapi.GetAllSourceDocumentsByQds('$(vService)', vCurQDSEngine);
if qccl.qmsapi.GetAllSourceDocumentsByQds.Result.Error = 1 then
	// #CMT# Handle Error Message
	// qccl.qmsapi.GetAllSourceDocumentsByQds.Result.Error
	// qccl.qmsapi.GetAllSourceDocumentsByQds.Result.Error.Message
else
	// #CMT# Work with Result
end if;
```

#### qccl.qmsapi.GetAllTasks
Command to get all tasks of this cluster
> Parameter
1. p1 : "[server]:[port]"	servername and port of the current qccl.qmsservice
```
call qccl.qmsapi.GetAllTasks('$(vService)');
if qccl.qmsapi.GetAllTasks.Result.Error = 1 then
	// #CMT# Handle Error Message
	// qccl.qmsapi.GetAllTasks.Result.Error
	// qccl.qmsapi.GetAllTasks.Result.Error.Message
else
	// #CMT# Work with Result
end if;
```

#### qccl.qmsapi.GetAllTasksByQds
Command to get all tasks on a specific qds node of this cluster
> Parameter
1. p1 : "[server]:[port]"	servername and port of the current qccl.qmsservice
2. p2 : "[qdsname]" 		name of the specific QDS engine
```
LET vCurQDSEngine = '$(v.ph.qdsname)';
call qccl.qmsapi.GetAllTasksByQds('$(vService)', vCurQDSEngine);
if qccl.qmsapi.GetAllTasksByQds.Result.Error = 1 then
	// #CMT# Handle Error Message
	// qccl.qmsapi.GetAllTasksByQds.Result.Error
	// qccl.qmsapi.GetAllTasksByQds.Result.Error.Message
else
	// #CMT# Work with Result
end if;
```

#### qccl.qmsapi.GetTaskByID
Command to get a task by its id
> Parameter
1. p1 : "[server]:[port]"	servername and port of the current qccl.qmsservice
2. p2 : "[taskid]" 		id the of the task
```
LET vCurTaskID = '$(v.ph.taskid)';
call qccl.qmsapi.GetTaskByID('$(vService)', vCurTaskID);
if qccl.qmsapi.GetTaskByID.Result.Error = 1 then
	// #CMT# Handle Error Message
	// qccl.qmsapi.GetTaskByID.Result.Error
	// qccl.qmsapi.GetTaskByID.Result.Error.Message
else
	// #CMT# Work with Result
end if;
```

#### qccl.qmsapi.GetTriggersByTask
Command to get all triggers by taskname
> Parameter
1. p1 : "[server]:[port]"	servername and port of the current qccl.qmsservice
2. p2 : "[taskname]" 		name of the specific task
```
LET vCurTask = '$(v.ph.taskname)';
call qccl.qmsapi.GetTriggersByTask('$(vService)', vCurTask);
if qccl.qmsapi.GetTriggersByTask.Result.Error = 1 then
	// #CMT# Handle Error Message
	// qccl.qmsapi.GetTriggersByTask.Result.Error
	// qccl.qmsapi.GetTriggersByTask.Result.Error.Message
else
	// #CMT# Work with Result
end if;
```

#### qccl.qmsapi.SendMail
Command to send a mail to a specific receipient
> Parameter
1. p1 : "[server]:[port]"	servername and port of the current qccl.qmsservice
2. p2 : "[receipient]" 	receipients mail address
3. p3 : "[subject]" 		mail subject
4. p4 : "[body]" 			mail body
5. p5 : "[ishtml]" 		boolean value to specify if the body is html formatted or not
```
LET vCurReceipient = '$(v.ph.mailreceipient)';
LET vCurSubject = '$(v.ph.mailsubject)';
LET vCurBody = '$(v.ph.mailbody)';
LET vCurIsHtml = '$(v.ph.mailishtml)';
call qccl.qmsapi.SendMail('$(vService)', vCurReceipient, vCurSubject, vCurBody, vCurIsHtml)
if qccl.qmsapi.SendMail.Result.Error = 1 then
	// #CMT# Handle Error Message
	// qccl.qmsapi.GetTriggersByTask.Result.Error
	// qccl.qmsapi.GetTriggersByTask.Result.Error.Message
else
	// #CMT# Work with Result
end if;
```

