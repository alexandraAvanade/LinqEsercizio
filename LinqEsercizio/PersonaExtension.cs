using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LinqEsercizio
{
    public static class PersonaExtension
    {
        public static List<VeicoliPosseduti> VeicoliPosseduti(this Persona persona, List<Veicolo> elencoVeicoli)
        {
            //var resultMethod = elencoVeicoli
            //    .Where(v => v.ProprietarioID == persona.ID)
            //    .Select(v => new VeicoliPosseduti { ID = v.ID, Targa = v.Targa, Prezzo = v.Prezzo })
            //    .ToList();

            //return resultMethod;

            var resultQuery = (from v in elencoVeicoli
                               where v.ProprietarioId == persona.Id
                               select new VeicoliPosseduti { ID = v.Id, Targa = v.Targa, Prezzo = (decimal)v.Prezzo }).ToList();

            return resultQuery;
        }
    }
}
namespace LinqEsercizio { 


    public class VeicoliPosseduti
    {
        public int ID { get; set; }
        public string Targa { get; set; }
        public decimal Prezzo { get; set; }
    }
}

