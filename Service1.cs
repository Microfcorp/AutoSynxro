using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Threading;

namespace Synchro
{
    public partial class Service1 : ServiceBase
    {
        Wather wather;
        public Service1()
        {
            InitializeComponent();
            this.CanStop = true;
            this.CanPauseAndContinue = true;
            this.AutoLog = true;
        }

        protected override void OnStart(string[] args)
        {
            wather = new Wather();
            Thread loggerThread = new Thread(new ThreadStart(wather.Start));
            loggerThread.Start();
        }

        protected override void OnStop()
        {
            wather.Stop();
            Thread.Sleep(1000);
        }
    }
}
