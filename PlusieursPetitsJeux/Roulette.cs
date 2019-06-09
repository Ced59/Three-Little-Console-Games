using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlusieursPetitsJeux
{
    class Roulette
    {

        public void JeuRoulette ( string pseudo )
        {
            int gold = 10000;
            int mise = 0;
            int jeu = 0;
            int gain = 0;

            Console.Clear();

            PositionText MiseEnPage = new PositionText();
            Sounds Play = new Sounds();
            VerifEntree Solde = new VerifEntree();



            MiseEnPage.CentrerLeTexte("/////////////////////////");
            MiseEnPage.CentrerLeTexte("/                       0");
            MiseEnPage.CentrerLeTexte("/    Jeu de Roulette    0");
            MiseEnPage.CentrerLeTexte("/                       0");
            MiseEnPage.CentrerLeTexte("0000000000000000000000000");

            MiseEnPage.PasserLignes(3);
            MiseEnPage.CentrerLeTexte("Bienvenue " + pseudo);

            MiseEnPage.PasserLignes(2);

            MiseEnPage.CentrerLeTexte("Règles: ");
            MiseEnPage.PasserLignes(1);
            MiseEnPage.CentrerLeTexte("Vous disposez de 10000 euros pour jouer au casino.");
            MiseEnPage.CentrerLeTexte("Vous devez choisir un numéro compris entre 0 et 49.");
            MiseEnPage.CentrerLeTexte("Si votre numéro est gagnant, vous remportez 3 fois votre mise.");
            MiseEnPage.CentrerLeTexte("Les numéros pairs sont de couleur noire, les impairs de couleur rouge.");
            MiseEnPage.CentrerLeTexte("Si votre couleur est tirée, vous gagnez 50% de votre mise initiale.");
            MiseEnPage.CentrerLeTexte("Les valeurs sont arrondies aux nombres entiers inférieurs.");
            MiseEnPage.CentrerLeTexte("Bonne chance!!");
            MiseEnPage.PasserLignes(4);


            Play.Intro();

            


            MiseEnPage.CentrerLeTexte("Vous avez " + gold + "Euros.");
            MiseEnPage.PasserLignes(2);


            while (Solde.Solde(gold))
            {
                
                string mise_string;
                MiseEnPage.CentrerLeTexte("Combien voulez-vous miser??");
                mise_string = Console.ReadLine();
                bool verify_entry = false;
                bool verify_entry_gamer = false;

                while (!verify_entry || !verify_entry_gamer)
                {

                    while (!verify_entry)
                    {
                        while (!Solde.GoodEntryNumber(mise_string)) // Test si bien nombre entier entré
                        {
                            MiseEnPage.CentrerLeTexte("Vous devez entrer un nombre entier!");
                            MiseEnPage.PasserLignes(1);
                            Play.Error();
                            MiseEnPage.CentrerLeTexte("Combien voulez-vous miser??");
                            mise_string = Console.ReadLine();
                        }

                        mise = Convert.ToInt32(mise_string); // Conversion en Int

                        if (!Solde.GoodEntryNumberBetween(mise, 1, gold))
                        {
                            MiseEnPage.CentrerLeTexte("Vous n'avez pas assez d'argent!!");
                            MiseEnPage.PasserLignes(1);
                            Play.Error();
                            MiseEnPage.CentrerLeTexte("Combien voulez-vous miser??");
                            mise_string = Console.ReadLine();
                        }
                        else
                        {
                            verify_entry = true;
                            
                        }

                    }




                    while (!verify_entry_gamer)
                    {

                        string jeu_string;
                        MiseEnPage.PasserLignes(1);
                        MiseEnPage.CentrerLeTexte("Quel numéro voulez-vous jouer??");
                        jeu_string = Console.ReadLine();

                        while (!Solde.GoodEntryNumber(jeu_string)) // Test si bien nombre entier entré
                        {
                            MiseEnPage.CentrerLeTexte("Vous devez entrer un nombre entier!");
                            MiseEnPage.PasserLignes(1);
                            Play.Error();
                            MiseEnPage.CentrerLeTexte("Quel numéro voulez-vous jouer??");
                            jeu_string = Console.ReadLine();
                        }

                        jeu = Convert.ToInt32(jeu_string); // Conversion en Int

                        if (!Solde.GoodEntryNumberBetween(jeu, 0, 49))
                        {
                            MiseEnPage.CentrerLeTexte("Vous devez jouer un nombre entre 0 et 49!!");
                            MiseEnPage.PasserLignes(1);
                            Play.Error();
                            MiseEnPage.CentrerLeTexte("Quel numéro voulez-vous jouer??");
                            jeu_string = Console.ReadLine();
                        }
                        else
                        {
                            verify_entry_gamer = true;
                            
                        }

                        

                    }

                  
                }


                
                Random alea = new Random(); 
                int bingo = alea.Next(0, 50); //Definition du nombre aléatoire gagnant.
                
                // Animation tirage

                Play.AnimationTirage();

                Console.Clear();
                string bingo_string = Convert.ToString(bingo);
                MiseEnPage.PasserLignes(10);
                MiseEnPage.CentrerLeTexte(bingo_string);

                if (jeu == bingo)
                {                   
                    Play.Victory();
                    MiseEnPage.CentrerLeTexte("Vous avez gagné le gros lot!!!");
                    gain = mise * 3;
                    gold = gold + gain;
                    MiseEnPage.PasserLignes(1);
                    MiseEnPage.CentrerLeTexte("Vous avez désormais " + gold + "euros!");
                    Console.ReadKey(true);
                    Console.Clear();
                }

                else if ((jeu % 2 == 0) && (bingo % 2 == 0))
                {
                    Play.Victory();
                    MiseEnPage.CentrerLeTexte("Votre numéro et le tirage sont noirs!!");
                    gain = mise / 2;
                    gold = gold + gain;
                    MiseEnPage.PasserLignes(1);
                    MiseEnPage.CentrerLeTexte("Vous avez gagné: " + gain + " euros!");
                    MiseEnPage.PasserLignes(1);
                    MiseEnPage.CentrerLeTexte("Vous avez désormais " + gold + "euros!");
                    Console.ReadKey(true);
                    Console.Clear();
                }

                else if ((jeu % 2 != 0) && (bingo % 2 != 0))
                {
                    Play.Victory();
                    MiseEnPage.CentrerLeTexte("Votre numéro et le tirage sont rouges!!");
                    gain = mise / 2;
                    gold = gold + gain;
                    MiseEnPage.PasserLignes(1);
                    MiseEnPage.CentrerLeTexte("Vous avez gagné: " + gain + " euros!");
                    MiseEnPage.PasserLignes(1);
                    MiseEnPage.CentrerLeTexte("Vous avez désormais " + gold + "euros!");
                    Console.ReadKey(true);
                    Console.Clear();
                }

                else
                {
                    Play.Over();
                    MiseEnPage.CentrerLeTexte("Vous avez perdu!!!");
                    gold = gold - mise;
                    MiseEnPage.PasserLignes(1);
                    MiseEnPage.CentrerLeTexte("Vous avez désormais " + gold + "euros!");
                    Console.ReadKey(true);
                    Console.Clear();
                }

                if (gold <= 0)
                {
                    break;
                }


            }

            MiseEnPage.PasserLignes(2);
            MiseEnPage.CentrerLeTexte("Votre solde est tombé à zéro. Vous avez tout perdu...");

            Console.ReadKey(true);



        }
    }
}
