using System;
using System.Collections.Generic;
using System.Text;

namespace BowlingGame.Models.Interface
{
    public interface ITour
    {
        int NbrDeTour { get; set; }
        int QuilleTombee { get; set; }
        int QuilleRestantes { get; set; }
    }
}
