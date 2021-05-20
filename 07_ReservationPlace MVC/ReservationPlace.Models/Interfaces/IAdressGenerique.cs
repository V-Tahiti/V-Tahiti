using System;
using System.Collections.Generic;
using System.Text;

namespace ReservationPlace.Models.Interfaces
{
    public interface IAdressGenerique
    {
        string Numero { get; set; } // numéro bis "ex: 25 bis" donc en string
        string Rue { get; set; } 
        string Ville { get; set; }
        string CP { get; set; }
        string Pays { get; set; }
    }
}
