using BowlingGame.Models.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace BowlingGame.Models.Models
{
    public class TourSup : ITour

    {
        public int NbrDeTour { get ;set; }
        public int QuilleTombee { get; set; }
        public int NbrStrike { get; set; }
        public int QuilleRestantes { get; set; }
    }
}
