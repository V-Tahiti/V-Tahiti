using System;
using System.Collections.Generic;
using System.Text;

namespace EquipesExos2
{
    public class Joueur :object//#2 1er objet de type general
    {

        public Joueur(string choixNom, string choixPrenom) //#2 meme nom que la class = constructeur (nom obligatoire)
        {
            this.NomJoueur = choixNom; //#2 on a recupere ds le construc et stocke ds le constructeur
            this.PrenomJoueur = choixPrenom; //#2 on a recupere ds le construc et stocke ds le constructeur

        }

        public string NomJoueur { get; private set; } //#2 propriete car accesible de l'ext ( lecture seule car on veut pas modifier le nom equipe ap)
        public string PrenomJoueur { get; private set; } //#2 propriete car accesible de l'ext ( lecture seule car on veut pas modifier le nom equipe ap)

        public EnumFonctionTypes Fonction { get; set; } //#5 propriete modifiable
    }
}
