using FireGame.Model.Enums;
using System;

namespace FireGame.Model
{
    public class Player
    {
        public Player(string name, Sexes sex)
        {
            this.Name = name;
            this.Sex = sex;
        }
        public Player(string name, Sexes sex, int bib):this(name,sex) // rappelle le constructeur du haut et remplace 
                                                            // this.Name = name; et this.Sex = sex  
        {
            this.Bib = bib;
        }

        public string Name { get; private set; }
        public Sexes Sex { get; private set; }

        public int Bib { get; set; } //Dossard

        public int Points { get; set; }
    }
}
