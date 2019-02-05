using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Delegates
{
    class GenericDelegates
    {
        private static double AddNums1(int x, float y, double z)
        {
            return (x + y + z);
        }

        private void AddNums2(int x, float y, double z)
        {
            Console.WriteLine(x + y + z);
        }

        private static bool TestLength(string name)
        {
            if (name.Length >= 4)
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
            GenericDelegates gdObj = new GenericDelegates();

            Console.WriteLine("*****METHOD 1*****");

            Func<int, float, double, double> obj1 = AddNums1;
            double result = obj1.Invoke(10, 10.0f, 10.00);
            Console.WriteLine(result);

            Action<int, float, double> obj2 = gdObj.AddNums2;
            obj2.Invoke(10, 10.0f, 10.00);

            Predicate<string> obj3 = TestLength;
            bool status = obj3.Invoke("Aka");
            Console.WriteLine(status);


            Console.WriteLine("*****METHOD 2 (Lambda Exp)*****");

            Func<int, float, double, double> gObj1 = (x, y, z) =>
            {
                return x + y + z;
            };
            result = gObj1.Invoke(10, 10.0f, 10.00);
            Console.WriteLine(result);

            Action<int, float, double> gObj2 = (x, y, z) =>
            {
                Console.WriteLine(x+y+z);
            };
            gObj2.Invoke(10, 10.0f, 10.00);

            Predicate<string> gObj3 = (str) =>
            {
                if (str.Length >= 3)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            };
            status = gObj3.Invoke("akad");
            Console.WriteLine(status);
            Console.ReadKey();
        }
    }
}
