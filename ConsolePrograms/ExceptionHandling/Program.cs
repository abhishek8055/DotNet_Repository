using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExceptionHandling
{
    class Program
    {
        public int TestFinally(int x, int y)
        {
            try
            {
                int z = x / y;
                return z;
            }
            catch(DivideByZeroException ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                Console.WriteLine("Finally block executed");
            }
            return 3;
        }
        static void Main(string[] args)
        {
            Program p = new Program();
            Console.WriteLine(p.TestFinally(10, 0));
            Console.ReadKey();
        }
    }
}
