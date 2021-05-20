using System;
using System.Collections.Generic;
using System.Linq;

namespace _0_ComptageElementsDsList
{
    class Program
    {
        static void Main(string[] args)
        {
            // ********************  TEST 1  ****************************

            var tab = new string[] { "1", "3", "3", "5", "7", "9", "8", "7", "7" };
            var results = tab
                .Distinct() // 1
                .Select(s => Tuple.Create(s, tab.Count(s2 => s2 == s))) // 2
                .OrderByDescending(pair => pair.Item2); // 3

            // 1 : On élimines les éléments apparaissant plus d'une fois
            // 2 : Pour chaque élément, on compte combien de fois il apparaît
            // 3 : On ordonne tout ça du plus grand au plus petit nombre d'éléments

            Console.WriteLine();
            Console.WriteLine("Test 1");
            foreach (var t in tab)
            {
                Console.Write(t + " ");
                //t = chaque string(nombre) du tableau
            }

            Console.WriteLine();
            foreach (var result in results)
            {

                Console.WriteLine("Le nombre {0} : {1} exemplaire{2}", result.Item1, result.Item2, result.Item2 > 1 ? "s" : "");
            }


            // Résultat :
            // Toto : 3 exemplaires
            // 42 : 2 exemplaires
            // test : 1 exemplaire
            // concombre : 1 exemplaire


            // ********************  TEST 2  ****************************

            string[] data = new string[] { "1", "3", "3", "5", "7", "9", "8", "7", "7" };
            var query = data
                .GroupBy(val => val)
                .OrderByDescending(grp => grp.Count())
                .ThenBy(grp => grp.Key);

            Console.WriteLine();
            Console.WriteLine("Test 2");
            foreach (var t in data)
            {
                Console.Write(t + " ");

            }
            Console.WriteLine();
            foreach (var item in query)
            {

                Console.WriteLine("Le nombre {0} ({1})", item.Key, item.Count());
            }

            // ********************  TEST 3 David  ****************************

            Console.WriteLine();
            Console.WriteLine("Test 3");
            List<int> listInt = new List<int> { 1, 3, 3, 5, 7, 8, 9, 8, 7, 7 };
            listInt.GroupBy(g => g).ToList().ForEach(g => Console.WriteLine($"Le nombre {g.Key} quantité : {g.Count()}"));

        }
    }
}
