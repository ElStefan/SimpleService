using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Simple.Library
{
    /// <summary>
    /// Controller for library
    /// </summary>
    public class Controller
    {
        private bool _stop;

        /// <summary>
        /// Start thread
        /// </summary>
        public void Start()
        {
            if (Assembly.GetAssembly(typeof(Controller)).GetName().Version > new Version(1, 0, 0, 0))
            {
                // new version contains really bad code, it crashes immediately at start
                throw new InitializationException();
            }

            new Thread(KeepAliveThread).Start();
        }

        private void KeepAliveThread()
        {
            while (!_stop)
            {
                Thread.Sleep(100);
            }
        }

        /// <summary>
        /// Stop thread
        /// </summary>
        public void Stop()
        {
            this._stop = true;
        }
    }
}
