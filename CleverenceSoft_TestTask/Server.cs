using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace CleverenceSoft_TestTask
{
    public static class Server
    {
        public static int Count { get; set; }
        public static int GetCount()
        {
            ManualResetEvent.WaitOne();

            return Count;
        }
        public static void AddToCount(int value)
        {
            lock (ManualResetEvent)
            {
                ManualResetEvent.Reset();
                Count += value;
                Thread.Sleep(TimeSpan.FromSeconds(1));
                ManualResetEvent.Set();
            }
        }
        public static bool IsWaitOne { get { return !ManualResetEvent.WaitOne(0); } }
        private static ManualResetEvent ManualResetEvent { get; set; } = new ManualResetEvent(true);
    }
}
