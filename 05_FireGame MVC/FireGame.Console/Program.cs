using FireGame.Core;
using FireGame.Core.Services;
using FireGame.Model;
using System;
using System.Collections.Generic;
using System.Threading;

namespace FireGame.ConsoleView
{
    class Program
    {
        static void Main(string[] args)
        {
            PlayerService playerService = new PlayerService();

            Console.WriteLine("Bienvenue dans le jeu BALLTRAP");
            Console.WriteLine("entrez le nombre de joueurs souhaité pour la partie");
            int players = Int32.Parse(Console.ReadLine());
            Console.WriteLine("vous avez choisi " + players + " joueurs");
            Console.WriteLine("Veuillez taper sur une touche pour que la partie commence !");
            Console.ReadKey();

            // génération du service en fonction du nobre de joueurs entré manuellement de façon aléatoire indépendemment du sexe
            GameService gameService = new GameService(playerService.CreatePlayers(players));

            while (!gameService.HasWinner)
            {
                var result = gameService.NextTurn();

                Thread.Sleep(200); //Uniquement pour ralentir le temps car l'ordinateur est trop rapide pour nous autre humains

                ShowScores(result.Item1, result.Item2, gameService.Players);
            }

            Console.ForegroundColor = ConsoleColor.DarkGreen;
            Console.WriteLine($"{gameService.Winner.Bib} - {gameService.Winner.Name} gagne la partie");
            Console.WriteLine("Pour terminer le programme veuiller appuyer sur une touche");
            Console.ReadKey();
        }

        static void ShowScores(Player currentPlayer, bool targetHit, List<Player> players)
        {
            Console.Clear();

            foreach (Player player in players)
            {
                Console.Write($"{player.Bib}  {player.Name} : {player.Points}");

                if (player == currentPlayer)
                {
                    if (targetHit)
                    {
                        Console.ForegroundColor = ConsoleColor.DarkGreen;
                        Console.Write("  Touché !");
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.Write("  Raté !");
                    }
                    Console.ResetColor();
                }
                Console.WriteLine();
            }
        }
    }
}
