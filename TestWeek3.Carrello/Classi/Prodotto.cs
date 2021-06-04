using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace TestWeek3.Carrello.Classi
{
    public abstract class Prodotto
    {
        public string Codice { get; set; }
        public string Descrizione { get; set; }
        public double Prezzo { get; set; }
        public double PercentualeSconto { get; set; }

        public Prodotto()
        {

        }

        public Prodotto(string codice, string descrizione, double prezzo, double sconto = 0)
        {
            Codice = codice;
            Descrizione = descrizione;
            Prezzo = prezzo;
            PercentualeSconto = sconto;
        }

        public override bool Equals(object obj)
        {
            if (!(obj is Prodotto))
                return false;
            Prodotto p = (Prodotto)obj;

            if (this.Codice.Equals(p.Codice) &&
                 this.Descrizione.Equals(p.Descrizione) &&
                 (this.Prezzo == p.Prezzo) &&
                 (this.PercentualeSconto == p.PercentualeSconto))
                return true;
            else if (this.Codice.Equals(p.Codice))
                throw new Exception("Errore. Sono presenti due prodotti con stesso codice ma con altri campi diversi.");
            return false;
        }


        public override string ToString()
        {
            return $"Descrizione: {Descrizione}\n" +
                $"Prezzo: {Prezzo} euro\n" +
                $"Sconto percentuale: {PercentualeSconto}";
        }

    }
}
