using Simple.Library;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Threading.Tasks;

namespace Simple.Service
{
    public partial class WindowsService : ServiceBase
    {
        private Controller _controller = new Controller();

        public WindowsService()
        {
            InitializeComponent();
            AppDomain.CurrentDomain.UnhandledException += (s, e) =>
            {
                if (EventLog.SourceExists(ServiceName))
                {
                    EventLog.WriteEntry(ServiceName,
                        "Fatal Exception : " + Environment.NewLine +
                        e.ExceptionObject, EventLogEntryType.Error);
                }
            };
        }

        protected override void OnStart(string[] args)
        {
            try
            {
                _controller.Start();
            }
            catch
            {
                ExitCode = 1064;
                throw;
            }
        }

        protected override void OnStop()
        {
            _controller.Stop();
        }
    }
}
