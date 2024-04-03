using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KukaPositionParser.Core
{
    public class Position
    {
        public string Name { get;  set; }
        public string Raw { get;  }
        public string Filename { get; }
            
        public Position(string filename,string raw)
        {
            Filename= filename;
            Raw= raw;
        }

        public double E1 { get; set; }
        public double E2 { get; set; }
        public double E3 { get; set; }
        public double E4 { get; set; }
        public double E5 { get; set; }
        public double E6 { get; set; }
    }

   
}
