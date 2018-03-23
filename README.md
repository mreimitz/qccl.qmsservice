# qccl.qmsservice
* * *

## QlikView task automation 
The qccl.qmsservice is a REST WebService that serves as wrapper for the QlikView Server QMS API interface. In addition to the web service itself, a QlikView function library is provided to make it easier to call the service functions. 
For example, a task can be started or stopped from a normal QlikView script.

The aim of the project is to keep the operation of a QlikView environment as autonomous as possible. QlikView can monitor the data of the source systems independently and start loading processes when needed without being dependent on triggers from the source systems.

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

