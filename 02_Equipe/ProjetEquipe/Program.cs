using System;

namespace ProjetEquipe
{
    class Program
    {
        static void Main(string[] args)
        {
            MembresEquipe Vaitua = new MembresEquipe("Vaitua", "MAKE", "Capitaine");
            Vaitua.Membre();

            MembresEquipe Alexandra = new MembresEquipe("Alexandra", "Muller", "Défense Gauche");
            Alexandra.Membre();
            
            MembresEquipe Laura = new MembresEquipe("Laura", "Wagner", "Défense Droit");
            Laura.Membre();
            Console.ReadKey();


            /*enum NomEquipe
              {
             Pirahnnas,
             BullDogs,
             Chihuahua,
             Eagles,
              }
             enum ListeJoueur
             {
             Fabien,
             Cyril,
             Agathe,
             Cécile,
             Amandine,
             Sylive,
             }*/

        }
    }
}
