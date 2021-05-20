using System;
using System.Collections.Generic;
using System.Text;

namespace Postage
{
    public class Toy : BasePackage
    {
        decimal weight = 0.300m; // variable statique disponible dans toute la class

        public Toy()
        {
            //this.weight = 0.05m; c'est la même chose que la déclaration de variable plus haut

        }
    }
}
