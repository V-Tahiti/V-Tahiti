using System;
using System.Collections.Generic;
using System.Text;

namespace Postage // Supprimer le .Models
{
    public abstract class BasePostable:LetterBox// abstract = base devenue obligatoire. On interdit la classe à devenir concrête
    {
        //public abstract decimal Weight { get; private set; } // pas de set à cause de abstract
        public BasePostable(string extFirstName, string extLastName, string extAdress)
        {
            this.FirstName = extFirstName;
            this.LastName = extLastName;
            this.Address = extAdress;
        }
        public abstract decimal Weight { get;} // propriété
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Address { get; set; }
        
    }
      

}
