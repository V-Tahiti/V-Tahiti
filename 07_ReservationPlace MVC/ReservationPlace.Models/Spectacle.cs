using ReservationPlace.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace ReservationPlace.Models
{
    /* La classe "Spectacle" dépend de "ICoordonnées" et de "IId" il est don nécessaire d'implémenter les propriétés respectives
  pour remplir les contrats. 
  Comme "ICoordonnées" dépend de l'interface "IAdresse" on est obligé également d'implémenter la propriété "Adress" qui
  provient de la classe "Adress".
  Si on fait des modifications de propriétés dans la classe d'origine (ex: "Adress") elles sont automatiquement incluses
  dans la propriété de type objet "Adress". C'est une bonne pratique d'écriture afin d'éviter la maintenance du code. */

    public class Spectacle : IId, ICoordonnees

    {
        public List<Artiste> Artistes { get; set; } = new List<Artiste>();
        public int Id { get; set; }
        public Coordonnees Coordonnees { get; set; }
        public IAdressGenerique Adress { get ; set ; }
    }
}
