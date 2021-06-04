using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestWeek3.Carrello.Classi
{
    public class Utente
    {
        public String Username { get; }
        public String Password { get; set; }
        public String Nome { get; set; }
        public String Cognome { get; set; }

        public CarrelloSpesa Carrello { get; } = new CarrelloSpesa();

        public Utente(string nome, string cognome, string username, string password)
        {
            Nome = nome;
            Cognome = cognome;
            Username = username;
            Password = password;
        }


    }
}
