using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace CleverenceSoft_TestTask
{
    public class AsyncCaller
    {
        public AsyncCaller(EventHandler EventHandler)
        {
            this.EventHandler = EventHandler;
        }
        private EventHandler EventHandler { get; set; }
        public bool Invoke(int millisecondsTimeout, object sender, EventArgs e)
        {
            bool completedOK = false;

            Thread thread = new Thread(() =>
            {
                try
                {
                    if (!(EventHandler is null))
                        EventHandler.Invoke(null, EventArgs.Empty);

                    completedOK = true;
                }
                catch (ThreadAbortException)
                {

                }                
            });
            thread.Start();
            thread.Join(millisecondsTimeout);

            if (thread.IsAlive)
            {
                thread.Abort();
                completedOK = false;
            }

            return completedOK;
        }
    }
}
