using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace Bataille
{
    public class Joueur
    {

        public Joueur(string firstName, string lastName)
        {
            this.FirstName = firstName;
            this.LastName = lastName;
        }

        public List<Card> JeuMain { get; set; } = new List<Card>();
        public List<Card> Plateau { get; set; } = new List<Card>();


        public string FirstName { get; private set; }
        public string LastName { get; private set; }
    }
}
