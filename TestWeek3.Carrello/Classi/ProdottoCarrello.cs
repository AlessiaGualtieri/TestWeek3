using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestWeek3.Carrello.Classi
{
    public class ProdottoCarrello
    {
        public Prodotto Prodotto { get; set; }
        public int Quantita { get; set; }
        public double PrezzoTotale { get { return Quantita * Prodotto.Prezzo; } }

        public double PrezzoTotaleScontato { get { return PrezzoTotale - PrezzoTotale * Prodotto.PercentualeSconto; } }
        
        public ProdottoCarrello(Prodotto prodotto, int quantita)
        {
            Prodotto = prodotto;
            Quantita = quantita;
        }

        public bool IsAggiungiProdotto(Prodotto prodotto, int quantita)
        {
            if (Prodotto.Equals(prodotto))
            {
                Quantita += quantita;
                return true;
            }
            return false;
        }

        public void ModificaQuantitaProdotto(int nuovaQuantita)
        {
            this.Quantita = nuovaQuantita;
        }

        public override string ToString()
        {
            return $"Prodotto: {Prodotto.ToString()}\n" +
                $"Quantità: {Quantita}\n" +
                $"Prezzo totale: {PrezzoTotale} euro\n" +
                $"Prezzo con saldo: {PrezzoTotaleScontato} euro\n";
        }

    }
}
