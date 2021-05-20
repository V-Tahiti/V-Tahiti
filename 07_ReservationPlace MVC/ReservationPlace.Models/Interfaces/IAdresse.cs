using System;
using System.Collections.Generic;
using System.Text;

namespace ReservationPlace.Models.Interfaces
{

    public interface IAdresse
    {
        /* ici l'interface dépend d'une classe "Adress". C'est pour ça que sa proppriété est de type "Adress"
         Si par la suite on souhaite implémenter une autre propriété dans la classe d'origine ""Adress", elle sera automatiquement
         intégrée dans la propriété ci-dessous. Et donc toutes les classes qui dépendent de l'interface "IAdress"
         seront soumise au nouveau contrat*/
         
        IAdressGenerique Adress { get; set; }
    }
}
