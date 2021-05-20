using System;
using System.Collections.Generic;
using System.Linq;

namespace AITeam.Utils
{
    public class NameService
    {        private readonly RandomService randomService = RandomService.Instance;

        private readonly List<char> vowels = new List<char>() { 'a', 'e', 'i', 'o', 'u', 'y' };
        private readonly List<char> consonants = new List<char>();

        private static readonly Lazy<NameService> lazy = new Lazy<NameService>(() => new NameService());
        public static NameService Instance { get { return lazy.Value; } }
        private NameService()
        {
            //97 à 122 => table des char minuscules
            for (int i = 97; i < 123; i++)
            {
                char letter = (char)i;

                if (!vowels.Exists(l => l == letter))
                    consonants.Add(letter);
            }
        }



        public string CreateRandomName(int min = 6, int max = 8)
        {
            int count = randomService.GetRandom(min, max + 1);

            string name = null;
            for (int i = 0; i < count; i++)
            {
                if (i % 2 == 0)
                    name += randomService.GetRandomFrom(consonants);
                else
                    name += randomService.GetRandomFrom(vowels);

                if (i == 0)
                    name = name.ToUpper();
            }


            return name;
        }
    }
}