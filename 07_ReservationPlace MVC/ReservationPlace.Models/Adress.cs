using ReservationPlace.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace ReservationPlace.Models
{
    /* On a créé une classe pour l'implémenter dans une interface de façon à simplifier les dépendences si on a oublié
    une propriété par la suite. Si on ajoute une nouvelle propriété, elle s'implémentera automatiquement dans l'interface qui 
    dépend de la classe et les autres classes qui dépendent de cette interface*/
    public class Adress : IAdressGenerique
    {
        public string Numero { get; set; }
        public string Rue { get; set; }
        public string Ville { get; set; }
        public string CP { get; set; }
        public string Pays { get; set; }
    }
}
