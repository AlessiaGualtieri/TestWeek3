using System;
using System.Collections.Generic;
using TestWeek3.Carrello.Classi;

namespace TestWeek3.Carrello
{
    class Program
    {
        public static List<Abbigliamento> abiti;
        public static List<Alimentare> cibo;
        public static List<Elettronica> elettro;


        static void Main(string[] args)
        {
            int scelta;
            CarrelloSpesa carrello = new CarrelloSpesa();

            CaricaProdottiSupermercato(out abiti, out cibo, out elettro);
            AccessoSito();
            do
            {
                StampaMenu();
                scelta = LeggiInputUtenteInt(1,5);
                while (scelta < 1 || scelta > 5);
                AnalizzaScelta(scelta, carrello);

            } while (scelta != 5);
        }

        public static void AccessoSito()
        {
            Console.WriteLine("Benvenuto su SSSSLUNGA!\n" +
                "Esegui l'accesso al sito:");

            Console.Write("Username:\t");
            //////////////////////////////////////////////
            Console.Write("Password:\t");
            /////////////////////////////////////////

        }

        public static void StampaMenu()
        {
            Console.WriteLine("\n----- Menù -----\n" +
                "1 - Aggiungi un prodotto al carrello\n" +
                "2 - Elimina un prodotto dal carrello\n" +
                "3 - Modifica la quantità di un prodotto già inserito\n" +
                "4 - Stampa a video il riepilogo del carrello\n" +
                "5 - Esci\n");
        }

        public static int LeggiInputUtenteInt()
        {
            bool succ;
            int scelta;
            succ = Int32.TryParse(Console.ReadLine(), out scelta);
            while(!succ)
            {
                Console.WriteLine("Errore. Valore inserito non opportuno. Riprovare.");
                succ = Int32.TryParse(Console.ReadLine(), out scelta);
            }

            return scelta;
        }

        public static int LeggiInputUtenteInt(int min, int max)
        {
            int scelta;
            do
            {
                scelta = LeggiInputUtenteInt();
                if (scelta < min || scelta > max)
                    Console.Write("Errore. Valore inserito non opportuno. Riprovare:");
            }
            while (scelta < min || scelta > max);
            return scelta;
        }

        public static void AnalizzaScelta(int scelta, CarrelloSpesa carrello)
        {
            switch(scelta)
            {
                case 1:
                    AggiungiProdotto(carrello);
                    break;
                case 2:
                    EliminaProdotto(carrello);
                    break;
                case 3:
                    ModificaQuantitaProdotto(carrello);
                    break;
                case 4:
                    StampaCarrello(carrello);
                    break;
            }

        }

        public static void AggiungiProdotto(CarrelloSpesa carrello)
        {
            int scelta;
            Prodotto p;
            Console.WriteLine("Inserire i dati del prodotto che si vuole inserire:");
            Console.WriteLine("Che tipo di prodotto deve essere?\n" +
                "1 - Abbigliamento\n" +
                "2 - Alimentare\n" +
                "3 - Elettronica\n");
            scelta = LeggiInputUtenteInt(1,3);

            Console.WriteLine("Seleziona tra i seguenti prodotti quello che desideri:");
            switch(scelta)
            {
                case 1:
                    p = new Abbigliamento();
                    SceltaProdotto(abiti, carrello);
                    break;
                case 2:
                    p = new Alimentare();
                    SceltaProdotto(cibo, carrello);
                    break;
                case 3:
                    p = new Elettronica();
                    SceltaProdotto(elettro, carrello);
                    break;
            }

        }

        public static void SceltaProdotto<T>(List<T> lista, CarrelloSpesa carrello)
            where T: Prodotto
        {
            int i = 1, scelta;
            int quantita;

            foreach (T a in lista)
            {
                Console.WriteLine(i + ")\n" + a);
                i++;
            }

            scelta = LeggiInputUtenteInt(1, lista.Count);

            Console.Write("Che quantità vuoi di questo prodotto?\t");
            quantita = LeggiInputUtenteInt(1, 500);

            carrello.AggiungiProdotto(lista[scelta - 1], quantita);
            Console.WriteLine("Prodotto aggiunto con successo\n");
        
        }

