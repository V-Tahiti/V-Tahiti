using BowlingGame.Core;
using BowlingGame.Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BowlingGame.View
{
    class Program
    {
        static void Main(string[] args)
        {
            GameService gameService = new GameService();
            //Console.WriteLine("Combien de joueurs êtes-vous ? ");
            //int qteJoueurs = Console.Read();
            gameService.Initialize();


            //var equipe = 0;
            //for (int i = 0; i < qteJoueurs; i++)
            //{
            //    Joueur joueur = new Joueur() Console.ReadLine();
            //}


            Console.WriteLine("Début de la partie");
            foreach (var joueur in gameService.Joueurs)
            {
                Console.WriteLine("Joueur " + joueur.Name + "- Force : " + joueur.Force);
                Console.WriteLine(" Nombre de STRIKE total : " + joueur.Manches.Where(s => s.Strike).Count());
                Console.WriteLine(" Nombre de SPARE total : " + joueur.Manches.Where(s => s.Spare).Count());
                Console.WriteLine();


                foreach (var manche in joueur.Manches)
                {
                    Console.WriteLine("Manche " + manche.NbrDeManche + " Joueur : " + joueur.Name);
                    Console.WriteLine();
                    Console.WriteLine("Choix de la boule : " + manche.Boule);
                    Console.WriteLine("Nombre de STRIKE : " + (manche.Strike ? "1" : "0"));
                    Console.WriteLine("Nombre de SPARE : " + (manche.Spare ? "1" : "0"));

                    foreach (var tour in manche.Tours.OrderBy(o => o.NbrDeTour))
                    {
                        Console.WriteLine("Tour " + tour.NbrDeTour + ": " + tour.QuilleRestantes + " Quilles sur la piste");
                        Console.WriteLine("la boule tape les quilles");
                        Console.WriteLine("Nombre de quilles touchées : " + tour.QuilleTombee + "/" + tour.QuilleRestantes);
                    }
                    Console.WriteLine("Points manche " + manche.NbrDeManche + " = " + manche.Points);
                    Console.WriteLine();
                    Console.WriteLine("taper une touche de votre clavier");
                    Console.ReadKey();
                }
                Console.WriteLine();
                



            }

            int valeurMax = gameService.Joueurs.Max(s => s.SommeTotalPoint); //On cherche la valeur "max" dans tous les joueurs et on la stocke dans une variable
            var listeGagnant = gameService.Joueurs.Where(s => s.SommeTotalPoint == valeurMax); //On cherche qui sont les joueurs qui correspondent à la valeur MAX
                                                                                               // et on les stockent dans une variable
                                                                                               // listeDesGagnant(listeGagnant);
            ListeDesGagnant(listeGagnant);
            foreach (Joueur gagnant in listeGagnant)
            {

                Console.WriteLine(gagnant.Name + " " + gagnant.SommeTotalPoint + " pts");


            }
            foreach (var joueur in gameService.Joueurs.OrderByDescending(o => o.SommeTotalPoint))
            {
                Console.WriteLine("Joueur" + joueur.Name + " : " + joueur.SommeTotalPoint);
            }
        }

        
        private static void ListeDesGagnant(IEnumerable<Joueur> listeGagnant)
        {
            if (listeGagnant.Count() > 1)
            {
                Console.Write("les gagnants sont: ");
            }
            else
            {
                Console.Write("le gagnant est : ");
            }
        }

    }
}
