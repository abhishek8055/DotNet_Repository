using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Delegates
{
    public delegate double DelegateAddNumns1(int x, float y, double z);
    public delegate void DelegateAddNumns2(int x, float y, double z);
    public delegate bool DelegateTestlength(string name);

    class BasicDelegates
    {
        private static double AddNums1(int x, float y, double z)
        {
            return (x + y + z);
        }

        private void AddNums2(int x, float y, double z)
        {
            Console.WriteLine(x+y+z);
        }

        private static bool TestLength(string name)
        {
            if(name.Length >= 4)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        static void Main()
        {
            BasicDelegates bd = new BasicDelegates();

            Console.WriteLine("******METHOD 1******");
            DelegateAddNumns1 del1 = new DelegateAddNumns1(AddNums1);
            double result = del1.Invoke(10, 12.3f, 123.89);
            Console.WriteLine(result);

            DelegateAddNumns2 del2 = new DelegateAddNumns2(bd.AddNums2);
            del2.Invoke(10, 12.3f, 123.89);

            DelegateTestlength del3 = new DelegateTestlength(TestLength);
            bool status = del3.Invoke("Abhishek");
            Console.WriteLine(status);

            
            Console.WriteLine("******METHOD 2******");
            DelegateAddNumns1 del11 = AddNums1;
            double result1 = del11.Invoke(10, 12.3f, 123.89);
            Console.WriteLine(result1);

            DelegateAddNumns2 del22 = bd.AddNums2;
            del22.Invoke(10, 12.3f, 123.89);

            DelegateTestlength del33 = TestLength;
            bool status1 = del3.Invoke("Abh");
            Console.WriteLine(status1);

            Console.ReadKey();
        }
    }
}
