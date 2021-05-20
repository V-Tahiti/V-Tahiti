using System;
using System.Collections.Generic;
using System.Text;

namespace Postage
{
    public abstract class BasePage
    {
        #region Properties

        public decimal Weight { get; set; } /*si on écrit: public abstract Weight {get;}
                                            on force les héritiers à renseigner Weight*/
        public string Message { get; set; }
        #endregion

    }
}
