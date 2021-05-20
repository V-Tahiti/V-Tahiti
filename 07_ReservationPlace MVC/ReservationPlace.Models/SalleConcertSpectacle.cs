using ReservationPlace.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace ReservationPlace.Models
{
   public class SalleConcertSpectacle:IId
    {
        public SalleConcert SalleConcert { get; set; }
        public Spectacle Spectacle { get; set; }
        public DateTime Date { get; set; }
        public int Id { get; set ; }
    }
}
