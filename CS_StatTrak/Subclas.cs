using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace CS_StatTrak
{
    public class Subclas
    {



    }

    public class Tablelist
    {
        public Tablelist(string Nameid, string patch, string nameimage)
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