        public static void EliminaProdotto(CarrelloSpesa carrello)
        {
            int i = 1;
            int scelta;
            bool eliminazione;

            if(carrello.Ordine.Count == 0)
            {
                Console.WriteLine("Il carrello è vuoto, aggiungere prima prodotti.");
                return;
            }

            Console.WriteLine("\nIl carrello contiene:\n");
            
            foreach(ProdottoCarrello p in carrello.Ordine)
            {
                Console.WriteLine(i + ")\n" + p.ToString());
                i++;
            }

            Console.WriteLine("Quale elemento vuoi eliminare?");
            scelta = LeggiInputUtenteInt(1,carrello.Ordine.Count);

            eliminazione = carrello.EliminaProdotto(scelta - 1);
            if (eliminazione)
                Console.WriteLine("Prodotto eliminato correttamente.");
            else
                Console.WriteLine("Impossibile elimanre il prodotto. Non presente nel carrello.");
        }

        public static void ModificaQuantitaProdotto(CarrelloSpesa carrello)
        {
            int i = 1;
            int scelta;
            int nuovaQuantita;

            if (carrello.Ordine.Count == 0)
            {
                Console.WriteLine("Il carrello è vuoto, aggiungere prima prodotti.");
                return;
            }

            Console.WriteLine("\nIl carrello contiene:\n");

            foreach (ProdottoCarrello p in carrello.Ordine)
            {
                Console.WriteLine(i + ")\n" + p.ToString());
                i++;
            }

            Console.Write("Di quale elemento vuoi modificare la quantità?");
            scelta = LeggiInputUtenteInt(1, carrello.Ordine.Count);

            Console.Write("Inserisci nuova quantità del prodotto: ");
            nuovaQuantita = LeggiInputUtenteInt(1, 500);

            carrello.ModificaQuantitaProdotto(scelta - 1, nuovaQuantita);

            Console.WriteLine("Quantità del prodotto modificata correttamente.");

        }

        public static void StampaCarrello(CarrelloSpesa carrello)
        {
            double prezzoTotale = 0;
            double prezzoTotaleScontato = 0;

            Console.WriteLine("\nIl carrello contiene:\n");
            Console.WriteLine(carrello.ToString());

            foreach(ProdottoCarrello p in carrello.Ordine)
            {
                prezzoTotale += p.PrezzoTotale;
                prezzoTotaleScontato += p.PrezzoTotaleScontato;
            }

            Console.WriteLine("\n\n\n" +
                $"Prezzo totale: {prezzoTotale}\n" +
                $"Prezzo con saldo: {prezzoTotaleScontato}\n");
        }

        public static void CaricaProdottiSupermercato(out List<Abbigliamento> abiti, out List<Alimentare> cibo, out List<Elettronica> elettro)
        {
            abiti = new List<Abbigliamento>();
            cibo = new List<Alimentare>();
            elettro = new List<Elettronica>();

            abiti.Add(new Abbigliamento("123412", "Maglia", 17.40, "S", "Max", 0.15));
            abiti.Add(new Abbigliamento("as2351", "Maglia", 17.40, "M", "Max", 0.15));
            abiti.Add(new Abbigliamento("sad1245", "Maglia", 17.40, "L", "Max", 0.15));
            abiti.Add(new Abbigliamento("19852", "Pantalone", 24, "38", "Bluesand"));
            abiti.Add(new Abbigliamento("12984", "Pantalone", 24, "40", "Bluesand"));
            abiti.Add(new Abbigliamento("12452", "Pantalone", 24, "42", "Bluesand"));

            cibo.Add(new Alimentare("23895012", "Pasta", 1.12, new DateTime(07/11/2021)));
            cibo.Add(new Alimentare("38949214", "Sugo", 3.15, new DateTime(09/11/2021)));
            cibo.Add(new Alimentare("asdf90234", "Cetrioli", 0.5, new DateTime(06 / 06 / 2021)));

            elettro.Add(new Elettronica("1389409345", "Disco", 13.2, "mao", 0.7));
            elettro.Add(new Elettronica("asd823324", "PC", 431.20, "lenovo", 0.1));

        }
    }
}
