using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _1_Random
{
    public class RandomService
    {


        static readonly Random random = new Random();



        ////////////////////////////////////
        //elle va retourner un element aleatoirement entre un min et un maxi
        public int MethodeRandom(int min, int max)
        {
            Random random = new Random();
            return random.Next(min, max);
        }


        //**************** Min et Max ****************
        //elle va retourner un element aleatoirement entre un min et un maxi defini      
        public int GetRandom(int min, int max)
        {
            return random.Next(min, max);
        }


        //**************** Max ****************
        //elle va retourner un element aleatoirement entre 0 et un maxi defini  
        public int GetRandom(int max)
        {
            return GetRandom(0, max);
        }



        ///////////////////////////////////
        // recupere un index aleatoire ds une list 
        public int GetRandomIndex<T>(List<T> list)
        {
            return random.Next(list.Count());
        }

        // de la position il retourne l'objet a l'index defini au dessus
        public T GetRandom<T>(List<T> list)
        {
            return list[this.GetRandomIndex<T>(list)];
        }

        ///////////////////////////////////
        // recupere un index aleatoire ds une list IEnumerable( List, Tableau..)
        public int GetRandomIndex<T>(IEnumerable<T> list)
        {
            // retourne un aleatoire de 0 a qte de la list
            return random.Next(list.Count()); 
        }

        // de la position il retourne l'objet a l'index defini au dessus
        public T GetRandomFrom<T>(IEnumerable<T> list)
        {
            return list.ToArray()[this.GetRandomIndex<T>(list)];
        }


        ////////////////////////////////////
        //elle va retourner un element de l'enum aleatoirement
        //retourne le type d'enum mis en entree imposee         
        public T GetRandomFrom<T>() where T : Enum
        {
            IEnumerable<T> enumArray = (T[])Enum.GetValues(typeof(T));
            //je transforme le tableau en IEnumerable
            return GetRandomFrom<T>(enumArray);
            //retour une liste aleatoire en fonction du type T
        }


        ////////////////////////////////////
        // Permet de recuperer un element dans une enumeration en excluant ceux passe en parametre
        // ex:
        public T GetRandomAndExclude<T>(params T[] excludes) where T : Enum
        {
            // je recupere tte les valeurs de l'enum
            IEnumerable<T> enumArray = (T[])Enum.GetValues(typeof(T));
            // si y a exclusion, j enleve tte celles q st ds exclude
            if (excludes != null)
                enumArray = enumArray.Except(excludes);

            // je fais un getRandom sur ce q reste
            return GetRandomFrom<T>(enumArray);
        }


        /////////////////////////////////////////////////////
        // je choisi une dans laquelle il choisira le truc aleatoire

        public T GetRandomIn<T>(params T[] list) where T : Enum
        {
            return GetRandomFrom<T>(list);
        }


        /////////////////////////////////////////////////////
        // sort une couleur RGB en format hexa aleatoirement
        // ex: #DF452C

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
            return this.GetRandomFrom<string>(new List<string> { "0", "1", "2", "3", "4", "5", "6", "7", "8", "9", "A", "B", "C", "D", "E", "F" });
        }


        /////////////////////////////////////////////////////
        // Shuffle= melanger
        // Sort une nouvelle liste melanger
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

        /////////////////////////////////////////////////////



    }
}
