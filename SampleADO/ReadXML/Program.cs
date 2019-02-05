using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace ReadXML
{
    class Program
    {
        static void Main(string[] args)
        {
            XDocument xDoc = XDocument.Load(@"D:\dotnet\FILES\generatedMenu.xml");
            XElement element = xDoc.Root;

            var businessUnits = from node in element.Elements()
                where node.Name == "Americas"
                select node.Element("products").Element("bussinessunits");

            foreach (var businessUnit in businessUnits.Elements<XElement>())
            {
                Console.WriteLine("####################################");
                Console.WriteLine("Business Unit: "+businessUnit.Attribute("name").Value);
                Console.WriteLine("####################################");
                foreach (var product in businessUnit.Elements())
                {
                    Console.WriteLine(product.Attribute("name").Value);
                }
            }
            Console.ReadKey();
        }
    }
}
