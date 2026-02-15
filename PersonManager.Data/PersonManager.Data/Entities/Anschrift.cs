using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace PersonManager.Data.Entities
{
    public class Anschrift
    {
        public int AnschriftId { get; set; }

        public string Ort { get; set; } = null!;
        public string Strasse { get; set; } = null!;
        public string Hausnummer { get; set; } = null!;
        public string Postleitzahl { get; set; } = null!;

        public int PersonId { get; set; }
        
        public Person Person { get; set; } = null!;
    }

}
