using System;
using System.Collections.Generic;
using System.Text;

namespace ProjetEquipe
{
    class MembresEquipe
    {
        private string Nom;
        private string Prénom;
        private string Fonction;

        public MembresEquipe(string Nom, string Prénom, string Fonction)
        {
            this.Nom = Nom;
            this.Prénom = Prénom;
            this.Fonction = Fonction;
        }

        public void Membre()
        {
            Console.WriteLine("Bonjour je suis {0} {1} et j'occupe la fonction : {2}",Nom,Prénom,Fonction);
        }

    }

}
