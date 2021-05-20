using _1_Random;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _1_Random
{
    public class NameService
    {
        private readonly RandomService randomService = new RandomService();

        private readonly List<char> vowels = new List<char>() { 'a', 'e', 'i', 'o', 'u', 'y' };
        private readonly List<char> consonants = new List<char>();

        private static readonly Lazy<NameService> lazy = new Lazy<NameService>(() => new NameService());
        public static NameService Instance { get { return lazy.Value; } }
        public NameService()
        {
            //On creer la liste des Consonnes
            //97 à 122 => table des char minuscules (ASCII)
            for (int i = 97; i < 123; i++)
            {
                char letter = (char)i;

                if (!vowels.Exists(l => l == letter))
                    consonants.Add(letter);
            }
        }


        //Nom entre 6 et 7 caracteres par defaut
        public string CreateRandomName(int min = 6, int max = 8)
        {
            int count = randomService.GetRandom(min, max + 1);

            string name = null;
            //Pour le nom on alterne consonne et voyelle en commencant par une consonne
            for (int i = 0; i < count; i++)
            {
                if (i % 2 == 0)
                    //Si c'est paire on prend une consonne sinon une voyelle
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
