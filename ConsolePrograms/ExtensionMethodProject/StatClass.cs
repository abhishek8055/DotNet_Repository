using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExtensionMethodProject
{
    static class StatClass
    {
        public static void Test3(this Program p)
        {
            Console.WriteLine("Method 3");
        }

        public static void Test4(this Program p, int i)
        {
            Console.WriteLine("Method 4: "+i);
        }
    }
}
