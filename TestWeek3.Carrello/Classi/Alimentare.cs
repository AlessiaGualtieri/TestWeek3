using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestWeek3.Carrello.Classi
{
    public class Alimentare : Prodotto
    {
        public DateTime DataScadenza { get; set; }

        public Alimentare() { }
        public Alimentare(string codice, string descrizione, double prezzo, DateTime dataScadenza, double sconto = 0) : base(codice,descrizione,prezzo,sconto)
        {
            DataScadenza = dataScadenza;
        }


    }
}
