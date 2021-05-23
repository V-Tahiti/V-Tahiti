using FireGame.Model;
using System;
using System.Collections.Generic;
using System.Linq;

namespace FireGame.Core.Services
{
    public class GameService
    {
        private readonly RandomService randomService = new RandomService();
        private int currentPlayerIndex = 0;

        public GameService(List<Player> players)
        {
            this.Players = randomService.Shuffle(players);
        }

        public bool HasWinner { get { return this.Winner != null; } }
        public Player Winner { get { return this.Players.FirstOrDefault(p => p.Points == 3); } }

        public List<Player> Players { get; private set; }

        public ValueTuple<Player, bool> NextTurn()
        {
            Player currentPlayer = this.Players[currentPlayerIndex++]; // je sauvegarde localement le joueur actuel et on commence par le 1er, et on incrémente
            bool targetHit = TargetHit(currentPlayer); //a-t-il touché la cible

            if (targetHit)
                currentPlayer.Points++;

            if (currentPlayerIndex == (this.Players.Count()))// si la liste est fini
                currentPlayerIndex = 0;// le joueur actuel revient à l'emplacement 0

            return new ValueTuple<Player, bool>(currentPlayer, targetHit);
        }




        private bool TargetHit(Player player)
        {
            return randomService.GetRandom(4) == 0;
        }


    }
}
