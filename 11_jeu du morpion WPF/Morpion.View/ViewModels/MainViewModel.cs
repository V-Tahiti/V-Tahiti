using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.CommandWpf;
using System;
using System.Linq;
using System.Windows;
using System.Windows.Input;

namespace Morpion.View.ViewModels
{
    /// <summary>
    /// This class contains properties that the main View can data bind to.
    /// <para>
    /// Use the <strong>mvvminpc</strong> snippet to add bindable properties to this ViewModel.
    /// </para>
    /// <para>
    /// You can also use Blend to data bind with the tool's support.
    /// </para>
    /// <para>
    /// See http://www.galasoft.ch/mvvm
    /// </para>
    /// </summary>
    public class MainViewModel : ViewModelBase
    {
        private string text1;
        public string Text1
        {
            get { return text1; }
            set { Set(() => Text1, ref text1, value); }
        }
        private string text2;
        public string Text2
        {
            get { return text2; }
            set { Set(() => Text2, ref text2, value); }
        }
        private string text3;
        public string Text3
        {
            get { return text3; }
            set { Set(() => Text3, ref text3, value); }
        }
        private string text4;
        public string Text4
        {
            get { return text4; }
            set { Set(() => Text4, ref text4, value); }
        }
        private string text5;
        public string Text5
        {
            get { return text5; }
            set { Set(() => Text5, ref text5, value); }
        }
        private string text6;
        public string Text6
        {
            get { return text6; }
            set { Set(() => Text6, ref text6, value); }
        }
        private string text7;
        public string Text7
        {
            get { return text7; }
            set { Set(() => Text7, ref text7, value); }
        }
        private string text8;
        public string Text8
        {
            get { return text8; }
            set { Set(() => Text8, ref text8, value); }
        }
        private string text9;
        public string Text9
        {
            get { return text9; }
            set { Set(() => Text9, ref text9, value); }
        }

        //public ICommand SelecCommand => new RelayCommand<string>(s => Select(s));
        public ICommand SelectCommand => new RelayCommand<string>(Select);

        private void Select(string text)
        {
            //C'est la même chose qu'en bas /// Text1 = Text1 ?? Choix(); ////
            //if (Text1 == null)
            //{
            // Choix();
            //}
            switch (text)
            {

                case "Text1":
                    Text1 = Text1 ?? Choix();
                    break;
                case "Text2":
                    Text2 = Text2 ?? Choix();
                    break;
                case "Text3":
                    Text3 = Text3 ?? Choix();
                    break;
                case "Text4":
                    Text4 = Text4 ?? Choix();
                    break;
                case "Text5":
                    Text5 = Text5 ?? Choix();
                    break;
                case "Text6":
                    Text6 = Text6 ?? Choix();
                    break;
                case "Text7":
                    Text7 = Text7 ?? Choix();
                    break;
                case "Text8":
                    Text8 = Text8 ?? Choix();
                    break;
                case "Text9":
                    Text9 = Text9 ?? Choix();
                    break;
            }
            if (Verification())
            {
                MessageBox.Show($"Winner {winner}");
                Clear();
            }
            if ((Text1 + Text2 + Text3 + Text4 + Text5 + Text6 + Text7 + Text8 + Text9)?.Count() == 9)
            {
                MessageBox.Show("Game Over");
                Clear();
            }
        }

        private void Clear()
        {
            Text1=null;
            Text2 = null;
            Text3 = null;
            Text4 = null;
            Text5 = null;
            Text6 = null;
            Text7 = null;
            Text8 = null;
            Text9 = null;
            parity = 0;
            winner = null;
        }

        private bool Verification()
        {
            return
                Verif(Text1 + text2 + text3) ||
                Verif(Text4 + text5 + text6) ||
                Verif(Text7 + text8 + text9) ||

                Verif(Text1 + text4 + text7) ||
                Verif(Text2 + text5 + text8) ||
                Verif(Text3 + text6 + text9) ||

                Verif(Text1 + text5 + text9) ||
                Verif(Text3 + text5 + text7);
        }
        string winner;

        private bool Verif(string textes)
        {
            if (textes == "XXX")
                winner = "Joueur 1";
            if (textes == "OOO")
                winner = "Joueur 2";
            return winner != null;
        }
        //private bool Verif(string textes)
        //{
        //    switch (textes)
        //    {
        //        case "XXX"
        //        default:
        //            break;
        //    }
        //    return winner != null;

        //}

        private int parity = 0;
        private string Choix()
        {
            return parity++ % 2 == 0 ? "X" : "O";
        }

    }
}