using System;
using System.Collections.Generic;
using System.Text;

namespace EquipesExos2
{
    public class Equipe //1er objet de type general
    {
        int points = 0;
        public Equipe(string choixNom) //#1 meme nom que la class = constructeur (nom obligatoire)
        {
            this.NomEquipe = choixNom; //#1 on a recuperé ds le construc et stocke ds le constructeur

        }
        //#1 propriete car accesible de l'ext ( lecture seule car on veut pas modifier le nom equipe ap)
        public string NomEquipe { get; private set; } 


        //#6 on rajoute la liste des joueurs choisi
        public List<Joueur> ListJoueurs { get; private set; } = new List<Joueur>();
        public void SetPoints (PointsTypes pointsTypes)
        {
            switch (pointsTypes)
            {
                case PointsTypes.UnPoint:
                    points += 1;
                    break;
                case PointsTypes.DeuxPoints:
                    points += 2;
                    break;
                case PointsTypes.TroisPoints:
                    points += 3;
                    break;
                default:
                    break;
            }
        }

        public int GetPoints()
        {
            return points;
        }
    }
}
