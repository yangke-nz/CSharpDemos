using System;
using System.Threading.Tasks;

namespace Singleton
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Create both Objects in parallel."); 
            Parallel.Invoke(
                () => {
                    Singleton Obj1 = Singleton.Instance;
                    Console.WriteLine(">>> Obj 1 created");
                },
                () => {
                    Singleton Obj2 = Singleton.Instance;
                    Console.WriteLine(">>> Obj 2 created");
                }
                );

            Console.WriteLine("Singleton constructor should only be called once");

            Console.ReadLine();

        }
    }

    public sealed class Singleton
    {
        private static Singleton _instance = null;
        private static readonly object _objLock = new object();

        private Singleton()
        {
            Console.WriteLine(">>> Singleton constructor called.");
        }

        public static Singleton Instance
        {
            get
            {
                lock (_objLock) // only one thread 
                {
                    if (_instance == null)
                    {
                        _instance = new Singleton();
                    }
                    return _instance;
                }
            }
        }
    }
}
