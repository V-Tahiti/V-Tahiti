using System;
using System.Linq;

namespace Bataille
{
    class Program
    {
        static void Main(string[] args)
        {
            Joueur joueur1 = new Joueur("Vai", "Gaderfield");
            Joueur joueur2 = new Joueur("Lynda", "Gadi");
            Joueur joueur3 = new Joueur("Jean", "Troy");
            Joueur joueur4 = new Joueur("Sarah", "Martin");

            GameService game = new GameService();


            game.Jeu(joueur1, joueur2);
            game.Jeu(joueur3, joueur4);

            Joueur gagnant1 = null;
            Joueur gagnant2 = null;

            if (joueur1.JeuMain.Count()== 0)
            {
                gagnant1 = joueur2;
            }
            else
            {
                gagnant1 = joueur1;
            }

            if (joueur3.JeuMain.Count() == 0)
            {
                gagnant2 = joueur4;
            }
            else
            {
                gagnant2 = joueur3;
            }


            game.Jeu(gagnant1, gagnant2);

            Console.WriteLine(gagnant1.FirstName);
            Console.WriteLine(gagnant1.JeuMain.Count());

            Console.WriteLine(gagnant2.FirstName);
            Console.WriteLine(gagnant2.JeuMain.Count());
        }
    }
}
