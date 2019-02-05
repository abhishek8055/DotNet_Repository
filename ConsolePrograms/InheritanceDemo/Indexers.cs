using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InheritanceDemo
{
    class Indexers
    {
        int Id;
        string Name;
        int Age;

        public Indexers(int id, string name, int age)
        {
            this.Id = id;
            this.Name = name;
            this.Age = age;
        }

        public object this[int index]
        {
            get
            {
                if(index == 1)
                {
                    return Id;
                }
                if (index == 2)
                {
                    return Name;
                }
                if (index == 3)
                {
                    return Age;
                }
                return null;
            }
            set
            {
                if (index == 1)
                {
                    Id = (int)value;
                }
                if (index == 2)
                {
                    Name = (string)value;
                }
                if (index == 3)
                {
                    Age = (int)value;
                }
            }
        }
        
    }

    class Consumer
    {
        static void Main()
        {
            Indexers idx = new Indexers(1, "Ram", 23);
            Console.WriteLine(idx[1]);
            Console.WriteLine(idx[2]);
            Console.WriteLine(idx[3]);
            idx[1] = 2;
            idx[2] = "Shyam";
            idx[3] = 29;
            Console.WriteLine(idx[1]);
            Console.WriteLine(idx[2]);
            Console.WriteLine(idx[3]);
            Console.ReadKey();
        }
    }
}
