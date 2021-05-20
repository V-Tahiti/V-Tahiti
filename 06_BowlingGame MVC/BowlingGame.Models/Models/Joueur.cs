using BowlingGame.Models.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BowlingGame.Models.Models
{
    public class Joueur
    {
        
        public Joueur(string name, ForceType force)
        {
            this.Name = name;
            this.Force = force;
        }

        public string Name { get; set; }
        public ForceType Force { get; set; }
        public List<Manche> Manches { get; set; } = new List<Manche>();
        public int SommeTotalPoint { get { return this.Manches.Sum(p => p.Points); } }

    }
}
