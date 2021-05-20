using ReservationPlace.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace ReservationPlace.Models
{
    public class Coordonnees : INom, IPhone

    {
        //public string Nom { get; set; }
        //public string Adress { get; set; } 
        //public string Tel { get; set; }
        //public int CP { get; set; }
         public string Phone { get; set; }
        public string Nom { get; set; }
        public string Prenom { get; set; }
    }
}
