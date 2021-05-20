using ReservationPlace.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace ReservationPlace.Models
{
    public class SalleConcertSpectacleSpectateur : IId

    {
        public SalleConcertSpectacle SalleConcertSpectacle { get; set; }
        public Spectateur Spectateur { get; set; }
        public SalleSiege SalleSiege { get; set; }
        public int Id { get; set; }
    }
}
