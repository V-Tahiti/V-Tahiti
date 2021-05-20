using ReservationPlace.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace ReservationPlace.Models
{
    public class SalleSiege : IId
    {
        public Siege siege { get; set; }
        public SalleConcert salleConcert { get; set; }
        public int Id { get; set; }
    }
}
