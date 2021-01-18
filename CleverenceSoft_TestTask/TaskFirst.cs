using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

/*
    Задача #1
    Есть "сервер" в виде статического класса.  
    У него есть переменная count (тип int) и два метода, которые позволяют эту переменную читать и писать: GetCount() и AddToCount(int value). 
    К серверу стучатся множество параллельных клиентов, которые в основном читают, но некоторые добавляют значение к count. 

    Нужно реализовать GetCount / AddToCount так, чтобы: 
    читатели могли читать параллельно, без выстраивания в очередь по локу; 
    писатели писали только последовательно и никогда одновременно; 
    пока писатели добавляют и пишут, читатели должны ждать окончания записи. 
 */

namespace CleverenceSoft_TestTask
{       
    public class TaskFirst
    {
        public static void Run()
        {
            TaskRun(-1, 1);
            TaskRun(-2, 2);
            TaskRun(-3, 3);
            TaskRun(4, 4);
            TaskRun(5, 5);
            TaskRun(6, 6);
            TaskRun(-7, 7);
            TaskRun(1);
            TaskRun(2);
            TaskRun(3);
            TaskRun(4);
        }
        private static void TaskRun(int AddToCount, int timeout)
        {
            Task.Run(() =>
            {
                while (true)
                {
                    if (Server.IsWaitOne)
                        Console.WriteLine("Method: {0}. [{1}]", nameof(Server.AddToCount), nameof(Server.IsWaitOne));

                    Server.AddToCount(AddToCount);
                    Console.WriteLine("Method: {0}. timeout: {1}. Count: {2}", nameof(Server.AddToCount), timeout, Server.Count);
                    Thread.Sleep(TimeSpan.FromSeconds(timeout));
                }
            });
        }
        private static void TaskRun(int timeout)
        {
            Task.Run(() =>
            {
                while (true)
                {
                    Console.WriteLine("Method: {0}. timeout: {1}. Count: {2}", nameof(Server.GetCount), timeout, Server.GetCount());
                    Thread.Sleep(TimeSpan.FromSeconds(timeout));
                }
            });
        }
    }
}
