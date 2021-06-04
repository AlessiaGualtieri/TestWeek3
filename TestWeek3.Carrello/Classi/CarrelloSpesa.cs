using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestWeek3.Carrello.Classi
{
    public class CarrelloSpesa
    {
        public IList<ProdottoCarrello> Ordine { get; } = new List<ProdottoCarrello>();

        public double PrezzoDaPagare 
        { 
            get 
            {
                double prezzo = 0;
                foreach (ProdottoCarrello p in Ordine)
                    prezzo += p.PrezzoTotaleScontato;
                return prezzo;
            } 
        }

        public void AggiungiProdotto(Prodotto prodotto, int quantita)
        {
            foreach(ProdottoCarrello p in Ordine)
                if (p.IsAggiungiProdotto(prodotto, quantita))
                    return;

            ProdottoCarrello prodottoCarrello = new ProdottoCarrello(prodotto, quantita);
            Ordine.Add(prodottoCarrello);
        }

        public bool EliminaProdotto(Prodotto prodotto)
        {
            foreach (ProdottoCarrello p in Ordine)
                if (p.Prodotto.Equals(prodotto))
                { 
                    Ordine.Remove(p);
                    return true;
                }
            return false;
        }

        public bool EliminaProdotto(int index)
        {
            try
            {
                Ordine.RemoveAt(index);
                return true;
            } catch(ArgumentOutOfRangeException)
            {
                return false;
            }
        }


        public void ModificaQuantitaProdotto(int index, int nuovaQuantita)
        {
            this.Ordine[index].ModificaQuantitaProdotto(nuovaQuantita);
        }

        public override string ToString()
        {
            string s = "";
            foreach (ProdottoCarrello p in Ordine)
                s += p.ToString();
            return s;
        }
    }

}
