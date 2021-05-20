using BowlingGame.Models.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace BowlingGame.Models.Models
{
    public class Tour : ITour
    {
        public int NbrDeTour { get ; set; }
        public int QuilleTombee { get ; set; }
        public int QuilleRestantes { get; set; } 
    }
}
