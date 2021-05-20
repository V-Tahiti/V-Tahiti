using BowlingGame.Models.Enums;
using BowlingGame.Models.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BowlingGame.Models.Models
{
    public class Manche
    {

        public int NbrDeManche { get; set; }
        public int Points { get; set; }
        public List<ITour> Tours { get; set; } = new List<ITour>();
        public bool Strike { get { return this.Tours.Count() == 1 && this.Tours.Sum(t => t.QuilleTombee) == 9; } }
        public bool Spare { get { return this.Tours.Count() == 2 && this.Tours.Sum(t => t.QuilleTombee) == 9; } }
        public SizeType Boule { get; set; }
    }
}
