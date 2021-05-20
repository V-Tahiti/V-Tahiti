using System;
using System.Collections.Generic;
using System.Linq;

namespace AITeam.Utils
{
    public sealed class RandomService
    {
        private static readonly Lazy<RandomService> lazy = new Lazy<RandomService>(() => new RandomService());
        public static RandomService Instance { get { return lazy.Value; } }
        private RandomService()
        {
        }

        static readonly Random random = new Random();

        public int GetRandom(int max)
        {
            return GetRandom(0, max);
        }

        public int GetRandom(int min, int max)
        {
            return random.Next(min, max);
        }

        public int GetRandomIndex<T>(IEnumerable<T> list)
        {
            return random.Next(list.Count());
        }

        public T GetRandomFrom<T>(IEnumerable<T> list)
        {
            return list.ToArray()[this.GetRandomIndex<T>(list)];
        }
        public T GetRandomFrom<T>() where T : Enum
        {
            IEnumerable<T> enumArray = (T[])Enum.GetValues(typeof(T));

            return GetRandomFrom<T>(enumArray);
        }
        public T GetRandomAndExclude<T>(params T[] excludes) where T : Enum
        {
            IEnumerable<T> enumArray = (T[])Enum.GetValues(typeof(T));

            if (excludes != null)
                enumArray = enumArray.Except(excludes);


            return GetRandomFrom<T>(enumArray);
        }
        public T GetRandomIn<T>(params T[] list) where T : Enum
        {
            return GetRandomFrom<T>(list);
        }

        public string GetRandomColorCode()
        {
            string code = null;

            for (int i = 0; i < 6; i++)
            {
                code += this.GetRandomHexaCode();
            }

            return code;
        }

        public string GetRandomHexaCode()
        {
            return this.GetRandomFrom<string>(new List<string> { "0", "1", "2","3","4","5","6","7","8","9","A", "B", "C", "D", "E", "F" });
        }

        public IEnumerable<T> Shuffle<T>(IEnumerable<T> list)
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