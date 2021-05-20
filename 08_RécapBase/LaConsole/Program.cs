using System;
using System.Globalization;
using System.Threading;

namespace LaConsole
{
    class Program
    {

        enum Color { Yellow = 1, Blue, Green };
        static DateTime thisDate = DateTime.Now;


        static void Main(string[] args)
        {


            //****************************  Ecriture dans Console.Write() *****************************************

            Console.WriteLine();
            Console.WriteLine("Chaine de caracteres Ecriture : Test 1 :");

            //****** Test 1 ******
            string nom = "Fred";
            string sortie = String.Format("Name = {0}, hours = {1:hh}", nom, DateTime.Now);
            // Index {0} = nom
            // Index {1} = DateTime.Now

            string primes;
            primes = String.Format("Nombre premier inférieur à 10: {0}, {1}, {2}, {3}", 2, 3, 5, 7);
            Console.WriteLine(primes);

            string nom2 = "Mark";

            // Formatage composite:
            Console.WriteLine("Hello, {0}! Aujourd'hui on est {1}, il est {2:HH:mm} maintenant.", nom2, thisDate.DayOfWeek, thisDate);

            // Interpolation de chaînes:
            Console.WriteLine($"Hello, {nom2}! Aujourd'hui on est {thisDate.ToString("dddd")}, il est {thisDate:HH:mm} maintenant.");

            // Les deux appels produisent la même sortie similaire à:
            // Bonjour Mark! Aujourd'hui, c'est mercredi, il est 19h40 maintenant.
            Console.WriteLine();



            //****** Test 2 ******
            Console.WriteLine("Chaine de caracteres Ecriture : Test 2 :");

            char[] array = new char[] { 'a', 'b', 'c', 'd' };

            //... Ecrit tout le tableau char sur une ligne.
            Console.WriteLine(array);

            // ... Écrivez les 2 caractères du milieu sur une ligne.
            Console.WriteLine(array, 1, 2);

            Console.WriteLine(array, 1, 3);
            Console.WriteLine();
            //Afffiche :
            //abcd
            //bc
            //bcd


            //****** Test 2 ******
            Console.WriteLine("Chaine de caracteres avec ASCII : Test 3 :");

            char[] array2 = new char[] { (char)98, (char)100 };
            //Comment afficher une liste ASCII
            Console.WriteLine(string.Join(" ", array2));
            Console.WriteLine();
            //Affiche
            //Chaine de caracteres avec ASCII : Test 2 :
            //b d



            //****************************  Chaine de Caracteres *****************************************

            Console.WriteLine("\t"); // => Tabulation
            Console.WriteLine("\n"); // => Retour Chariot
            Console.WriteLine("\\"); // => "c:\\https\\dossier\\...etc"
            Console.WriteLine(@" "); // => Tout est ok meme rtour chariot
            Console.WriteLine($" "); // => "... {} ... {} ..."
            Console.WriteLine($@" "); // => Tout



            //****************************  Caracteres ds les methodes ***********************************

            Console.WriteLine("\b"); // => Commence à la limite d'un mot / ou Termine à la limite d'un mot
            Console.WriteLine("[^o]"); // => Ts caracteres (char) qui n'est pas "o"

            Console.WriteLine($@"\w+"); // \w+ => Faire correspondre 1 ou pls char du mot
            Console.WriteLine($@"\w"); // \w => 1 mot (1 string)
            Console.WriteLine($@"\W"); // \w => Autre qu'un mot (un char, espace, ponctuation ...etc)
            //ex :
            //@"\bth[^o]\w+\b" => Mot commencant par th et non suivie par "o"
            //ex = this 
            //ex : mais pas != thought

            Console.WriteLine("^"); // => Commencant au debut de la ligne
            Console.WriteLine("$"); // => Finissant à la fin de la ligne

            Console.WriteLine(".+"); // => Correspond a chaque caractere (char)

            Console.WriteLine($@"\s"); // \s => Espace Blanc
            Console.WriteLine($@"(\s)?"); // (\s)? => zero ou Espace Blanc
            Console.WriteLine($@"\s+"); // \s+ => n'importe quels nbres d'Espace Blanc
            Console.WriteLine($@"\s|$"); // \s|$ => espace ou fin de chaine

            Console.WriteLine($@"\S"); // \S => Tout caracteres non blanc (non espace)
            Console.WriteLine($@"\S+"); // \S+ => 1 ou pls caractere non blanc (non espace)

            Console.WriteLine($@"\d"); // \d => N'importe quels chiffres
            Console.WriteLine($@"\d{3}"); // \d{3} => 3 chiffres
            //ex : 122
            Console.WriteLine($@"\D"); // \D => Tous caractere (char) non numerique (chiffre)
            //ex : 'A' ou: 'n' ou: 'B'


            Console.WriteLine($@"?"); // ? => zero ou ...
            Console.WriteLine($@"+"); // ? => 1 ou plusieurs 
            Console.WriteLine($@"*"); // * => zero ou 1 ou plusieurs
            //ex: \D* => zero, 1 ou pls (char) non numerique (chiffre)
            

            //ex :
            //@"^\Dd{1;5}\D*$" => Chaine ce combinaison commencant par un (char) non numerique, suivant de 1 à 5 chiffres, suivant de "zero" ou 1 ou pls (char) non numerique pour la fin
            // = A1039C, = C18A
            //!= AA0001, != Y938518




            //*****************************  ReadKey() ***************************************

            Console.WriteLine();
            Console.WriteLine("-> ReadKey()");

            //Utilisez la méthode Console.ReadKey pour gérer les touches lorsqu'elles sont enfoncées de manière interactive.
            //Il ne nécessite pas que l'utilisateur appuie sur Entrée avant de revenir.



            //****** Test 1 ******
            Console.WriteLine("-> ReadKey() : Test 1 :");

            ConsoleKeyInfo cki;

            do
            {
                Console.WriteLine("\nAppuyez sur une touche pour afficher; appuyez sur la touche «x» pour quitter.");

                // Votre code pourrait effectuer une tâche utile dans la boucle suivante. cependant, pour cet exemple, nous allons simplement faire une pause d'un quart de seconde.

                // KeyAvailable = (true => si l'appui sur une touche est disponible, sinon => false.)

                while (Console.KeyAvailable == false)
                    Thread.Sleep(250); // Boucle jusqu'à ce que l'entrée soit entrée.

                cki = Console.ReadKey(true);
                Console.WriteLine("Vous avez appuyé sur la touche '{0}'.", cki.Key);
            }
            while (cki.Key != ConsoleKey.X);
            Console.WriteLine();



            //****** Test 1 ******
            Console.WriteLine("-> ReadKey() : Test 2 :");


            Console.WriteLine("... Appuyez sur échap, a, puis contrôlez X");

            // Appelez la méthode ReadKey et stockez le résultat dans une variable locale. 
            // ... Ensuite, testez le résultat pour échapper.

            ConsoleKeyInfo info = Console.ReadKey();
            if (info.Key == ConsoleKey.Escape)
            {
                Console.WriteLine("Vous avez appuyé sur échapper!");
            }

            // Appeler à nouveau ReadKey et tester la lettre a.
            info = Console.ReadKey();
            if (info.KeyChar == 'a')
            {
                Console.WriteLine("Vous avez appuyé sur a");
            }

            // Appelez à nouveau ReadKey et testez control-X. 
            // ... Ceci implémente une séquence de raccourcis.
            info = Console.ReadKey();
            if (info.Key == ConsoleKey.X &&
            info.Modifiers == ConsoleModifiers.Control)
            {
                Console.WriteLine("Vous avez appuyé sur la commande X");
            }
            Console.WriteLine();
            //Affiche :
            //(Les touches ont été enfoncées)
            //... Appuyez sur échapper, a, puis contrôlez X
            //Vous avez appuyé sur échapper!
            //Vous avez appuyé sur a
            //Vous avez appuyé sur la commande X




            //****************************  Date et Heure (1) *****************************************

            Console.WriteLine();

            Console.WriteLine("-> Date et Heure : Test 1 :");

            // Cet exemple de code illustre la méthode Console.WriteLine ().
            // Le formatage de cet exemple utilise la culture "en-US".


            // Mettre en forme la date actuelle de différentes manières.
            Console.WriteLine("Spécificateurs de format DateTime standard");
            Console.WriteLine(
                "(d) Date courte: . . . . . . . {0:d}\n" +
                "(D) Date longue:. . . . . . . . {0:D}\n" +
                "(t) Temps court: . . . . . . . {0:t}\n" +
                "(T) Long temps:. . . . . . . . {0:T}\n" +
                "(f) Date complète/courte durée: . . {0:f}\n" +
                "(F) Date complète/longue durée:. . . {0:F}\n" +
                "(g) Date générale/courte durée:. {0:g}\n" +
                "(G) Date générale/longue durée: . {0:G}\n" +
                "    (default):. . . . . . . . {0} (default = 'G')\n" +
                "(M) Mois:. . . . . . . . . . {0:M}\n" +
                "(R) RFC1123:. . . . . . . . . {0:R}\n" +
                "(s) Triable: . . . . . . . . {0:s}\n" +
                "(u) Universal sortable: . . . {0:u} (invariant)\n" +
                "(U) Date/heure universelles complètes: {0:U}\n" +
                "(Y) Année: . . . . . . . . . . {0:Y}\n", thisDate);
            //Affiche :
            //(d) Date courte: . . . . . . . 11/06/2020
            //(D) Date longue:. . . . . . . . jeudi 11 juin 2020
            //(t) Temps court: . . . . . . . 14:42
            //(T) Long temps:. . . . . . . . 14:42:35
            //(f) Date complète/courte durée: . . jeudi 11 juin 2020 14:42
            //(F) Date complète/longue durée:. . . jeudi 11 juin 2020 14:42:35
            //(g) Date générale/courte durée:. 11/06/2020 14:42
            //(G) Date générale/longue durée: . 11/06/2020 14:42:35
            //    (default):. . . . . . . . 11/06/2020 14:42:35 (default = 'G')
            //(M) Mois:. . . . . . . . . . 11 juin
            //(R) RFC1123:. . . . . . . . . Thu, 11 Jun 2020 14:42:35 GMT
            //(s) Triable: . . . . . . . . 2020-06-11 14:42:35
            //(u) Universal sortable: . . . 2020-06-11 14:42:35Z (invariant)\n" +
            //(U) Date/heure universelles complètes: jeudi 11 juin 2020 14:42:35
            //(Y) Année: . . . . . . . . . . juin 2020



            //****************************  Date et Heure (2) **************************************

            Console.WriteLine();
            Console.WriteLine("-> Date et Heure : Test 2 :");

            Console.WriteLine("1- Aujourd'hui on est le " + thisDate.ToString("dd/MM/yy") + ".");
            Console.WriteLine("1- Aujourd'hui on est le " + thisDate.ToString("ddd/MMM/yyy") + ".");
            Console.WriteLine("1- Aujourd'hui on est le " + thisDate.ToString("dddd/MMMM/yyyy") + ".");
            //Heure Format 24h => H
            Console.WriteLine("2- Aujourd'hui on est le " + thisDate.ToString("dd/MM/yyyy H:mm:ss") + ".");

            //Heure Format 12h => h
            Console.WriteLine("3- Aujourd'hui on est le " + thisDate.ToString("dd/MM/yyyy h:mm:ss") + ".");

            //Avec Fuseau Horaire => %K
            Console.WriteLine("4- Aujourd'hui on est le " + thisDate.ToString("dd/MM/yyyy h:mm %K") + ".");

            //Avec Décalage horaire par rapport à l'heure UTC => zzz
            Console.WriteLine("4- Aujourd'hui on est le " + thisDate.ToString("dd/MM/yyyy h:mm zzz") + ".");

            //avec Centièmes de seconde => .ff
            Console.WriteLine("5- Aujourd'hui on est le " + thisDate.ToString("dd/MM/yyyy H:mm:ss.ff") + ".");

            //avec indicateur AM/PM => t
            Console.WriteLine("6- Aujourd'hui on est le " + thisDate.ToString("dd/MM/yyyy H:mm:ss t",
                  CultureInfo.InvariantCulture) + ".");
            Console.WriteLine("6- Aujourd'hui on est le " + thisDate.ToString("dd/MM/yyyy H:mm:ss tt",
                  CultureInfo.InvariantCulture) + ".");

            //avec Période ou ère => g", CultureInfo.CreateSpecificCulture("fr-FR")
            Console.WriteLine("7- Aujourd'hui on est le " + thisDate.ToString("dd/MM/yyyy H:mm g", CultureInfo.CreateSpecificCulture("fr-FR")) + ".");
            Console.WriteLine();
            //Affiche :
            //1- Aujourd'hui on est le 11/06/20.
            //1- Aujourd'hui on est le jeu./juin/2020.
            //1- Aujourd'hui on est le jeudi/juin/2020.
            //2- Aujourd'hui on est le 11/06/2020 14:42:35.
            //3- Aujourd'hui on est le 11/06/2020 2:42:35.
            //4- Aujourd'hui on est le 11/06/2020 2:42 +02:00.
            //4- Aujourd'hui on est le 11/06/2020 2:42 +02:00.
            //5- Aujourd'hui on est le 11/06/2020 14:42:35.03.
            //7- Aujourd'hui on est le 11/06/2020 14:42:35 PM.
            //7- Aujourd'hui on est le 11/06/2020 14:42:35 ap. J.-C..



            //*********************************************************************

            Console.WriteLine("-> entier négatif ou un nombre à virgule flottante :");

            // Formate un entier négatif ou un nombre à virgule flottante de différentes manières.
            Console.WriteLine("Spécificateurs de format numérique standard");
            Console.WriteLine(
                "(C) Devise: . . . . . . . . {0:C}\n" +
                "(D) Decimale:. . . . . . . . . {0:D}\n" +
                "(E) Scientifique: . . . . . . . {1:E}\n" +
                "(F) Un point fixe:. . . . . . . {1:F}\n" +
                "(G) General:. . . . . . . . . {0:G}\n" +
                "    (default):. . . . . . . . {0} (default = 'G')\n" +
                "(N) Nombre: . . . . . . . . . {0:N}\n" +
                "(P) Pourcentage:. . . . . . . . . {1:P}\n" +
                "(R) Aller-retour: . . . . . . . {1:R}\n" +
                "(X) Hexadecimal:. . . . . . . {0:X}\n", -123, -123.45f);
            //Affiche : 
            //(C) Devise: . . . . . . . . -123,00 ?
            //(D) Decimale:. . . . . . . . . -123
            //(E) Scientifique: . . . . . . . -1,234500E+002
            //(F) Un point fixe:. . . . . . . -123,45
            //(G) General:. . . . . . . . . -123
            //    (default):. . . . . . . . -123 (default = 'G')
            //(N) Nombre: . . . . . . . . . -123,00
            //(P) Pourcentage:. . . . . . . . . -12 345,00%
            //(R) Aller-retour: . . . . . . . -123,45
            //(X) Hexadecimal:. . . . . . . FFFFFF85
            

          
            //*****************************  Couleurs  ***************************************

            Console.WriteLine();
            Console.WriteLine("-> Couleurs");


            //ForegroundColor = Police ; BackgroundColor = Fond

            Console.ForegroundColor = ConsoleColor.DarkBlue;
            Console.BackgroundColor = ConsoleColor.Yellow;
            Console.Write("Hello ");

            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.BackgroundColor = ConsoleColor.Red;
            Console.Write("les couleurs");

            Console.ForegroundColor = ConsoleColor.Black;
            Console.BackgroundColor = ConsoleColor.White;
            Console.Write(" dans la console");

            Console.ResetColor();
            Console.WriteLine();


            //Toutes les Couleurs
            Type type = typeof(ConsoleColor);
            Console.BackgroundColor = ConsoleColor.Black;
            foreach (var name in Enum.GetNames(type))
            {
                Console.ForegroundColor = (ConsoleColor)Enum.Parse(type, name);
                Console.WriteLine(name);
            }
            Console.WriteLine();



            //**************************************************************************

            // Formate une valeur d'énumération de couleur de différentes manières.
            Console.WriteLine("Spécificateurs de format d'énumération standard");
            Console.WriteLine(
                "(G) Général:.......... {0:G}\n" +
                "    (par défaut):........ {0} (par défaut = 'G')\n" +
                "(F) Indicateurs:.......... {0:F} (indicateurs ou entier)\n" +
                "(D) Nombre décimal:..... {0:D}\n" +
                "(X) Hexadécimal:....... {0:X}\n", Color.Green);
            //Affiche : 
            //(G) Général:.......... Green
            //   (par défaut):........ Green (par défaut = 'G')
            //(F) Indicateurs:.......... Green (indicateurs ou entier)
            //(D) Nombre décimal:..... 3
            //(X) Hexadécimal:....... 00000003



            //*****************************  Effacer Ecran  ***************************************

            //tous les 10 affichages on attend une saisie qui permet d'effacer l'écran :
            //for (int i = 1; i <= 40; i++)
            //{
            //    Console.WriteLine("Ligne numéro " + i);
            //    if (i % 10 == 0)
            //    {
            //        Console.ReadKey();
            //        Console.Clear();
            //    }
            //}
            //Console.WriteLine();



            //*****************************  Positionner Texte au Centre  ***************************************

            Console.WriteLine();
            Console.WriteLine("-> Centrage");

            CentrerLeTexte("Texte au Centre");
            CentrerLeTexte("Je suis un texte plus long");
            Console.WriteLine();



            // *************************   Methodes  **********************************
        }

        private static void CentrerLeTexte(string texte)
        {
            int nbEspaces = (Console.WindowWidth - texte.Length) / 2;
            Console.SetCursorPosition(nbEspaces, Console.CursorTop);
            Console.WriteLine(texte);
        }

    }
}

