using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LinqEsercizio
{
    public class Esercizi
    {
        public static List<Persona> CreatePersonaList()
        {
            var list = new List<Persona>
            {
                new Persona{Id =1, Nome = "Alex", Cognome = "Alezzander", Nazione="Americano"},
                new Persona{Id =2, Nome = "Tia", Cognome = "Taylor", Nazione="Canadiana"},
                new Persona{Id =3, Nome = "Fred", Cognome = "McDreamy", Nazione="Austaliano"},
                new Persona { Id = 4, Nome = "Roberto", Cognome = "Ajolfi", Nazione = "Italia" },
                new Persona { Id = 5, Nome = "Alice", Cognome = "Colella", Nazione = "Italia" },
                new Persona { Id = 6, Nome = "Paolo", Cognome = "Rossi", Nazione = "Italia" },
                new Persona { Id = 7, Nome = "Mario", Cognome = "Bianchi", Nazione = "Italia" },
            };
            return list;
        }

        public static List<Veicolo> CreateVeicoloList()
        {
            var list = new List<Veicolo>
            {
                new Veicolo{Id=1,Targa="FG568EF", Peso = 1000, Colore ="Blue", Prezzo = 10000.00,ProprietarioId =1 },
                new Veicolo{Id=2,Targa="CC567ER", Peso = 800, Colore ="Nero", Prezzo = 15000.00,ProprietarioId =3 },
                new Veicolo{Id=3,Targa="GA456CC", Peso = 1000, Colore ="Bianco", Prezzo = 9000.00,ProprietarioId =3 },
                new Veicolo { Id = 1, Colore = "Rosso", Peso = 1000, Prezzo = 1000, Targa = "YC888ZZ", ProprietarioId = 1 },
                new Veicolo { Id = 2, Colore = "Rosso", Peso = 1200, Prezzo = 2000, Targa = "AA967OP", ProprietarioId = 1 },
                new Veicolo { Id = 3, Colore = "Grigio", Peso = 500, Prezzo = 700, Targa = "ND999AA", ProprietarioId = 2 },
                new Veicolo { Id = 4, Colore = "Nero", Peso = 900, Prezzo = 1500, Targa = "HK086KK", ProprietarioId = 4 },
                new Veicolo { Id = 5, Colore = "Verde", Peso = 1900, Prezzo = 3000, Targa = "ZA876AA", ProprietarioId = 4 }
            };
            return list;
        }
        public static void Liste()
        {
            var personatList = CreatePersonaList();
            var veicoloList = CreateVeicoloList();

            Console.WriteLine("");
            Console.WriteLine("Persone: ");

            foreach (var p in personatList)
            {
                Console.WriteLine("{0}  {1} {2} {3}", p.Id, p.Nome, p.Cognome, p.Nazione);
            }
            Console.WriteLine("");
            Console.WriteLine("Veicoli: ");

            foreach (var v in veicoloList)
            {
                Console.WriteLine("{0}  {1} {2} {3} {4}", v.Targa, v.Peso, v.Colore, v.Prezzo, v.ProprietarioId);
            }
        }

        public static void Peso()
        {

            var veicoloList = CreateVeicoloList();
            var personaList = CreatePersonaList();

            var sumQuantityByPeso =
               from v in veicoloList
               group v by v.ProprietarioId into list3
               select new { Id = list3.Key, Peso = list3.Sum(x => x.Peso) };
            Console.WriteLine("");
            Console.WriteLine("Peso complessivo by persona");
            foreach (var item in sumQuantityByPeso)
            {
                Console.WriteLine("{0} {1}", item.Id, item.Peso);
            }

            //Alice
            //var macchinePerColoreMethod = veicoloList.GroupBy(v => v.Colore, (key, v) => new { Colore = key, Count = v.Count() });


            //var prezzoMedioEPesoComplessivoQuery = from v in veicoloList
            //                                       group v by v.ProprietarioId into vpp
            //                                       select new
            //                                       {
            //                                           PersonaId = vpp.Key,
            //                                           PesoComplessivo = vpp.Sum(v => v.Peso),
            //                                           PrezzoMedio = vpp.Average(v => v.Prezzo)
            //                                       };
            //Console.WriteLine("Peso ");
            //foreach (var item in prezzoMedioEPesoComplessivoQuery)
            //{
            //    Console.WriteLine("{0} ", item.PesoComplessivo);
            //}



            //var prezzoMedioEPesoComplessivoMethod2 = personaList.GroupJoin(
            //   veicoloList,
            //   p => p.Id,
            //   v => v.ProprietarioId,
            //   (p, v) => new
            //   {
            //       PersonaId = p.Id,
            //       Nome = $"{p.Cognome} {p.Nome}",
            //       PesoComplessivo = v.Any() ? v.Sum(v => v.Peso) : 0,   // <== necessari perchè GroupJoin restituisce comunque record anche dove non c'è corrispondenza
            //        PrezzoMedio = v.Any() ? v.Average(v => v.Prezzo) : 0    // <==
            //    }).ToList();

            //foreach (var item in prezzoMedioEPesoComplessivoMethod2)
            //    Console.WriteLine($"[{item.PersonaId}] {item.Nome} => Peso Complessivo: {item.PesoComplessivo} / Prezzo Medio: {item.PrezzoMedio}");

            //Console.WriteLine("=================================");
            //Console.WriteLine();
        }



        public static void PrezzoMedio()
        {
            var personatList = CreatePersonaList();
            var veicoloList = CreateVeicoloList();

            var prezzoMedioVeicoloByPersona =
              from p in veicoloList
              group p by p.ProprietarioId into list4
              select new { Id = list4.Key, PrezzoMedio = list4.Average(x => x.Peso) };

            Console.WriteLine("");
            Console.WriteLine("Prezzo Medio by Persona");
            foreach (var item in prezzoMedioVeicoloByPersona)
            {
                Console.WriteLine("{0} {1}", item.Id, item.PrezzoMedio);
            }
        }
        //Scrivere una query LINQ che restituisca Peso complessivo e Prezzo Medio dei Veicoli posseduti da ciascuna Persona
        public static void PrezzoPeso()
        {
            var personaList = CreatePersonaList();
            var veicoloList = CreateVeicoloList();

            var prezzoMedioEPesoComplessivoQuery2 = from v in veicoloList
                                                    group v by v.ProprietarioId into vpp
                                                    join p in personaList on vpp.Key equals p.Id
                                                    select new
                                                    {
                                                        PersonaId = vpp.Key,
                                                        Nome = $"{p.Cognome} {p.Nome}",
                                                        PesoComplessivo = vpp.Sum(v => v.Peso),
                                                        PrezzoMedio = vpp.Average(v => v.Prezzo)
                                                    };
            Console.WriteLine("");
            Console.WriteLine("Tutto insieme");
            foreach (var item in prezzoMedioEPesoComplessivoQuery2)
            {
                Console.WriteLine($"[{item.PersonaId}] {item.Nome} => Peso Complessivo: {item.PesoComplessivo} / Prezzo Medio: {item.PrezzoMedio}");
            }
        }

       // Scrivere un extension method della classe Persona(VeicoliPosseduti(List<Veicoli> elencoVeicoli) ) che restituisca l’elenco dei veicoli posseduti(campi: ID, Targa, Prezzo)
       public static void ElencoLista()
        {
            var personaList = CreatePersonaList();
            var veicoloList = CreateVeicoloList();
            Console.WriteLine();
            Console.WriteLine("Lista Veicoli di ogni persona: ");

            foreach (var p in personaList)
            {
                Console.WriteLine($"== Veicoli di {p.Nome} {p.Cognome} ==");
                foreach (var item in p.VeicoliPosseduti(veicoloList))
                    Console.WriteLine($"{item.ID} - {item.Targa} - {item.Prezzo}");
                Console.WriteLine("====");
            }

            Console.WriteLine("=================================");
            Console.WriteLine();

        }
    }
}


