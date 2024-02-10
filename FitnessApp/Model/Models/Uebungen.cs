using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Models
{
    public class Uebungen
    {
        public int uebung_id { get; set; }
        public string uebungname { get; set; }
        public List<Muskel> Muskeln { get; set; }
    }
}
