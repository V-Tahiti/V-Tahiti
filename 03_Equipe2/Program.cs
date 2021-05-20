using System;

namespace EquipesExos2
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Voici la liste des équipes");

            Equipe equipeA = new Equipe("Pirhanna");
            Equipe equipeB = new Equipe("Bolduc");

            Joueur joueur1 = new Joueur("Georges", "Martin");
            Joueur joueur2 = new Joueur("Julie", "Marchal");
            Joueur joueur3 = new Joueur("Henry", "Lanister");
            Joueur joueur4 = new Joueur("Janne", "Hugo");


            joueur1.Fonction = EnumFonctionTypes.Capitaine;
            joueur2.Fonction = EnumFonctionTypes.Pillier;
            joueur3.Fonction = EnumFonctionTypes.Capitaine;
            joueur4.Fonction = EnumFonctionTypes.DefenseurD;

            equipeA.ListJoueurs.Add(joueur1);
            equipeA.ListJoueurs.Add(joueur3);
            equipeB.ListJoueurs.Add(joueur2);
            equipeB.ListJoueurs.Add(joueur4);


            equipeA.SetPoints(PointsTypes.DeuxPoints);
            Console.WriteLine("avec les joueurs suivants: ");
            Console.WriteLine("Equipe A");
            foreach (var team in equipeA.ListJoueurs)
            {
                Console.WriteLine("Nom " + team.NomJoueur);
                Console.WriteLine("Prénom " + team.PrenomJoueur);
                Console.WriteLine("Fonction " + team.Fonction);
            }

            Console.WriteLine("Equipe B");
            foreach (var team in equipeB.ListJoueurs)
            {
                Console.WriteLine("Nom " + team.NomJoueur);
                Console.WriteLine("Prénom " + team.PrenomJoueur);
                Console.WriteLine("Fonction " + team.Fonction);
            }

        }
    }
}
