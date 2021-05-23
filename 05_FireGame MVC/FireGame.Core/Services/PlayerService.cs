using FireGame.Model;
using FireGame.Model.Enums;
using System;
using System.Collections.Generic;

namespace FireGame.Core.Services
{
    public class PlayerService
    {
        private readonly RandomService randomService = new RandomService();
        private readonly NameService nameService = new NameService();
               
        public List<Player> CreatePlayers(int count)
        {
            List<Player> list = new List<Player>();

            for (int i = 0; i < count; i++)
            {
                list.Add(CreatePlayer(i+1));
            }

            return list;
        }

        private Player CreatePlayer(int bib)
        {
            Sexes sex  = (Sexes) randomService.GetRandom(2); // référence 2 joueurs dans les énum (0 ou 1)
            string name = nameService.RandomName(sex);
            return new Player(name,sex, bib);
        }
    }
}