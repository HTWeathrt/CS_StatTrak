using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VP_CS2
{
    public class Tablelist
    {
        public Tablelist(string Nameid, string patch,string nameimage)
        {
            this.NameID = Nameid;
            this.Patch = patch;
            this.NameImage = nameimage;
        }
        public string NameID { get; set; }
        public string Patch { get; set; }
        public string NameImage { get; set; }

    }
}
