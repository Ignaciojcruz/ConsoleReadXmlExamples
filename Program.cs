using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;
using System.Xml.Serialization;

namespace ConsoleReadXml
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //EjemploReader();

            //EjemploDeserialize();

            EjemploXDocument();

            Console.ReadKey();
        }

        private static void EjemploReader()
        {
            String URLString = "http://localhost/ejemplo_flujo.xml";

            XmlTextReader reader = new XmlTextReader(URLString);
                        
            while (reader.Read())
            {
                //Console.WriteLine(reader.Name);

                switch (reader.NodeType)
                {
                    case XmlNodeType.None:
                        break;
                    case XmlNodeType.Element:   //The node is an element.
                        Console.Write("<" + reader.Name);

                        while (reader.MoveToNextAttribute())
                            Console.Write(" " + reader.Name + "='" + reader.Value + "'");
                        //Console.Write(">");
                        //Console.WriteLine(">");
                        break;
                    case XmlNodeType.Attribute:
                        break;
                    case XmlNodeType.Text:  //Display the text in each element.
                        //Console.WriteLine(reader.Value);
                        break;
                    case XmlNodeType.CDATA:                        
                        Console.WriteLine(reader.Name);
                        Console.WriteLine(reader.Value);
                        break;
                    case XmlNodeType.EntityReference:
                        break;
                    case XmlNodeType.Entity:
                        break;
                    case XmlNodeType.ProcessingInstruction:
                        break;
                    case XmlNodeType.Comment:
                        break;
                    case XmlNodeType.Document:
                        break;
                    case XmlNodeType.DocumentType:
                        break;
                    case XmlNodeType.DocumentFragment:
                        break;
                    case XmlNodeType.Notation:
                        break;
                    case XmlNodeType.Whitespace:
                        break;
                    case XmlNodeType.SignificantWhitespace:
                        break;
                    case XmlNodeType.EndElement:    //Display the end of the element
                        //Console.Write("</" + reader.Name);
                        //Console.WriteLine(">");
                        break;
                    case XmlNodeType.EndEntity:
                        break;
                    case XmlNodeType.XmlDeclaration:
                        break;
                    default:
                        break;
                }

            }
        }

        private static void EjemploDeserialize()
        {
            Result result;
            using (var xmlReader = XmlReader.Create("http://localhost/ejemplo_flujo.xml"))
            {
                xmlReader.ReadToFollowing("row");
                xmlReader.Read();

                using(var stringReader = new StringReader(xmlReader.Value))
                {
                    var xs = new XmlSerializer(typeof(Result));
                    result = (Result)xs.Deserialize(stringReader);
                }

            }

            Console.WriteLine(result.vta);
            Console.WriteLine(result.fecha_24);
                
        }

        private static void EjemploXDocument()
        {
            //XDocument xdoc = XDocument.Load("http://localhost/ejemplo_flujo.xml");
            //int cant = xdoc.DescendantNodes().OfType<XCData>().Count();

            XElement xElement = XElement.Load("http://localhost/ejemplo_flujo.xml");

            var queryCDATAXML = from element in xElement.DescendantNodes()
                                where element.NodeType == XmlNodeType.CDATA
                                select element.Parent.Value.Trim();
            string vta = queryCDATAXML.ToList<string>()[0].ToString();
            string fecha_actual = queryCDATAXML.ToList<string>()[1].ToString();
            string fecha_24 = queryCDATAXML.ToList<string>()[2].ToString();
            string fecha_48 = queryCDATAXML.ToList<string>()[3].ToString();
            string fecha_72 = queryCDATAXML.ToList<string>()[4].ToString();
            string fecha_mas_72 = queryCDATAXML.ToList<string>()[5].ToString();
            string total = queryCDATAXML.ToList<string>()[6].ToString();

            string valor = xElement.Value;
                                    
            Console.WriteLine("vta: " + vta);
            Console.WriteLine("fecha_actual: " + fecha_actual);
        }


    }
}
