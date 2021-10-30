using Microsoft.Extensions.DependencyInjection;
using System;

namespace TransientVsScoped
{
    class Program
    {
        private static IServiceProvider _serProvider;
        static void Main(string[] args)
        {
            Console.WriteLine("==== Transient VS Scoped ====");

            /*** Start Register Service ***/
            var serCollection = new ServiceCollection();

            serCollection.AddScoped<IDemoScoped, DemoService>();
            serCollection.AddTransient<IDemoTransient, DemoService>();

            _serProvider = serCollection.BuildServiceProvider();
            /*** End Register Service ***/

            var obj1 = _serProvider.GetService<IDemoScoped>();
            obj1.PrintInstanceKey(); 
            var obj2 = _serProvider.GetService<IDemoScoped>();
            obj2.PrintInstanceKey();
            var obj3 = _serProvider.GetService<IDemoTransient>();
            obj3.PrintInstanceKey();
            var obj4 = _serProvider.GetService<IDemoTransient>();
            obj4.PrintInstanceKey();

            Console.WriteLine("Scoped: Same method same intance.");
            Console.WriteLine("Transient: Same method diff instance.");
        }
    }

    interface IDemoScoped
    {
        void PrintInstanceKey();
    }

    interface IDemoTransient
    {
        void PrintInstanceKey();
    }

    public class DemoService : IDemoScoped, IDemoTransient {

        Guid key;
        public DemoService()
        {
            this.key = Guid.NewGuid();
            Console.WriteLine(">>> Constructor called. KEY: " + this.key);
        }
        public void PrintInstanceKey()
        {
            Console.WriteLine(">>> Print from instance. KEY: " + this.key);
        }
    }

}
