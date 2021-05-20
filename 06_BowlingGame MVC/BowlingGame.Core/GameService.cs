using AITeam.Utils;
using BowlingGame.Models.Enums;
using BowlingGame.Models.Models;
using System;
using System.Collections.Generic;

namespace BowlingGame.Core
{
    public class GameService
    {

        private readonly RandomService randomService = RandomService.Instance;
        private readonly NameService nameService = NameService.Instance; // création de nom aléatoire
        private readonly TourService tourService = new TourService(); // on instancie et donc on accède aux autres services
        const int QUANTITE_MANCHE = 10; // accessible de tous dans la "class GameService"
        public List<Joueur> Joueurs { get; set; } = new List<Joueur>();
        public void Initialize()
        {
           CreerEquipe();
            Onjoue();

        }
        private void CreerEquipe()
        {
            int quantite = randomService.GetRandom(2, 7);
            for (int i = 0; i < quantite; i++)
            {
                ForceType force = randomService.GetRandomFrom<ForceType>();
               // Joueurs.Add(new Joueur(joueur, force));
                Joueurs.Add(new Joueur("J" + (i + 1), force));
                // Joueurs.Add(new Joueur(nameService.CreateRandomName(), force)); // création de nom aléatoire
            }
             }
        private void Onjoue()
        {
            for (int i = 0; i < QUANTITE_MANCHE; i++)
            {
                JeuPrChaqueJoueur(i + 1);
            }
        }

        private void JeuPrChaqueJoueur(int numeroManche)
        {
            foreach (var joueur in Joueurs)
            {
                SizeType boule = randomService.GetRandomFrom<SizeType>(); // sélection aléatoire de la boule de bowling
                Manche manche = new Manche(); //On instancie la class "PointParManche" et on accède à toutes ses propriétés
                manche.NbrDeManche = numeroManche; //On créé une variable "numéroManche" 
                manche.Boule = boule; // on stocke la taille de la boule
                joueur.Manches.Add(manche); // on ajoute toutes les propriétés de chaque manche au joueur
                tourService.LancerBoule(joueur.Force, manche);

            }
        }






    }
}
