using qccl.appservice.IQMSAPI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

namespace qccl.qmsservice.Support
{
    /// <summary>
    /// 
    /// </summary>
    internal class APIClient
    {
        /// <summary>
        /// The client
        /// </summary>
        private QMSClient _client;

        /// <summary>
        /// Gets the client.
        /// </summary>
        /// <value>
        /// The client.
        /// </value>
        public QMSClient Client { get => _client; }


        /// <summary>
        /// Initializes a new instance of the <see cref="APIClient"/> class.
        /// </summary>
        internal APIClient()
        {
            try
            {
                _client = new QMSClient("BasicHttpBinding_IQMS");
                string key = _client.GetTimeLimitedServiceKey();
                ServiceKeyClientMessageInspector.ServiceKey = key;
            }
            catch (System.Exception)
            {
                throw;
            }
        }


        /// <summary>
        /// Initializes a new instance of the <see cref="APIClient"/> class.
        /// </summary>
        /// <param name="_url">The URL.</param>
        /// <exception cref="System.Exception">Servername is null</exception>
        internal APIClient(string _url)
        {
            try
            {
               
                if (string.IsNullOrEmpty(_url))
                    throw new System.Exception("Servername is null");

                string QMS = "http://" + _url + ":4799/QMS/Service";
                _client = new QMSClient("BasicHttpBinding_IQMS", QMS);
                string key = _client.GetTimeLimitedServiceKey();
                ServiceKeyClientMessageInspector.ServiceKey = key;
            }
            catch (System.Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// Gets the QDS identifier.
        /// </summary>
        /// <param name="_server">The server.</param>
        /// <returns></returns>
        /// <exception cref="System.Exception">QmsClient is null
        /// or
        /// Server is null
        /// or
        /// No Server like " + _server + " in this cluster.</exception>
        internal Guid GetQdsID(string _server)
        {
            try
            {
                if (_client == null)
                    throw new System.Exception("QmsClient is null");
                if (string.IsNullOrEmpty(_server))
                    throw new System.Exception("Server is null");

                //Get a list of QlikView Distribution services
                List<ServiceInfo> qdsServices = _client.GetServices(ServiceTypes.QlikViewDistributionService).ToList();

                //Loops through all services 
                foreach (ServiceInfo info in qdsServices)
                {
                    if (info.Name.ToLower() == _server.ToLower())
                        return info.ID;
                }

                throw new System.Exception("No Server like " + _server + " in this cluster.");
            }
            catch (System.Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// Gets all servers.
        /// </summary>
        /// <returns></returns>
        /// <exception cref="System.Exception">QmsClient is null</exception>
        internal List<string> GetAllServers()
        {
            try
            {
                if (_client == null)
                    throw new System.Exception("QmsClient is null");

                return GetServers(ServiceTypes.All);
            }
            catch (System.Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// Gets the QDS servers.
        /// </summary>
        /// <returns></returns>
        /// <exception cref="System.Exception">QmsClient is null</exception>
        internal List<string> GetQDSServers()
        {
            try
            {
                if (_client == null)
                    throw new System.Exception("QmsClient is null");

                return GetServers(ServiceTypes.QlikViewDistributionService);
            }
            catch (System.Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// Gets the DSC servers.
        /// </summary>
        /// <returns></returns>
        /// <exception cref="System.Exception">QmsClient is null</exception>
        internal List<string> GetDSCServers()
        {
            try
            {
                if (_client == null)
                    throw new System.Exception("QmsClient is null");

                return GetServers(ServiceTypes.QlikViewDirectoryServiceConnector);
            }
            catch (System.Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// Gets the QMS servers.
        /// </summary>
        /// <returns></returns>
        /// <exception cref="System.Exception">QmsClient is null</exception>
        internal List<string> GetQMSServers()
        {
            try
            {
                if (_client == null)
                    throw new System.Exception("QmsClient is null");

                return GetServers(ServiceTypes.QlikViewManagementService);
            }
            catch (System.Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// Gets the QVS servers.
        /// </summary>
        /// <returns></returns>
        /// <exception cref="System.Exception">QmsClient is null</exception>
        internal List<string> GetQVSServers()
        {
            try
            {
                if (_client == null)
                    throw new System.Exception("QmsClient is null");

                return GetServers(ServiceTypes.QlikViewServer);
            }
            catch (System.Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// Gets the QWS servers.
        /// </summary>
        /// <returns></returns>
        /// <exception cref="System.Exception">QmsClient is null</exception>
        internal List<string> GetQWSServers()
        {
            try
            {
                if (_client == null)
                    throw new System.Exception("QmsClient is null");

                return GetServers(ServiceTypes.QlikViewWebServer);
            }
            catch (System.Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// Gets the RMS servers.
        /// </summary>
        /// <returns></returns>
        /// <exception cref="System.Exception">QmsClient is null</exception>
        internal List<string> GetRMSServers()
        {
            try
            {
                if (_client == null)
                    throw new System.Exception("QmsClient is null");

                return GetServers(ServiceTypes.RemoteQlikViewManagementService);
            }
            catch (System.Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// Gets the servers.
        /// </summary>
        /// <param name="_type">The type.</param>
        /// <returns></returns>
        /// <exception cref="System.Exception">QmsClient is null</exception>
        private List<string> GetServers(ServiceTypes _type)
        {
            try
            {
                if (_client == null)
                    throw new System.Exception("QmsClient is null");

                //Get a list of QlikView Distribution services
                List<ServiceInfo> qdsServices = _client.GetServices(_type).ToList();

                List<string> _result = new List<string>();

                //Loops through all services 
                foreach (ServiceInfo info in qdsServices)
                {
                    _result.Add(info.Name);
                }

                return _result;
            }
            catch (System.Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// Gets the categories.
        /// </summary>
        /// <returns></returns>
        /// <exception cref="System.Exception">QmsClient is null</exception>
        internal List<string> GetCategories()
        {
            try
            {
                if (_client == null)
                    throw new System.Exception("QmsClient is null");

                List<string> _result = new List<string>();

                //Loops through all services 
                foreach (Category cat in _client.GetCategories(CategoriesScope.All))
                {
                    _result.Add(cat.Name);
                }

                return _result;

            }
            catch (System.Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// Gets the running tasks.
        /// </summary>
        /// <returns></returns>
        /// <exception cref="System.Exception">QmsClient is null</exception>
        internal List<string> GetRunningTasks()
        {
            try
            {
                if (_client == null)
                    throw new System.Exception("QmsClient is null");

                //Get a list of QlikView Distribution services
                List<ServiceInfo> qdsServices = _client.GetServices(ServiceTypes.QlikViewDistributionService).ToList();

                List<string> _result = new List<string>();

                //Loops through all services 
                foreach (ServiceInfo info in qdsServices)
                {
                    //Gets the General settings for the current service and print information abput the folders used.
                    TaskInfo[] tasks = _client.GetTasks(info.ID);
                    foreach (TaskInfo task in tasks)
                    {
                        TaskStatusValue _status = _client.GetTaskStatus(task.ID, TaskStatusScope.All).General.Status;
                        if (_status == TaskStatusValue.Running)
                        {
                            _result.Add(task.Name);
                        }
                    }
                }

                return _result;
            }
            catch (System.Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// Gets the running tasks.
        /// </summary>
        /// <param name="_category">The category.</param>
        /// <returns></returns>
        /// <exception cref="System.Exception">QmsClient is null
        /// or
        /// Server is null
        /// or
        /// Category is null</exception>
        internal List<string> GetRunningTasks(string _category)
        {
            try
            {
                if (_client == null)
                    throw new System.Exception("QmsClient is null");
                if (string.IsNullOrEmpty(_category))
                    throw new System.Exception("Category is null");

                List<string> _result = new List<string>();

                //Get a list of QlikView Distribution services
                List<ServiceInfo> qdsServices = _client.GetServices(ServiceTypes.QlikViewDistributionService).ToList();

                //Loops through all services 
                foreach (ServiceInfo info in qdsServices)
                {
                    //Gets the General settings for the current service and print information abput the folders used.
                    TaskInfo[] tasks = _client.GetTasks(info.ID);
                    foreach (TaskInfo task in tasks)
                    {
                        if (_client.GetDocumentTask(task.ID, DocumentTaskScope.DocumentInfo).DocumentInfo.Category == _category)
                        {
                            TaskStatusValue _status = _client.GetTaskStatus(task.ID, TaskStatusScope.All).General.Status;
                            if (_status == TaskStatusValue.Running)
                            {
                                _result.Add(task.Name);
                            }
                        }
                    }
                }

                return _result;
            }
            catch (System.Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// Gets all tasks.
        /// </summary>
        /// <returns></returns>
        /// <exception cref="System.Exception">QmsClient is null</exception>
        internal List<string> GetAllTasks()
        {
            try
            {
                if (_client == null)
                    throw new System.Exception("QmsClient is null");

                //Get a list of QlikView Distribution services
                List<ServiceInfo> qdsServices = _client.GetServices(ServiceTypes.QlikViewDistributionService).ToList();

                List<string> _result = new List<string>();

                //Loops through all services 
                foreach (ServiceInfo info in qdsServices)
                {
                    //Gets the General settings for the current service and print information abput the folders used.
                    TaskInfo[] tasks = _client.GetTasks(info.ID);
                    foreach (TaskInfo task in tasks)
                    {
                        _result.Add(task.Name);
                    }
                }

                return _result;
            }
            catch (System.Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// Gets all tasks.
        /// </summary>
        /// <param name="_server">The server.</param>
        /// <returns></returns>
        /// <exception cref="System.Exception">QmsClient is null
        /// or
        /// Server is null
        /// or
        /// No Server like " + _server + " in this cluster.</exception>
        internal List<string> GetAllTasks(string _server)
        {
            try
            {
                if (_client == null)
                    throw new System.Exception("QmsClient is null");
                if (string.IsNullOrEmpty(_server))
                    throw new System.Exception("Server is null");

                List<string> _result = new List<string>();

                Guid _qdsid = GetQdsID(_server);
                if (_qdsid == Guid.Empty)
                    throw new System.Exception("No Server like " + _server + " in this cluster.");

                //Gets the General settings for the current service and print information abput the folders used.
                TaskInfo[] tasks = _client.GetTasks(_qdsid);
                foreach (TaskInfo task in tasks)
                {
                    _result.Add(task.Name);
                }

                return _result;
            }
            catch (System.Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// Gets the task identifier.
        /// </summary>
        /// <param name="_name">The name.</param>
        /// <returns></returns>
        /// <exception cref="System.Exception">QmsClient is null
        /// or
        /// Taskname is null</exception>
        /// <exception cref="KeyNotFoundException"></exception>
        internal Guid GetTaskId(string _name)
        {
            try
            {
                if (_client == null)
                    throw new System.Exception("QmsClient is null");
                if (string.IsNullOrEmpty(_name))
                    throw new System.Exception("Taskname is null");

                //Get a list of QlikView Distribution services
                List<ServiceInfo> qdsServices = _client.GetServices(ServiceTypes.QlikViewDistributionService).ToList();

                //Loops through all services 
                foreach (ServiceInfo info in qdsServices)
                {
                    TaskInfo taskInfo = _client.FindTask(info.ID, TaskType.Undefined, _name);
                    if (taskInfo != null)
                        return taskInfo.ID;
                }

                throw new KeyNotFoundException(_name);
            }
            catch (System.Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// Tasks the status.
        /// </summary>
        /// <param name="_name">The name.</param>
        /// <returns></returns>
        /// <exception cref="System.Exception">QmsClient is null
        /// or
        /// Taskname is null</exception>
        internal string TaskStatus(string _name)
        {
            try
            {
                if (_client == null)
                    throw new System.Exception("QmsClient is null");
                if (string.IsNullOrEmpty(_name))
                    throw new System.Exception("Taskname is null");

                Guid _taskID = GetTaskId(_name);
                TaskStatusValue _Status = _client.GetTaskStatus(_taskID, TaskStatusScope.All).General.Status;
                return _Status.ToString();
            }
            catch (System.Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// Starts the task.
        /// </summary>
        /// <param name="_name">The name.</param>
        /// <returns></returns>
        /// <exception cref="System.Exception">QmsClient is null
        /// or
        /// Taskname is null</exception>
        internal string StartTask(string _name)
        {
            try
            {
                if (_client == null)
                    throw new System.Exception("QmsClient is null");
                if (string.IsNullOrEmpty(_name))
                    throw new System.Exception("Taskname is null");

                Guid _taskID = GetTaskId(_name);
                TaskStatusValue _preStatus = _client.GetTaskStatus(_taskID, TaskStatusScope.All).General.Status;
                switch (_preStatus)
                {
                    case TaskStatusValue.Waiting:
                    case TaskStatusValue.Completed:
                    case TaskStatusValue.Failed:
                    case TaskStatusValue.Warning:
                        _client.RunTask(_taskID);
                        Thread.Sleep(10 * 1000);
                        TaskStatus taskStatus = _client.GetTaskStatus(_taskID, TaskStatusScope.All);
                        return taskStatus.General.Status.ToString();
                    default:
                        return _preStatus.ToString();
                }
            }
            catch (System.Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// Aborts the task.
        /// </summary>
        /// <param name="_name">The name.</param>
        /// <returns></returns>
        /// <exception cref="System.Exception">QmsClient is null
        /// or
        /// Taskname is null</exception>
        internal string AbortTask(string _name)
        {
            try
            {
                if (_client == null)
                    throw new System.Exception("QmsClient is null");
                if (string.IsNullOrEmpty(_name))
                    throw new System.Exception("Taskname is null");

                Guid _taskID = GetTaskId(_name);
                TaskStatusValue _preStatus = _client.GetTaskStatus(_taskID, TaskStatusScope.All).General.Status;
                switch (_preStatus)
                {
                    case TaskStatusValue.Running:
                        _client.AbortTask(_taskID);
                        TaskStatus taskStatus = _client.GetTaskStatus(_taskID, TaskStatusScope.All);
                        Thread.Sleep(10 * 1000);
                        return taskStatus.General.Status.ToString();
                    default:
                        return _preStatus.ToString();
                }
            }
            catch (System.Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// Gets the source documents.
        /// </summary>
        /// <param name="_server">The server.</param>
        /// <returns></returns>
        /// <exception cref="System.Exception">QmsClient is null</exception>
        internal List<string> GetSourceDocuments(string _server)
        {
            try
            {
                if (_client == null)
                    throw new System.Exception("QmsClient is null");
                if (string.IsNullOrEmpty(_server))
                    throw new System.Exception("Server is null");

                List<string> _result = new List<string>();

                Guid _qdsid = GetQdsID(_server);
                if (_qdsid == Guid.Empty)
                    throw new System.Exception("No Server like " + _server + " in this cluster.");

                DocumentNode[] _sourcedocuments = _client.GetSourceDocuments(_qdsid);
                foreach (DocumentNode _node in _sourcedocuments)
                {
                    _result.Add(_node.Name);
                }

                return _result;
            }
            catch (System.Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// Gets the triggers by task.
        /// </summary>
        /// <param name="_name">The name.</param>
        /// <returns></returns>
        /// <exception cref="System.Exception">QmsClient is null
        /// or
        /// Taskname is null
        /// or
        /// Invalid Triggertype : " + _trigger.Type</exception>
        internal List<string> GetTriggersByTask(string _name)
        {
            try
            {
                if (_client == null)
                    throw new System.Exception("QmsClient is null");
                if (string.IsNullOrEmpty(_name))
                    throw new System.Exception("Taskname is null");

                List<string> _result = new List<string>();

                Guid _taskID = GetTaskId(_name);
                DocumentTask _task = _client.GetDocumentTask(_taskID, DocumentTaskScope.All);

                int _triggerid = 0;
                foreach (Trigger _trigger in _client.GetDocumentTask(_taskID, DocumentTaskScope.All).Triggering.Triggers)
                {
                    _triggerid++;

                    switch (_trigger.Type)
                    {
                        case TaskTriggerType.OnceTrigger:
                        case TaskTriggerType.HourlyTrigger:
                        case TaskTriggerType.DailyTrigger:
                        case TaskTriggerType.WeeklyTrigger:
                        case TaskTriggerType.MonthlyTrigger:
                        case TaskTriggerType.ContinuousTrigger:
                            ScheduleTrigger _scheduletrigger = (ScheduleTrigger)_trigger;
                            _result.Add(_triggerid + "|" + _scheduletrigger.Type + "|" + _scheduletrigger.StartAt);
                            break;
                        case TaskTriggerType.ExternalEventTrigger:
                            ExternalEventTrigger _externaltrigger = (ExternalEventTrigger)_trigger;
                            _result.Add(_triggerid + "|" + _externaltrigger.Type);
                            break;
                        case TaskTriggerType.TaskFinishedTrigger:
                        case TaskTriggerType.TaskFailedTrigger:
                            TaskEventTrigger _eventtrigger = (TaskEventTrigger)_trigger;
                            _result.Add(_triggerid + "|" + _eventtrigger.Type + "|" + _eventtrigger.TaskID);
                            break;
                        case TaskTriggerType.AndTrigger:
                            MultipleEventTrigger _multitrigger = (MultipleEventTrigger)_trigger;
                            int _subtriggerid = 0;
                            foreach(TaskEventTrigger _subtrigger in _multitrigger.SubTriggers)
                            {
                                _subtriggerid++;
                                _result.Add(_triggerid + "|" + _multitrigger.Type + "|" + _subtriggerid + "|" + _subtrigger.TaskID);
                            }
                            break;
                        default:
                            throw new System.Exception("Invalid Triggertype : " + _trigger.Type);
                    }
                }

                return _result;
            }
            catch (System.Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// Gets the task by identifier.
        /// </summary>
        /// <param name="_id">The identifier.</param>
        /// <returns></returns>
        /// <exception cref="System.Exception">QmsClient is null
        /// or
        /// ID is null
        /// or
        /// No Task found with id " + _id</exception>
        internal string GetTaskById(string _id)
        {
            try
            {
                if (_client == null)
                    throw new System.Exception("QmsClient is null");
                if (string.IsNullOrEmpty(_id))
                    throw new System.Exception("ID is null");

                TaskInfo _task = _client.GetTask(Guid.Parse(_id));
                if(_task == null)
                    throw new System.Exception("No Task found with id " + _id);
                else
                {
                    return _task.Name;
                }
            }
            catch (System.Exception)
            {
                throw;
            }
        }
    }
}
