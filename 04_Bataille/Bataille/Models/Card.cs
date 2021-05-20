using System;
using System.Collections.Generic;
using System.Text;

namespace Bataille
{
    public class Card 
    {
        /*-------------Constructeur----------------*/
        // Les cartes auront 2 types povenant des "enum" 1 couleur et 1 force
        public Card(ForceType extforce, CouleurType extCouleur)
        {
            this.Force = extforce;
            this.Couleurs = extCouleur;
        }
        public ForceType Force { get; set; }
        public CouleurType Couleurs { get; set; }

    }
}
