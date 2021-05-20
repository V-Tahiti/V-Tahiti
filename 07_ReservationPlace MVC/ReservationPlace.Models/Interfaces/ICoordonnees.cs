using System;
using System.Collections.Generic;
using System.Text;

namespace ReservationPlace.Models.Interfaces
{
    public interface ICoordonnees : IAdresse
    {
        /* ici l'interface dépend d'une classe "Coordonnees". C'est pour ça que sa proppriété est de type "Coordonnees"
         Si par la suite on souhaite implémenter une autre propriété dans la classe d'origine "Coordonnees", elle sera automatiquement
         intégrée dans la propriété ci-dessous. Et donc toutes les classes qui dépendent de l'interface "ICoordonnees"
         seront soumise au nouveau contrat automatiquement*/

        /* Pour information une interface peut dépendre d'autres interfaces. Dans notre cas elle dépend de "IAdress".
         Donc toute les classes qui dépenderont de "ICoordonnées" dépenderont également de "IAdress". */
        Coordonnees Coordonnees { get; set; }
    }
}
