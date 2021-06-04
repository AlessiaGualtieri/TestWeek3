using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestWeek3.Carrello.Classi
{
    public class Elettronica : Prodotto
    {
        public String Produttore { get; set; }

        public Elettronica() { }
        public Elettronica(string codice, string descrizione, double prezzo, string produttore, double sconto = 0) : base(codice, descrizione, prezzo, sconto)
        {
            Produttore = produttore;
        }

    }
}
