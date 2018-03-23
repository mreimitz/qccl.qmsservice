using qccl.qmsservice.Support;
using qccl.toolbox;
using qccl.toolbox.mail;
using System.Web.Script.Services;
using System.Web.Services;

namespace qccl.qmsservice
{
    /// <summary>
    /// Summary description for qmsservice
    /// </summary>
    /// <seealso cref="System.Web.Services.WebService" />
    [WebService(Namespace = "http://qccl.qmsservice.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
   // [System.Web.Script.Services.ScriptService]
    public class qmsservice : System.Web.Services.WebService
    {
        /// <summary>
        /// The log
        /// </summary>
        private static readonly log4net.ILog _log = 
                log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        /// <summary>
        /// Gets the running tasks.
        /// </summary>
        /// <returns></returns>
        [WebMethod]
        [ScriptMethod(UseHttpGet = true)]
        public string[] GetRunningTasks()
        {
            try
            {
                _log.Info(Context.Request.Url.ToString());
                APIClient _client = new APIClient();
                return Tools.List2StringArray(_client.GetRunningTasks());
            }
            catch (System.Exception ex)
            {
                _log.Error(ex.Message, ex);
                return Tools.Exeception2StringArray(ex);
            }
        }

        /// <summary>
        /// Gets the running tasks by category.
        /// </summary>
        /// <param name="category">The category.</param>
        /// <returns></returns>
        [WebMethod]
        [ScriptMethod(UseHttpGet = true)]
        public string[] GetRunningTasksByCategory(string category)
        {
            try
            {
                _log.Info(Context.Request.Url.ToString() + "[category=" + category + "]");
                APIClient _client = new APIClient();
                return Tools.List2StringArray(_client.GetRunningTasks(category));
            }
            catch (System.Exception ex)
            {
                _log.Error(ex.Message, ex);
                return Tools.Exeception2StringArray(ex);
            }
        }

        /// <summary>
        /// Counts the running tasks.
        /// </summary>
        /// <returns></returns>
        [WebMethod]
        [ScriptMethod(UseHttpGet = true)]
        public string[] CountRunningTasks()
        {
            try
            {
                _log.Info(Context.Request.Url.ToString());
                APIClient _client = new APIClient();
                return Tools.String2StringArray(_client.GetRunningTasks().Count.ToString());
            }
            catch (System.Exception ex)
            {
                _log.Error(ex.Message, ex);
                return Tools.Exeception2StringArray(ex);
            }
        }

        /// <summary>
        /// Counts the running tasks by category.
        /// </summary>
        /// <param name="category">The category.</param>
        /// <returns></returns>
        [WebMethod]
        [ScriptMethod(UseHttpGet = true)]
        public string[] CountRunningTasksByCategory(string category)
        {
            try
            {
                _log.Info(Context.Request.Url.ToString() + "[category=" + category + "]");
                APIClient _client = new APIClient();
                return Tools.String2StringArray(_client.GetRunningTasks(category).Count.ToString());
            }
            catch (System.Exception ex)
            {
                _log.Error(ex.Message, ex);
                return Tools.Exeception2StringArray(ex);
            }
        }

        /// <summary>
        /// Gets the categories.
        /// </summary>
        /// <returns></returns>
        [WebMethod]
        [ScriptMethod(UseHttpGet = true)]
        public string[] GetCategories()
        {
            try
            {
                _log.Info(Context.Request.Url.ToString() + "");
                APIClient _client = new APIClient();
                return Tools.List2StringArray(_client.GetCategories());
            }
            catch (System.Exception ex)
            {
                _log.Error(ex.Message, ex);
                return Tools.Exeception2StringArray(ex);
            }
        }

        /// <summary>
        /// Tasks the status.
        /// </summary>
        /// <param name="task">The task.</param>
        /// <returns></returns>
        [WebMethod]
        [ScriptMethod(UseHttpGet = true)]
        public string[] TaskStatus(string task)
        {
            try
            {
                _log.Info(Context.Request.Url.ToString() + "[task=" + task + "]");
                APIClient _client = new APIClient();
                return Tools.String2StringArray(_client.TaskStatus(task).ToString());
            }
            catch (System.Exception ex)
            {
                _log.Error(ex.Message, ex);
                return Tools.Exeception2StringArray(ex);
            }
        }

        /// <summary>
        /// Gets all source documents by QDS.
        /// </summary>
        /// <param name="qdsnode">The qdsnode.</param>
        /// <returns></returns>
        [WebMethod]
        [ScriptMethod(UseHttpGet = true)]
        public string[] GetAllSourceDocumentsByQds(string qdsnode)
        {
            try
            {
                _log.Info(Context.Request.Url.ToString());
                APIClient _client = new APIClient();
                return Tools.List2StringArray(_client.GetSourceDocuments(qdsnode));
            }
            catch (System.Exception ex)
            {
                _log.Error(ex.Message, ex);
                return Tools.Exeception2StringArray(ex);
            }
        }

        /// <summary>
        /// Gets all tasks.
        /// </summary>
        /// <returns></returns>
        [WebMethod]
        [ScriptMethod(UseHttpGet = true)]
        public string[] GetAllTasks()
        {
            try
            {
                _log.Info(Context.Request.Url.ToString());
                APIClient _client = new APIClient();
                return Tools.List2StringArray(_client.GetAllTasks());
            }
            catch (System.Exception ex)
            {
                _log.Error(ex.Message, ex);
                return Tools.Exeception2StringArray(ex);
            }
        }

        /// <summary>
        /// Gets all tasks by QDS.
        /// </summary>
        /// <param name="qdsnode">The qdsnode.</param>
        /// <returns></returns>
        [WebMethod]
        [ScriptMethod(UseHttpGet = true)]
        public string[] GetAllTasksByQds(string qdsnode)
        {
            try
            {
                _log.Info(Context.Request.Url.ToString());
                APIClient _client = new APIClient();
                return Tools.List2StringArray(_client.GetAllTasks(qdsnode));
            }
            catch (System.Exception ex)
            {
                _log.Error(ex.Message, ex);
                return Tools.Exeception2StringArray(ex);
            }
        }

        /// <summary>
        /// Gets the triggers by task.
        /// </summary>
        /// <param name="task">The task.</param>
        /// <returns></returns>
        [WebMethod]
        [ScriptMethod(UseHttpGet = true)]
        public string[] GetTriggersByTask(string task)
        {
            try
            {
                _log.Info(Context.Request.Url.ToString() + "[task=" + task + "]");
                APIClient _client = new APIClient();
                return Tools.List2StringArray(_client.GetTriggersByTask(task));
            }
            catch (System.Exception ex)
            {
                _log.Error(ex.Message, ex);
                return Tools.Exeception2StringArray(ex);
            }
        }

        /// <summary>
        /// Gets the task by identifier.
        /// </summary>
        /// <param name="taskid">The taskid.</param>
        /// <returns></returns>
        [WebMethod]
        [ScriptMethod(UseHttpGet = true)]
        public string[] GetTaskByID(string taskid)
        {
            try
            {
                _log.Info(Context.Request.Url.ToString());
                APIClient _client = new APIClient();
                return Tools.String2StringArray(_client.GetTaskById(taskid));
            }
            catch (System.Exception ex)
            {
                _log.Error(ex.Message, ex);
                return Tools.Exeception2StringArray(ex);
            }
        }

        /// <summary>
        /// Starts the task.
        /// </summary>
        /// <param name="task">The task.</param>
        /// <returns></returns>
        [WebMethod]
        [ScriptMethod(UseHttpGet = true)]
        public string[] StartTask(string task)
        {
            try
            {
                _log.Info(Context.Request.Url.ToString() + "[task=" + task + "]");
                APIClient _client = new APIClient();
                return Tools.String2StringArray(_client.StartTask(task).ToString());
            }
            catch (System.Exception ex)
            {
                _log.Error(ex.Message, ex);
                return Tools.Exeception2StringArray(ex);
            }
        }

        /// <summary>
        /// Aborts the task.
        /// </summary>
        /// <param name="task">The task.</param>
        /// <returns></returns>
        [WebMethod]
        [ScriptMethod(UseHttpGet = true)]
        public string[] AbortTask(string task)
        {
            try
            {
                _log.Info(Context.Request.Url.ToString() + "[task=" + task + "]");
                APIClient _client = new APIClient();
                return Tools.String2StringArray(_client.AbortTask(task).ToString());
            }
            catch (System.Exception ex)
            {
                _log.Error(ex.Message, ex);
                return Tools.Exeception2StringArray(ex);
            }
        }

        /// <summary>
        /// Gets all servers.
        /// </summary>
        /// <returns></returns>
        [WebMethod]
        [ScriptMethod(UseHttpGet = true)]
        public string[] GetAllServers()
        {
            try
            {
                _log.Info(Context.Request.Url.ToString());
                APIClient _client = new APIClient();
                return Tools.List2StringArray(_client.GetAllServers());
            }
            catch (System.Exception ex)
            {
                _log.Error(ex.Message, ex);
                return Tools.Exeception2StringArray(ex);
            }
        }

        /// <summary>
        /// Gets the QDS servers.
        /// </summary>
        /// <returns></returns>
        [WebMethod]
        [ScriptMethod(UseHttpGet = true)]
        public string[] GetQDSServers()
        {
            try
            {
                _log.Info(Context.Request.Url.ToString());
                APIClient _client = new APIClient();
                return Tools.List2StringArray(_client.GetQDSServers());
            }
            catch (System.Exception ex)
            {
                _log.Error(ex.Message, ex);
                return Tools.Exeception2StringArray(ex);
            }
        }

        /// <summary>
        /// Gets the DSC servers.
        /// </summary>
        /// <returns></returns>
        [WebMethod]
        [ScriptMethod(UseHttpGet = true)]
        public string[] GetDSCServers()
        {
            try
            {
                _log.Info(Context.Request.Url.ToString());
                APIClient _client = new APIClient();
                return Tools.List2StringArray(_client.GetDSCServers());
            }
            catch (System.Exception ex)
            {
                _log.Error(ex.Message, ex);
                return Tools.Exeception2StringArray(ex);
            }
        }

        /// <summary>
        /// Gets the QMS servers.
        /// </summary>
        /// <returns></returns>
        [WebMethod]
        [ScriptMethod(UseHttpGet = true)]
        public string[] GetQMSServers()
        {
            try
            {
                _log.Info(Context.Request.Url.ToString());
                APIClient _client = new APIClient();
                return Tools.List2StringArray(_client.GetQMSServers());
            }
            catch (System.Exception ex)
            {
                _log.Error(ex.Message, ex);
                return Tools.Exeception2StringArray(ex);
            }
        }

        /// <summary>
        /// Gets the QVS servers.
        /// </summary>
        /// <returns></returns>
        [WebMethod]
        [ScriptMethod(UseHttpGet = true)]
        public string[] GetQVSServers()
        {
            try
            {
                _log.Info(Context.Request.Url.ToString());
                APIClient _client = new APIClient();
                return Tools.List2StringArray(_client.GetQVSServers());
            }
            catch (System.Exception ex)
            {
                _log.Error(ex.Message, ex);
                return Tools.Exeception2StringArray(ex);
            }
        }

        /// <summary>
        /// Gets the QWS servers.
        /// </summary>
        /// <returns></returns>
        [WebMethod]
        [ScriptMethod(UseHttpGet = true)]
        public string[] GetQWSServers()
        {
            try
            {
                _log.Info(Context.Request.Url.ToString());
                APIClient _client = new APIClient();
                return Tools.List2StringArray(_client.GetQWSServers());
            }
            catch (System.Exception ex)
            {
                _log.Error(ex.Message, ex);
                return Tools.Exeception2StringArray(ex);
            }
        }

        /// <summary>
        /// Gets the RMS servers.
        /// </summary>
        /// <returns></returns>
        [WebMethod]
        [ScriptMethod(UseHttpGet = true)]
        public string[] GetRMSServers()
        {
            try
            {
                _log.Info(Context.Request.Url.ToString());
                APIClient _client = new APIClient();
                return Tools.List2StringArray(_client.GetRMSServers());
            }
            catch (System.Exception ex)
            {
                _log.Error(ex.Message, ex);
                return Tools.Exeception2StringArray(ex);
            }
        }

        /// <summary>
        /// Sends the mail.
        /// </summary>
        /// <param name="to">To.</param>
        /// <param name="subject">The subject.</param>
        /// <param name="body">The body.</param>
        /// <param name="ishtml">if set to <c>true</c> [ishtml].</param>
        /// <returns></returns>
        [WebMethod]
        [ScriptMethod(UseHttpGet = true)]
        public string[] SendMail(string to, string subject, string body, bool ishtml)
        {
            try
            {
                _log.Info(Context.Request.Url.ToString() + "[to=" + to + "][subject=" + subject + "][body=" + body + "][ishtml=" + ishtml.ToString() + "]");

                string _host = Properties.Settings.Default.SmtpHost;
                int _port = Properties.Settings.Default.SmtpPort;
                string _from = Properties.Settings.Default.SmtpSender;
                bool _useSSL = Properties.Settings.Default.SmtpUseSSL;

                string result = smtpclient.SendMail(_host, _port, _from, _useSSL, to, subject, body, ishtml);

                return Tools.String2StringArray(result);
            }
            catch (System.Exception ex)
            {
                _log.Error(ex.Message, ex);
                return Tools.Exeception2StringArray(ex);
            }
        }
    }
}
