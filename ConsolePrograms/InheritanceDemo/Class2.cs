using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InheritanceDemo
{
    class Class2 : Class1
    {
        public Class2()
        {
            Console.WriteLine("Class 2 Constructor executed");
        }
        public override void Test1()
        {
            Console.WriteLine("Test1 method in Class2");
        }
        public override void Test2()
        {
            Console.WriteLine("Test2 method in Class2");
        }
        public void Test3()
        {
            Console.WriteLine("Test3 method in Class2");
        }

        static void Main()
        {
            Class1 p = new Class1();
            p.Test1();
            p.Test2();
            Console.WriteLine("\n");

            Class1 r = new Class2();
            r.Test1();
            r.Test2();
            Console.WriteLine("\n");

            Class2 c = new Class2();
            c.Test1();
            c.Test2();
            c.Test3();
            Console.ReadLine();
        }
    }
}
