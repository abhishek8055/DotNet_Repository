using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InheritanceDemo
{
    class Class1
    {
        public Class1()
        {
            Console.WriteLine("Class 1 Constructor executed");
        }
        public virtual void Test1()
        {
            Console.WriteLine("Test1 method in Class1");
        }
        public virtual void Test2()
        {
            Console.WriteLine("Test2 method in Class1");
        }
    }
}
