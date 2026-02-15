using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonManager.Data.Entities
{
    public class Person
    {
        public int PersonId { get; set; }

        public string Name { get; set; } = null!;
        public string Vorname { get; set; } = null!;
        public DateTime Geburtsdatum { get; set; }

        public List<Anschrift> Anschriften { get; set; } = new();
        public List<Telefonverbindung> Telefonnummern { get; set; } = new();
    }

}
