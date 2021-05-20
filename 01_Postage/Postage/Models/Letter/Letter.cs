using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Postage
{
    public class Letter : BasePostable // les : définissent l'hériatage. Ici La lettre hérite de BasePostable
    {
        decimal weight = 0.05m; // variable statique disponible dans toute la class
        public Letter(string extLastName, string extFirstName, string extAdress) : base(extFirstName, extLastName, extAdress)
        {
            //this.weight = 0.05m; c'est la même chose que la déclaration de variable plus haut
        }
        public List<BasePage> ListBasePage { get; set; } = new List<BasePage>();
        //public override decimal Weight { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public override decimal Weight { get => this.ListBasePage.Sum(p => p.Weight) + weight; } // Somme de toutes les pages + l'enveloppe

    }

}
