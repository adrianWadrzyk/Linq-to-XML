using System;
using System.Linq;
using System.Text;
using System.Xml.Linq;

namespace Linq_via_XML
{
    class Program
    {
        static void Main(string[] args)
        {
            var year = int.Parse(Console.ReadLine());

            StringBuilder s = new StringBuilder(); 
            string line;
            while ((line = Console.ReadLine()) != null && line != "")
            s.AppendLine(line);
            s.ToString();
            XDocument doc = XDocument.Parse(s.ToString());

            var data = doc.Descendants("Customer").Where(x => x.Elements("Orders").Elements("Order")
                .Where( z => DateTime.Parse(z.Element("OrderDate").Value).Year == year ).Any()
            );

            var result = data
                         .OrderBy(x => x.Element("Country").Value)
                         .ThenBy(x => x.Element("City").Value)
                         .ThenBy(x => x.Element("CompanyName").Value)        
                         .Select(x => x.Element("CompanyName").Value);
            result.ToList().ForEach(x => Console.WriteLine(x));
        }
    }
}
