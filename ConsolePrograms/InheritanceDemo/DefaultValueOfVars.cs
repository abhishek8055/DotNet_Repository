using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InheritanceDemo
{
    class DefaultValueOfVars
    {
        static int i;
        int j;
        int k;
        public DefaultValueOfVars(int n)
        {
            this.k = n;
        }
        static void Main()
        {
            DefaultValueOfVars d = new DefaultValueOfVars(3);
            Console.WriteLine(i);
            Console.WriteLine(d.j);
            Console.WriteLine(d.k);
            Console.ReadKey();
        }
    }
}
