using System;

namespace Postage
{
    class Program
    {
        static void Main(string[] args)
        {
            A4 page1 = new A4();
            page1.Message = "Bonjour on va y à arriver!!!";

            A3 page2 = new A3();
            page2.Message = "et voilà!";
            A3 page3 = new A3();
            page3.Message = "Miam miam";

            Package package1 = new Package("Adrien", "Delarue", "14 rue Jean Vaillée");
            Cloth cloth1 = new Cloth();
            Cloth cloth2 = new Cloth();
            Toy toy1 = new Toy();
            Toy toy2 = new Toy();
            
            
            Letter letter1 = new Letter("Adrien", "Delarue","14 rue Jean Vaillée");
            Letter letter2 = new Letter("Luc", "Melun".ToUpper(), "23 Rue Dardeville") ;
            Letter letter3 = new Letter("Mathieu", "Genoux".ToUpper(), "10 jean Val Jean");


            //letter1.FirstName = "Adrien";
            //letter1.LastName = "Delarue".ToUpper();
            //letter1.Address = "14 rue Jean Val Jean";

            letter1.ListBasePage.Add(page1);
            letter2.ListBasePage.Add(page2);
            letter3.ListBasePage.Add(page3);

            package1.ListBasePackage.Add(cloth1);
            package1.ListBasePackage.Add(cloth2);
            package1.ListBasePackage.Add(toy1);
            package1.ListBasePackage.Add(toy2);
            

            Console.WriteLine(letter1.Weight);
            Console.Read();

        }

    }
}
