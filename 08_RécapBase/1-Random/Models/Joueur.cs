using _1_Random.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace _1_Random.Models
{
    public class Joueur
    {
        public Joueur(string name, Sexes sex)
        {
            this.Name = name;
            this.Sex = sex;
        }
        
        
        //raccourci pour rapeler le 1er constructeur
        public Joueur(string name, Sexes sex, int dossard) : this(name, sex) 
        {
            this.Dossard = dossard;
        }

        public string Name { get; private set; }
        public Sexes Sex { get; private set; }

        public int Dossard { get; set; } //Dossard = bib


    }
}
