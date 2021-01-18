using System;
using System.Threading;
using System.Threading.Tasks;

namespace CleverenceSoft_TestTask
{
    class Program
    {
        static void Main(string[] args)
        {
            //TaskFirst.Run();
            TaskSecond TaskSecond = new TaskSecond();
            TaskSecond.myEventHandler += delegate { Thread.Sleep(TimeSpan.FromSeconds(3)); };
            TaskSecond.Run();
            Console.ReadKey();
        }
    }
}
