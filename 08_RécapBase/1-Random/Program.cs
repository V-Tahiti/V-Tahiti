using _1_Random;
using _1_Random.Enums;
using _1_Random.Models;
using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;

namespace _1_Random
{
    class Program
    {
        private static NameService nameService = new NameService();
        private static Services.NameServiceList nameServiceList = new Services.NameServiceList();
        private static RandomService randomService = new RandomService();

        static void Main(string[] args)
        {



            //Aleatoire

            // ... Créez un nouvel objet Random.
            Random random = new Random();

            //----------------- (1) Exemples de nombres aléatoires C# -------------------------------

            Console.WriteLine();
            Console.WriteLine("1-> Random())");

            //**** (1) Max ***
            //Le code suivant renvoie un nombre aléatoire inférieur à 5
            int num = random.Next(5);
            Console.WriteLine("essai 1: num :" + num);


            //**** (2) Min et Max ***
            //Lorsque nous transmettons un entier à Random.Next(), nous obtenons un résultat compris entre min et max, avec min compris mais pas max.
            static int RandomNumber(int min, int max)
            {
                Random random = new Random();
                return random.Next(min, max);
            }
            Console.WriteLine("essai 2: string lettres :" + RandomNumber(1, 5));



            //*********** (3) Creation Mot de passe avec Majuscules/Minuscules **********
            string caracteres = "azertyuiopqsdfghjklmwxcvbn";

            string sel = ""; // le mot de passe a la fin

            // 8 caracteres, la taille du mot de passes
            for (int i = 0; i < 8; i++)
            {
                // a chaque tour de boucle marOrMin va valoir sois 0 ou 1 
                int majOrMin = random.Next(2); // un nombre aléatoire qui vaut 0 ou 1

                // un caractere au hazard dans la chaine (caractere transformé en string)
                string carac = caracteres[random.Next(0, caracteres.Length)].ToString();

                // si le nombre vaut 0
                if (majOrMin == 0)
                {
                    sel += carac.ToUpper(); // on met le caracteres en majuscule et on le met dans la chaine
                }
                else
                {
                    sel += carac.ToLower(); //Sinon on met le caracteres en minscule et on le met dans lachaine
                }
            }
            Console.WriteLine("essai 3: Le Mot de Passe est : " + sel); // tu affiches le mot de passe
            Console.WriteLine();




            //*********** (4) Creation Mot de passe avec Majuscules/Minuscules/Chiffres **********
            //Retourne un string composé de lettre minuscule si vrai, majuscule si faux

            //le code suivant génère un mot de passe de longueur 10 avec les 4 premières lettres en minuscules, les 4 chiffres suivants et les 2 dernières lettres en majuscules.

            static string RandomString(int size, bool lowerCase)
            {
                StringBuilder builder = new StringBuilder();
                Random random = new Random();
                char ch;
                for (int i = 0; i < size; i++)
                {
                    ch = Convert.ToChar(Convert.ToInt32(Math.Floor(26 * random.NextDouble() + 65)));
                    builder.Append(ch);
                }
                if (lowerCase)
                    return builder.ToString().ToLower();
                return builder.ToString();
            }
            //Console.WriteLine(RandomString(5, false));

            static string RandomPassword()
            {
                StringBuilder builder = new StringBuilder();
                builder.Append(RandomString(4, true));
                builder.Append(RandomNumber(1000, 9999));
                builder.Append(RandomString(2, false));
                return builder.ToString();
            }

            Console.WriteLine();
            Console.WriteLine("essai 4: string : min + num +  Maj :" + RandomPassword());


            //*********** (4) Creation Mot de passe avec Majuscules/Minuscules/Chiffres/Symbole **********

            string maj = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
            string min = "abcdefghijklmnopqrstuvwxyz";
            string chiffres = "0123456789";
            string symboles = ".!-_/*+=&$";

            //string ensemble = "";

            string ensemble = maj + min + chiffres + symboles;

            // Ici, ensemble contient donc la totalité des caractères autorisés

            string password = "";
            int taillePwd = 12;
            Random rand = new Random();
            for (int i = 0; i < taillePwd; i++)
            {
                Thread.Sleep(10);
                // On ajoute un caractère parmi tous les caractères autorisés
                password += ensemble[rand.Next(0, ensemble.Length)];
            }
            Console.WriteLine("essai 5: password : " + password);

            
            //****** ou *****
            string pwd = null;
            pwd += RandomFromString(maj, 2, 4);
            pwd += RandomFromString(min, 2, 4);
            pwd += RandomFromString(chiffres, 2, 4);
            pwd += RandomFromString(symboles, 2, 4);
            Console.WriteLine("pwd : " + pwd);
            Console.WriteLine("pwd melanger 1 : " + Scramble(pwd));
            Console.WriteLine("pwd melanger 2: " + Shuffle(pwd));
            Console.WriteLine();
            //Affiche
            // 


            //*********** (5) Test de la complexite du Password **********

            //Determines if a password is sufficiently complex.
            //Password to validate
            //Minimum number of password characters.
            //Minimum number of uppercase characters.
            //Minimum number of lowercase characters.
            //Minimum number of numeric characters.
            //Minimum number of special characters.
            //True if the password is sufficiently complex.


            TestValidatePassword(password);


            //*********** Creation Nom aleatoire d'apres lettres **********
            Console.WriteLine("Bonjour Nom creer : " + nameService.CreateRandomName());
            string choix = nameService.CreateRandomName();
            Console.WriteLine(choix);
            Console.WriteLine();


            //*********** Creation Nom aleatoire d'apres Liste **********

            static Joueur CreerJoueur()
            {
                Sexes sex = (Sexes)randomService.GetRandom(2); // entre 0 et 1 //raccourci en 1 ligne
                string name = nameServiceList.RandomName(sex);
                return new Joueur(name, sex);
            }

            Console.WriteLine();

            Joueur joueur = CreerJoueur();
            Console.WriteLine("Bonjour Nom choisi : " + joueur.Name + " " + joueur.Sex);




            // test ///
            

            Console.WriteLine(Melanger("mot"));




        }

