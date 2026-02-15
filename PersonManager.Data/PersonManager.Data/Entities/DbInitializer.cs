using System;
using System.Collections.Generic;
using System.Linq;
using PersonManager.Data.Entities;

namespace PersonManager.Data.Entities
{
    public static class DbInitializer
    {
        public static void Seed(PersonDbContext context)
        {
            if (context.Persons.Any())
                return; // data already exists

            var random = new Random();

            var firstNames = new[] { "Max", "Anna", "Peter", "Laura", "Jan", "Lena", "Tom", "Sophie", "Felix", "Clara" };
            var lastNames = new[] { "Müller", "Schmidt", "Meier", "Fischer", "Weber", "Becker", "Hoffmann", "Klein", "Wolf", "Neumann" };
            var cities = new[] { "Dresden", "Leipzig", "Berlin", "München", "Hamburg", "Köln", "Frankfurt", "Stuttgart" };
            var streets = new[] { "Hauptstr.", "Bahnhofstr.", "Friedrichstr.", "Marienplatz", "Jungfernstieg", "Goethestr.", "Schillerstr." };

            var persons = new List<Person>();
            var addresses = new List<Anschrift>();
            var phoneNumbers = new List<Telefonverbindung>();

            for (int i = 0; i < 100; i++)
            {
                var person = new Person
                {
                    Name = lastNames[random.Next(lastNames.Length)],
                    Vorname = firstNames[random.Next(firstNames.Length)],
                    Geburtsdatum = new DateTime(random.Next(1960, 2005), random.Next(1, 13), random.Next(1, 28))
                };

                persons.Add(person);
            }

            context.Persons.AddRange(persons);
            context.SaveChanges(); // save to generate PersonId

            foreach (var person in persons)
            {
                // 1-3 addresses per person
                int addrCount = random.Next(1, 4);
                for (int j = 0; j < addrCount; j++)
                {
                    addresses.Add(new Anschrift
                    {
                        PersonId = person.PersonId,
                        Ort = cities[random.Next(cities.Length)],
                        Strasse = streets[random.Next(streets.Length)],
                        Hausnummer = random.Next(1, 50).ToString(),
                        Postleitzahl = random.Next(10000, 99999).ToString()
                    });
                }

                // 1-3 phone numbers per person
                int phoneCount = random.Next(1, 4);
                for (int k = 0; k < phoneCount; k++)
                {
                    // 70% chance the number starts with 0 or +
                    bool validNumber = random.NextDouble() < 0.7;

                    string number;
                    if (validNumber)
                    {
                        number = random.Next(0, 2) == 0
                            ? "0" + random.Next(1000000, 9999999)
                            : "+" + random.Next(491000000, 491999999);
                    }
                    else
                    {
                        number = random.Next(1000000, 9999999).ToString(); // for DELETE test
                    }

                    phoneNumbers.Add(new Telefonverbindung
                    {
                        PersonId = person.PersonId,
                        Nummer = number
                    });
                }
            }

            context.Anschriften.AddRange(addresses);
            context.Telefonverbindungen.AddRange(phoneNumbers);

            context.SaveChanges();
        }
    }
}
