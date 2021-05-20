using AITeam.Utils;
using BowlingGame.Models.Enums;
using BowlingGame.Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BowlingGame.Core
{
    public class TourService
    {

        private readonly RandomService randomService = RandomService.Instance;

        public void LancerBoule(ForceType force, Manche manche, int quilleMax = 9, int numeroTour = 1)

        {
            Tour tour = new Tour();
            manche.Tours.Add(tour);
            int qteQuilleTombee = CalculQuilleTombee(force, manche, quilleMax);
            if (qteQuilleTombee == quilleMax) // c'est un strike ou un spare
            {
                StrikeOuSpare(manche);

            }
            else
            {
                manche.Points += qteQuilleTombee;
                if (numeroTour == 1)
                {
                    LancerBoule(force, manche, quilleMax - qteQuilleTombee, 2);
                }

            }
            tour.NbrDeTour = numeroTour;
            tour.QuilleTombee = qteQuilleTombee;
            tour.QuilleRestantes = quilleMax;


        }

        private void StrikeOuSpare(Manche manche)
        {
            // return manche.Points += manche.Tours.Any() ? 11 : 22;
            //Je veux ajouter qq chose dans "manche.Points +=" je prend un "bool" "manche.Tours.Any() "
            // si "?" c'est vrai je mets 11 ":" sinon je met 22
            if (manche.Tours.Count() == 1)
            {
                manche.Points = 22;
            }
            else
            {
                manche.Points = 11;
            }
        }

        private int CalculQuilleTombee(ForceType force, Manche manche, int quilleMax) // pour "quilleMax" elle est incluse plus haut dans la méthode "LancerBoule"
        {
            int qteQuilleTombe = 0;
            for (int i = 0; i < quilleMax; i++)
            {
                if (QuilleTombee((int)force == (int)manche.Boule)) //on caste et on force la valeur de l'énum afin de comparer les valeurs (0,1,2)
                {
                    qteQuilleTombe++; // Chaque quille tombée on ajoute
                }
            }
            return qteQuilleTombe;
        }

        private bool QuilleTombee(bool forceEgale)
        {
            //return randomService.GetRandom(0, 10) < (forceEgale ? 6 : 3); // le "?" est la forme contractée de "if" et les ":" remplace le "else"
            // la forme abrégée ne marche que si uniquement il y a un "else"
            //remplace tout le code dessous
            int proba = 3;
            if (forceEgale)
            {
                proba = 6;
            }
            return randomService.GetRandom(0, 10) < proba;
        }
    }
}