        // ///////////////////////////////////////////////////////////////////////////

        static bool ValidatePassword(string pwd, int minLength = 8, int numUpper = 2, int numLower = 2, int numNumbers = 2, int numSpecial = 2)
        {
            // Replace [A-Z] with \p{Lu}, to allow for Unicode uppercase letters.
            Regex upper = new Regex("[A-Z]");
            Regex lower = new Regex("[a-z]");
            Regex number = new Regex("[0-9]");
            // Special is "none of the above".
            Regex special = new Regex("[^a-zA-Z0-9]");

            // Check the length.
            if (Strings.Len(pwd) < minLength)
                return false;
            // Check for minimum number of occurrences.
            if (upper.Matches(pwd).Count < numUpper)
                return false;
            if (lower.Matches(pwd).Count < numLower)
                return false;
            if (number.Matches(pwd).Count < numNumbers)
                return false;
            if (special.Matches(pwd).Count < numSpecial)
                return false;

            // Passed all checks.
            return true;
        }

        static void TestValidatePassword(string password2)
        {

            // Demonstrate that "Password" is not complex.
            Console.WriteLine(password2 + " is complex: " + ValidatePassword(password2));


            // Demonstrate that "Z9f%a>2kQ" is not complex.
            Console.WriteLine(password2 + " is complex: " + ValidatePassword(password2));
        }

        static string RandomFromString(string list, int min, int max)
        {
            Random random = new Random();
            var nombreTour = random.Next(min, max + 1);
            string lettres = null;
            for (int i = 0; i < nombreTour; i++)
            {
                lettres += list[random.Next(0, list.Length)];
            }
            return lettres;
        }

        public static string Scramble(string s)
        {
            return new string(s.ToCharArray().OrderBy(x => Guid.NewGuid()).ToArray());
        }
        public static string Shuffle(string str)
        {
            char[] array = str.ToCharArray();
            Random rng = new Random();
            int n = array.Length;
            while (n > 1)
            {
                n--;
                int k = rng.Next(n + 1);
                var value = array[k];
                array[k] = array[n];
                array[n] = value;
            }
            return new string(array);
        }

        static string Melanger(string mot)
        {
            int nombremaximal = mot.Length;

            Random random = new Random();
            string motFinal = "";

            for (int i = 0; i < nombremaximal; i++)
            {
                int indexAleatoire = random.Next(0, mot.Length);

                // on pointe la lettre obtenu et on identifie la position qu elle avait [ ici ]
                string lettre = mot[indexAleatoire].ToString();

                //On supprime son emplacement initial
                //Mais remove creer une copie, donc pour supprimer reelement l emplacement on creer un nouveau objet
                mot = mot.Remove(indexAleatoire);

                motFinal += lettre;
            }
            return motFinal;
        }
    }
}


