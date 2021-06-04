using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestWeek3.Carrello.Classi
{
    public class Abbigliamento : Prodotto
    {
        public String Taglia { get; set; }
        public String Brand { get; set; }

        public Abbigliamento() { }
        public Abbigliamento(string codice, string descrizione, double prezzo, string taglia, string brand, double sconto = 0) : base(codice, descrizione, prezzo, sconto)
        {
            Taglia = taglia;
            Brand = brand;
        }

    }
}
