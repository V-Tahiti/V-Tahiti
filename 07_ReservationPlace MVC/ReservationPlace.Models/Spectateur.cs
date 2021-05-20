using ReservationPlace.Models.Interfaces;

namespace ReservationPlace.Models
 
{
    /* La classe "Spectateur" dépend de "ICoordonnées" et de "IId" il est don nécessaire d'implémenter les propriétés respectives
    pour remplir les contrats. 
    Comme "ICoordonnées" dépend de l'interface "IAdresse" on est obligé également d'implémenter la propriété "Adress" qui
    provient de la classe "Adress".
    Si on fait des modifications de propriétés dans la classe d'origine (ex: "Adress") elles sont automatiquement incluses
    dans la propriété de type objet "Adress". C'est une bonne pratique d'écriture afin d'éviter la maintenance du code. */
    public class Spectateur : ICoordonnees,IId
    {
        public int Id { get; set; }
        // on instancie Coordonnees car c'est un objet qui fait partie d'un objet tut dépend du fonctionnel 
        // car dans notre cas dans la méthode dans "ReservationService" "AjoutSalleConcert" on ne veut pas que 
        // Coordonnees soit nul.
        public Coordonnees Coordonnees { get; set; } = new Coordonnees();
        public IAdressGenerique Adress { get ; set ; }
    }
}