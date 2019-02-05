using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace LINQtoXML
{
    class Program
    {
        static void Main(string[] args)
        {
            XDocument xDoc = XDocument.Load(@"D:\dotnet\FILES\generatedMenu.xml");
            XElement element = xDoc.Root;

            var industries = from node in element.Elements()
                where node.Name == "Americas"
                select node.Element("industries");

            foreach (var industry in industries.Elements<XElement>())
            {
                foreach (var item in industry.Elements())
                {
                    Console.WriteLine(item.Attribute("name").Value);
                }
                Console.ReadKey();
            }
        }
        
    }
}
