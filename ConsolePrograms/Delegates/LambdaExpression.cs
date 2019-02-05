using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Delegates
{
    class LambdaExpression
    {
        static void Main()
        {
            LambdaExpression bd = new LambdaExpression();

            DelegateAddNumns1 del1 = (int x, float y, double z) =>
            {
                return x + y + z;
            };

            double result = del1.Invoke(10, 12.3f, 123.89);
            Console.WriteLine(result);

            DelegateAddNumns2 del2 = (int x, float y, double z) =>
            {
                Console.WriteLine(x + y + z);
            };
            del2.Invoke(10, 12.3f, 123.89);

            DelegateTestlength del3 = (string str) =>
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
            bool status = del3.Invoke("abhi");
            Console.WriteLine(status);
            Console.ReadKey();
        }
    }
}
