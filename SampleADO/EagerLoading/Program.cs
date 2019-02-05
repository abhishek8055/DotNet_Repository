using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Linq;

namespace EagerLoading
{
    class Program
    {
        static void Main(string[] args)
        {
            //LAZY LOADING

            /*
            using (DataBaseDataContext dbContext = new DataBaseDataContext())
            {
                dbContext.Log = Console.Out;
                foreach (Department dept in dbContext.Departments)
                {
                    Console.WriteLine(dept.Name);
                    foreach (Employee emp in dept.Employees)
                    {
                        Console.WriteLine("\t"+emp.FirstName+" "+emp.LastName);
                    }
                }
                Console.ReadKey();
            }
            */


            //EAGER LOADING METHOD 1 (DATALOADOPTIONS)
            /*
            using (DataBaseDataContext dbContext = new DataBaseDataContext())
            {
                dbContext.Log = Console.Out;
                DataLoadOptions loadOptions = new DataLoadOptions();
                loadOptions.LoadWith<Department>(d => d.Employees);
                dbContext.LoadOptions = loadOptions;
                foreach (Department dept in dbContext.Departments)
                {
                    Console.WriteLine(dept.Name);
                    foreach (Employee emp in dept.Employees)
                    {
                        Console.WriteLine("\t" + emp.FirstName + " " + emp.LastName);
                    }
                }
                Console.ReadKey();
            }
            */

            //EAGER LOADING METHOD 2 (PROJECTION)
            using (DataBaseDataContext dbContext = new DataBaseDataContext())
            {
                dbContext.Log = Console.Out;

                var linqQuery = from dept in dbContext.Departments
                    select new
                    {
                        Name = dept.Name, Employees = dept.Employees
                    };

                foreach (var dept in linqQuery)
                {
                    Console.WriteLine(dept.Name);
                    foreach (Employee emp in dept.Employees)
                    {
                        Console.WriteLine("\t" + emp.FirstName + " " + emp.LastName);
                    }
                }
                Console.ReadKey();
            }
        }
    }
    
}
