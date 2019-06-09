using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlusieursPetitsJeux
{
    class Program
    {
        
        static void Main ( string[] args )
        {
            int choice = 0;

            PositionText MiseEnPage = new PositionText(); 
            VerifEntree Verif = new VerifEntree();

            MiseEnPage.PasserLignes(4);

            MiseEnPage.CentrerLeTexte("#################");
            MiseEnPage.CentrerLeTexte("#               /");
            MiseEnPage.CentrerLeTexte("#   Bienvenue   /");
            MiseEnPage.CentrerLeTexte("#               /");
            MiseEnPage.CentrerLeTexte("/////////////////");


            Sounds Play = new Sounds();
            Play.Intro();

            MiseEnPage.PasserLignes(4);

            string pseudo = "pseudo";

            Console.WriteLine("Quel est votre pseudo?? ");
            pseudo = Console.ReadLine();

            Console.Clear();

            MiseEnPage.CentrerLeTexte("Bienvenue " + pseudo);
            MiseEnPage.PasserLignes(4);

            MiseEnPage.Tab("Choisissez votre jeu:", 4);
            MiseEnPage.PasserLignes(2);
            MiseEnPage.Tab("Tirage du Loto => Choix 1.", 8);
            MiseEnPage.Tab("Jeu de la roulette => Choix 2.", 8);
            MiseEnPage.Tab("Jeu du \"Plus ou Moins\" => Choix 3.", 8);
            MiseEnPage.PasserLignes(2);
            MiseEnPage.Tab("Votre choix: ", 0);
            string saisie = Console.ReadLine();

            bool verif_entry = false;
            
            while (!verif_entry)
            { 
                while (!Verif.GoodEntryNumber(saisie))
                {              
                    Console.WriteLine("Vous devez entrer un nombre valide pour le choix du jeu!");
                    Play.Error();
                    Console.WriteLine("Votre choix : ");
                    saisie = Console.ReadLine();        
                }

                choice = Convert.ToInt32(saisie); //Convert to Int 

                if (!Verif.GoodEntryNumberBetween(choice, 1, 3))
                {
                    Console.WriteLine("Vous devez entrer un nombre entre 1 et 3 pour le choix du jeu!");
                    Play.Error();
                    Console.WriteLine("Votre choix : ");
                    saisie = Console.ReadLine();
                    verif_entry = false;
                }
                else
                {
                    verif_entry = true;
                }
            }

            if (choice == 1)
            {
                Loto JeuLoto = new Loto();
                JeuLoto.JeuLoto(pseudo);
            }

            if (choice == 2)
            {
                Roulette JeuRoulette = new Roulette();
                JeuRoulette.JeuRoulette(pseudo);
            }

            if (choice == 3)
            {
                PlusOuMoins JeuPlusOuMoins = new PlusOuMoins();
                JeuPlusOuMoins.JeuPlusOuMoins(pseudo);
            }

        }

        

    }
}
