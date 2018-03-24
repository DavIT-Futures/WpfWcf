using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace TestApp.Entity
{
    public class ThreadInfo
    {
        private int Percentage { get; set; }
        private Action Callback { get; set; }
        private Action ThreadProc { get; set; }

        public ThreadInfo(int percentage, Action threadProc, Action callback)
        {
            this.Percentage = percentage;
            this.ThreadProc = threadProc;
            this.Callback = callback;
        }

        public void ThreadProcedure()
        {
            this.ThreadProc();
            this.Callback();
        }
    }
}
