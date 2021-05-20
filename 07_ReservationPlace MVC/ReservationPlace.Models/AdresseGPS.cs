using System;
using System.Collections.Generic;
using System.Text;

namespace ReservationPlace.Models
{
    public class AdresseGPS : Adress
    {
        public string Latitude { get; set; }
        public string Longitude { get; set; }
    }
}
