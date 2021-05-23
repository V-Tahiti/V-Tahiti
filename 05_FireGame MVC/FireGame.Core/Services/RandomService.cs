using System;
using System.Collections.Generic;
using System.Linq;

namespace FireGame.Core.Services
{
    public class RandomService
    {
        static readonly Random random = new Random();

        public int GetRandom(int max)
        {
            return GetRandom(0, max);
        }

        public int GetRandom(int min, int max)
        {
            return random.Next(min, max);
        }

        public int GetRandomIndex<T>(List<T> list)
        {
            return random.Next(list.Count());
        }

        public T GetRandom<T>(List<T> list)
        {
            return list[this.GetRandomIndex<T>(list)];
        }


        public List<T> Shuffle<T>(List<T> list)
        {
            List<T> copy = new List<T>(list);

            int n = copy.Count;
            while (n > 1)
            {
                n--;
                int k = random.Next(n + 1);
                T value = copy[k];
                copy[k] = copy[n];
                copy[n] = value;
            }

            return copy;
        }
    }
}