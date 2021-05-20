using System;
using System.Collections.Generic;
using System.Text;

namespace Postage
{
    public class Cloth : BasePackage
    {
        decimal weight = 0.100m; // variable statique disponible dans toute la class

        public Cloth()
        {
            //this.weight = 0.05m; c'est la même chose que la déclaration de variable plus haut
        }
    }
}
