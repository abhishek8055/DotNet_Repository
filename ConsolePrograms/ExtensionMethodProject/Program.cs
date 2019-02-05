using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExtensionMethodProject
{
    public class Program
    {
        public void Test1()
        {
            Console.WriteLine("Method 1");
        }

        public void Test2()
        {
            Console.WriteLine("Method 2");
        }

        static void Main()
        {
            Program p = new Program();
            p.Test1();
            p.Test2();
            p.Test3();
            p.Test4(20);
            Console.ReadKey();
        }
    }
}
