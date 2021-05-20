using System;
using System.Collections.Generic;
using System.Text;

namespace Postage
{
    public class Package : BasePostable
    {
        decimal weight = 0.50m;
        public Package(string extFirstName, string extLastName, string extAdress) : base(extFirstName, extLastName, extAdress)
        {

        }
        /* Je cherche */
        public List<BasePackage> ListBasePackage { get; set; } = new List<BasePackage>();

        public override decimal Weight => throw new NotImplementedException();
    }

}
