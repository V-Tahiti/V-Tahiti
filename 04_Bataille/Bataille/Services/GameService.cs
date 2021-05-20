using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace Bataille
{
    public class GameService
    {
        Joueur joueur1;
        Joueur joueur2;

        public Deck PacketJeu { get; set; } = new Deck();

        public void Jeu(Joueur extjoueur1, Joueur extjoueur2)
        {
            this.joueur1 = extjoueur1;
            this.joueur2 = extjoueur2;


            this.joueur1.JeuMain.Clear();
            this.joueur2.JeuMain.Clear();

            CreerPacket();
            Distribuer();
            OnPoseCarteSurTable();

        }



        private void CreerPacket()
        {
            for (int i = 0; i < 13; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    PacketJeu.Packet.Add(new Card((ForceType)i, (CouleurType)j));
                    //J'ajoute dans "PacketJeu" que j'ai récupérer de "Packet" et j'y ai ajouté des cartes venant du constructeur "Card" (ForceType et CouleurType)
                }
            }
        }

        private void Distribuer()
        {
            for (int i = 0; i < 26; i++) // je le fais 26 fois
            {
                joueur1.JeuMain.Add(this.CartesAleatoires(this.PacketJeu.Packet));
                // j'ai mis dans la main du joueur et j'y ai ajouter une carte aléatoire du "Packet" à partir du "PacketJeu"
                joueur2.JeuMain.Add(this.CartesAleatoires(this.PacketJeu.Packet));
            }
        }
        private Card CartesAleatoires(List<Card> listCard) // Card renseigne les propiétés que l'on veut dans l'objet Card
        {
            int nombreMax = listCard.Count(); // on définit le nombre max de cartes
            Random aleatoire = new Random(); // méthode aléatoire
            int indexAleatoire = aleatoire.Next(0, nombreMax); //choisir un emplacement aléatoire de carte
            Card retraitCarte = listCard[indexAleatoire]; // Sauvegarder/instancier l'emplacement de la liste
            listCard.RemoveAt(indexAleatoire); // supprime l'emplacement "indexAleatoire" du packet de la liste de carte
            return retraitCarte; // on retourne la carte choisie aléatoirement
        }
        //private void OnPoseCarteSurTable()
        //{
        //    Card lastCard = this.joueur1.JeuMain.Last();
        //    joueur1.Plateau.Add(lastCard); // on ajoute au plateau la dernière carte à partir de la MainJoueur
        //    joueur1.JeuMain.Remove(lastCard);// on retire la dernière carte à partir de la MainJoueur
        //    lastCard = this.joueur2.JeuMain.Last(); // lastCard est réutilisé et écrasé par rapport au joueur1 car elle est utilisée en TAMPON
        //    joueur2.Plateau.Add(lastCard); // on ajoute au plateau la dernière carte à partir de la MainJoueur
        //    joueur2.JeuMain.Remove(lastCard);// on retire la dernière carte à partir de la MainJoueur

        //    while (joueur1.JeuMain.Count() > 0 || joueur2.JeuMain.Count() > 0)
        //    {
        //        //joueur1.Plateau.Add(this.joueur1.JeuMain.Last()); // on ajoute au plateau la dernière carte à partir de la MainJoueur
        //        //joueur1.JeuMain.Remove(this.joueur1.JeuMain.Last());// on retire la dernière carte à partir de la MainJoueur
        //        //joueur2.Plateau.Add(this.joueur2.JeuMain.Last()); // on ajoute au plateau la dernière carte à partir de la MainJoueur
        //        //joueur2.JeuMain.Remove(this.joueur2.JeuMain.Last());// on retire la dernière carte à partir de la MainJoueur

        //        // continue; // ne pas oublier de mettre continue pour perpétuer la boucle   
        //        if (joueur1.Plateau.Last().Force < joueur2.Plateau.Last().Force)
        //        {
        //            joueur2.JeuMain.AddRange(this.joueur1.Plateau);
        //            joueur2.JeuMain.AddRange(this.joueur2.Plateau);
        //            joueur1.Plateau.Clear();
        //            joueur2.Plateau.Clear();

        //        }
        //        if (joueur1.Plateau.Last().Force > joueur2.Plateau.Last().Force)
        //        {
        //            joueur1.JeuMain.AddRange(this.joueur1.Plateau);
        //            joueur1.JeuMain.AddRange(this.joueur2.Plateau);
        //            joueur1.Plateau.Clear();
        //            joueur2.Plateau.Clear();
        //        }
        //        else (joueur1.Plateau.Last().Force = joueur2.Plateau.Last().Force)
        //        {
        //            joueur1.Plateau.Add(this.joueur1.JeuMain.Last()); // on ajoute au plateau la dernière carte à partir de la MainJoueur
        //            joueur1.JeuMain.Remove(this.joueur1.JeuMain.Last());// on retire la dernière carte à partir de la MainJoueur
        //            joueur2.Plateau.Add(this.joueur2.JeuMain.Last()); // on ajoute au plateau la dernière carte à partir de la MainJoueur
        //            joueur2.JeuMain.Remove(this.joueur2.JeuMain.Last());// on retire la dernière carte à partir de la MainJoueur
        //        }
        //        continue;
        //    }
        //}


        private void OnPoseCarteSurTable()
        {
            List<Card> cartesEgalite = new List<Card>(); // on instancie une variable locale, elle sera accessible en dehors de la boucle "While"

            while (joueur1.JeuMain.Count() > 0 && joueur2.JeuMain.Count() > 0)
            {
                PoseCartePlateau(joueur1); // on appelle la méthode PoseCartePlateau
                PoseCartePlateau(joueur2);
                //joueur1.Plateau.Add(this.joueur1.JeuMain.Last()); // on ajoute au plateau la dernière carte à partir de la MainJoueur
                //joueur1.JeuMain.Remove(this.joueur1.JeuMain.Last());// on retire la dernière carte à partir de la MainJoueur
                //joueur2.Plateau.Add(this.joueur2.JeuMain.Last()); // on ajoute au plateau la dernière carte à partir de la MainJoueur
                //joueur2.JeuMain.Remove(this.joueur2.JeuMain.Last());// on retire la dernière carte à partir de la MainJoueur

                // continue; // ne pas oublier de mettre continue pour perpétuer la boucle   
                if (joueur1.Plateau.Last().Force < joueur2.Plateau.Last().Force)
                {
                    joueur2.JeuMain.Insert(0, this.joueur1.Plateau.Last()); // insérer dans le jeu main à l'index 0 (au début) la dernière carte du plateau
                    joueur2.JeuMain.Insert(0, this.joueur2.Plateau.Last()); // insérer dans le jeu main à l'index 0 (au début) la dernière carte du plateau

                    joueur2.JeuMain.InsertRange(0, cartesEgalite); //ici bientôt autre chose
                    cartesEgalite.Clear();

                    continue;
                }
                if (joueur1.Plateau.Last().Force > joueur2.Plateau.Last().Force)
                {
                    joueur1.JeuMain.Insert(0, this.joueur1.Plateau.Last()); // insérer dans le jeu main à l'index 0 (au début) la dernière carte du plateau
                    joueur1.JeuMain.Insert(0, this.joueur2.Plateau.Last()); // insérer dans le jeu main à l'index 0 (au début) la dernière carte du plateau

                    joueur1.JeuMain.InsertRange(0, cartesEgalite); //ici bientôt autre chose
                    cartesEgalite.Clear();

                    continue;
                }

                if (joueur1.Plateau.Last().Force == joueur2.Plateau.Last().Force) 
                {
                    Joueur tempJoueur1 = this.joueur1;
                    Joueur tempJoueur2 = this.joueur2;

                    if (joueur1.JeuMain.Count() == 0 ) // Version connard. Le joueur qui a une dernière carte en main perd
                    {
                        tempJoueur1 = joueur2;
                        this.joueur1.JeuMain.Add(this.joueur2.JeuMain.Last());
                        this.joueur1.JeuMain.Remove(this.joueur2.JeuMain.Last());
                    }

                    if ( joueur2.JeuMain.Count() == 0) // Version connard. Le joueur qui a une dernière carte en main perd
                    {
                        tempJoueur2= joueur1;
                        this.joueur2.JeuMain.Add(this.joueur1.JeuMain.Last());
                        this.joueur2.JeuMain.Remove(this.joueur1.JeuMain.Last());
                    }

                    cartesEgalite.Add(tempJoueur1.Plateau.Last());
                    cartesEgalite.Add(tempJoueur2.Plateau.Last());
                    cartesEgalite.Add(tempJoueur1.JeuMain.Last());
                    cartesEgalite.Add(tempJoueur2.JeuMain.Last());
                    tempJoueur1.JeuMain.Remove(tempJoueur1.JeuMain.Last());
                    tempJoueur2.JeuMain.Remove(tempJoueur2.JeuMain.Last());

                    tempJoueur1.Plateau.Clear();
                    tempJoueur2.Plateau.Clear();

                }

            }
        }

        private void PoseCartePlateau(Joueur joueur) // ici "joueur" est une variable locale de la méthode
        {
            joueur.Plateau.Clear(); // ne pas mettre de .this c ar ici on accède à la variable "joueur" dans la méthode PoseCartePlateau et de la classe
            Card lastCard = joueur.JeuMain.Last();
            joueur.Plateau.Add(lastCard); // on ajoute au plateau la dernière carte à partir de la MainJoueur
            joueur.JeuMain.Remove(lastCard);// on retire la dernière carte à partir de la MainJoueur


        }


    }
}
