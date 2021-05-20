using _2_Enum.Enums;
using _2_Enum.Services;
using System;
using System.Collections.Generic;
using System.Linq;

namespace _2_Enum
{
    class Program
    {
        private readonly ColorService colorService = new ColorService();

        static void Main(string[] args)
        {
            //***** Exemple 1 *****
            // Spécifiez une instance de balise.
            ColorTypes tagValue = ColorTypes.Rouge;


          

            if (tagValue == ColorTypes.Rouge)
            {
                // Sera afficher.
                Console.WriteLine("Rouge");
            }
            else
            {
                // Ne Sera pas afficher.
                Console.WriteLine("Pas Vrai");
            }
            Console.WriteLine();
            //Affiche :
            //Rouge


            //***** Exemple 2 *****
            //Console.WriteLine peut appeler automatiquement la méthode ToString.

            // ... Deux variables enum.
            ColorTypes color = ColorTypes.Bleu;
            VisibilityTypes visible = VisibilityTypes.Hidden;

            // ... Utilisez Console.WriteLine pour imprimer les valeurs d'héritier.
            Console.WriteLine(color);
            Console.WriteLine(visible);
            Console.WriteLine();



            //***** Exemple 3 *****
            // ... Test enum avec la méthode switch.
            FormatTypes formatValue = FormatTypes.None;
            if (IsFormat(formatValue))
            {
                // Ceci n'est pas atteint, car None ne renvoie pas une vraie valeur dans IsFormat.
                Console.WriteLine("Error");
            }
            // ... Testez une autre énumération avec switch.
            formatValue = FormatTypes.ItalicsFormat;
            if (IsFormat(formatValue))
            {
                // Ceci est imprimé, car nous recevons true de IsFormat.
                Console.WriteLine("True");
            }
            Console.WriteLine();
            //Affiche :
            //True


            //***********************************************************


            // ***** recupere un Char defini dans l'enum *****
            CharTypes charEnum = CharTypes.AnoniemNIETActive;
            Console.WriteLine("{0}: {1}", (char)charEnum, charEnum);
            Console.WriteLine();
            //Affiche :
            //R : AnoniemNIETActive


            // ***** recupere un string defini dans l'enum *****
            ColorTypes colorType = ColorTypes.Bleu;
            Console.WriteLine(colorType);
            Console.WriteLine("string : " + colorType + ", " + "Valeur : " + (int)colorType);
            Console.WriteLine();
            //Affiche :
            //Bleu
            //string : Bleu, Valeur :  33

            //ou

            foreach (var item in Enum.GetNames(typeof(ColorTypes)).ToList())
            {
                Console.WriteLine(item);
            }
            Console.WriteLine();
            //Affiche :
            //Rouge
            //Vert
            //Bleu


            // ***** recupere les valeurs defini dans l'enum *****
            foreach (int item in Enum.GetValues(typeof(ColorTypes)))
            {
                Console.WriteLine(item);
            }
            Console.WriteLine();
            //Affiche :
            //0
            //1
            //2
            //33
            foreach (int item in Enum.GetValues(typeof(CharTypes)))
            {
                Console.WriteLine(item);
            }
            Console.WriteLine();
            //Affiche :
            //32
            //65
            //82
            //87
            //90



            Console.WriteLine((char)(int)CharTypes.Archive);
            Console.WriteLine((char)CharTypes.AnoniemActive);
            Console.WriteLine(CharTypes.AnoniemActive);

        }

        // ////////////////////////////////////////////////////////////////////////////


        //IsFormat => cette méthode fonctionne comme un filtre qui nous renseigne sur les ensembles de valeurs d'énumération (elle contient une instruction switch).
        //Renvoie vrai si le FormatType est Gras ou Italique.
        static bool IsFormat(FormatTypes value)
        {
            switch (value)
            {
                case FormatTypes.BoldFormat:
                case FormatTypes.ItalicsFormat:
                    {
                        // Ces 2 valeurs sont des valeurs de format.
                        return true;
                    }
                default:
                    {
                        // L'argument n'est pas une valeur de format.
                        return false;
                    }
            }
        }


    }
}
