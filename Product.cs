using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace testapp
{
    public class Product
    {
        public int id { get; set; }
        public string title { get; set; }
        public int producttypeid { get; set; }
        public int articlenumber { get; set; }
        public string image { get; set; }
        public int productionworkshopnumber { get; set; }
        public int mincostforagent { get; set; }
        public int productionpersoncount { get; set; }
    }
}
