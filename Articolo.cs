using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace back_end_s3_l05
{
    public class Articolo
    {
        public string Codice { get; set; }
        public string Nome { get; set; }
        public string Descrizione { get; set; }
        public decimal Prezzo { get; set; }

        public Articolo(string codice, string nome, string descrizione, decimal prezzo)
        {
            Codice = codice;
            Nome = nome;
            Descrizione = descrizione;
            Prezzo = prezzo;
        }
    }
}