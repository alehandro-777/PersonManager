using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace PersonManager.Data.Entities
{
    public class Telefonverbindung
    {
        public int TelefonverbindungId { get; set; }

        public string Nummer { get; set; } = null!;

        public int PersonId { get; set; }
        
        public Person Person { get; set; } = null!;
    }

}
