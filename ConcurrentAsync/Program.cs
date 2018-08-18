using System;
using System.Threading.Tasks;

namespace ConcurrentAsync
{
    class Program
    {
        static void Main(string[] args)
        { 
            ConcurAsync ObjCA = new ConcurAsync();

            ObjCA.DoMultipleTasks().Wait();

            Console.ReadLine();
        }
    }

    class ConcurAsync
    {
        public async Task DoMultipleTasks()
        {
            Task[] tasks = new Task[3];

            tasks[0] = DoTaskWithTime("A", 8);
            tasks[1] = DoTaskWithTime("B", 6);
            tasks[2] = DoTaskWithTime("C", 2);

            Console.WriteLine("All Tasks Started");
            await Task.WhenAll(tasks);
            Console.WriteLine("All Done");

        }

        public async Task DoTaskWithTime(string name, int secs)
        {
            Console.WriteLine("Start Task " + name + " needs " + secs + " secs to complete");
            await Task.Delay(secs * 1000);
            Console.WriteLine("End Task " + name);
        }
    }
}
