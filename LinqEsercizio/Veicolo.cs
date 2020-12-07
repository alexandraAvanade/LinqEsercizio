using System;
using System.Collections.Generic;
using System.Text;

namespace LinqEsercizio
{
    public class Veicolo
    {
        public int Id { get; set; }
        public string Targa { get; set; }
        public int Peso { get; set; }
        public string Colore { get; set; }
        public double Prezzo { get; set; }
        public int ProprietarioId { get; set; }
       
    }
}
