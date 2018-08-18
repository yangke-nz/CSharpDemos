using System;
using System.Reflection;

namespace Polymorphism
{
    class Program
    {
        static void Main(string[] args)
        {
            BaseClass ObjBase;
            BaseClassV ObjBaseV;

            ObjBase = new DerivedClass();
            ObjBase.DoSomething();

            ObjBaseV = new DerivedClassV();
            ObjBaseV.DoSomething();

            Console.ReadLine();
        }

        class BaseClass
        {
            public void DoSomething()
            {
                Console.WriteLine(MethodBase.GetCurrentMethod().Name + " in BaseClass");
            }
        }

        class DerivedClass : BaseClass
        {
            public new void DoSomething()
            {
                Console.WriteLine(MethodBase.GetCurrentMethod().Name + " in DerivedClass");
            }
        }

        class BaseClassV
        {
            public virtual void DoSomething()
            {
                Console.WriteLine(MethodBase.GetCurrentMethod().Name + " in BaseClassV");
            }
        }

        class DerivedClassV : BaseClassV
        {
            public override void DoSomething()
            {
                Console.WriteLine(MethodBase.GetCurrentMethod().Name + " in DerivedClassV");
            }
        }
    }
}
