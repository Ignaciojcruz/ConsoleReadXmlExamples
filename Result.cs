using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace ConsoleReadXml
{
    [XmlRoot("result")]
    public class Result
    {
        public string vta;
        public string fecha_actual;
        public string fecha_24;
        public string fecha_48;
        public string fecha_72;
        public string fecha_mas_72;
    }
}
