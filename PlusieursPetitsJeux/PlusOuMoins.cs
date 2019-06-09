using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlusieursPetitsJeux
{
    class PlusOuMoins
    {
        public void JeuPlusOuMoins(string pseudo)
        {
            Console.Clear();

            PositionText MiseEnPage = new PositionText();
            Sounds Play = new Sounds();
            VerifEntree GoodInt = new VerifEntree();

            int Borne_Inf = 0;
            int Borne_Sup = 0;
            int alea;
            int Player_Entry = 0;
            bool verify_entry = false;
            bool win = false;
            int tour = 0;



            MiseEnPage.CentrerLeTexte("//////////////////////////////");
            MiseEnPage.CentrerLeTexte("/                            0");
            MiseEnPage.CentrerLeTexte("/    Jeu du Plus ou Moins    0");
            MiseEnPage.CentrerLeTexte("/                            0");
            MiseEnPage.CentrerLeTexte("000000000000000000000000000000");

            MiseEnPage.PasserLignes(3);
            MiseEnPage.CentrerLeTexte("Bienvenue " + pseudo);

            MiseEnPage.PasserLignes(2);

            MiseEnPage.CentrerLeTexte("Règles: ");
            MiseEnPage.PasserLignes(1);
            MiseEnPage.CentrerLeTexte("Un nombre aléatoire sera tiré entre deux bornes que vous aurez définies.");
            MiseEnPage.CentrerLeTexte("Le but du jeu sera de trouver ce nombre en un minimum de coups.");
            MiseEnPage.CentrerLeTexte("Le jeu vous dira si le nombre à chercher est supérieur ou inférieur à celui entré.");
            MiseEnPage.CentrerLeTexte("Bonne chance!!");
            MiseEnPage.PasserLignes(4);

            Play.Intro();



            


            while (!verify_entry)
            {
                string String_Player_Entry;
                MiseEnPage.CentrerLeTexte("Veuillez entrer la borne inférieure: ");
                String_Player_Entry = Console.ReadLine();
                MiseEnPage.PasserLignes(1);
                

                while (!GoodInt.GoodEntryNumber(String_Player_Entry)) // Test si bien nombre entier entré
                {
                    MiseEnPage.CentrerLeTexte("Vous devez entrer un nombre entier!");
                    MiseEnPage.PasserLignes(1);
                    Play.Error();
                    MiseEnPage.CentrerLeTexte("Veuillez entrer la borne inférieure: ");
                    String_Player_Entry = Console.ReadLine();
                }

                Borne_Inf = Convert.ToInt32(String_Player_Entry);

                MiseEnPage.CentrerLeTexte("Veuillez entrer la borne supérieure: ");
                String_Player_Entry = Console.ReadLine();
                MiseEnPage.PasserLignes(1);
                
                while (!GoodInt.GoodEntryNumber(String_Player_Entry))
                {
                    MiseEnPage.CentrerLeTexte("Vous devez entrer un nombre entier!");
                    MiseEnPage.PasserLignes(1);
                    Play.Error();
                    MiseEnPage.CentrerLeTexte("Veuillez entrer la borne supérieure: ");
                    String_Player_Entry = Console.ReadLine();
                }

                Borne_Sup = Convert.ToInt32(String_Player_Entry);

                if (Borne_Sup <= Borne_Inf)
                {
                    MiseEnPage.CentrerLeTexte("La borne supérieure doit être strictement supérieure à l'inférieure!!");
                    verify_entry = false;
                    Play.Error();
                }

                else
                {
                    verify_entry = true;
                }

            }

            Random bingo = new Random();
            alea = bingo.Next(Borne_Inf, Borne_Sup+1); //Definition du nombre aléatoire gagnant.
            

            while (!win)
            {
                verify_entry = false;
                while (!verify_entry)
                {
                    string String_Player_Entry;
                    MiseEnPage.CentrerLeTexte("Entrez votre choix entre " + Borne_Inf + " et " + Borne_Sup);
                    String_Player_Entry = Console.ReadLine();
                    MiseEnPage.PasserLignes(1);

                    while (!GoodInt.GoodEntryNumber(String_Player_Entry))
                    {
                        MiseEnPage.CentrerLeTexte("Vous devez entrer un nombre entier!!");
                        MiseEnPage.PasserLignes(1);
                        Play.Error();
                        MiseEnPage.CentrerLeTexte("Entrez votre choix entre " + Borne_Inf + " et " + Borne_Sup);
                        String_Player_Entry = Console.ReadLine();

                    }

                    Player_Entry = Convert.ToInt32(String_Player_Entry);

                    if ((Player_Entry < Borne_Inf) || (Player_Entry > Borne_Sup))
                    {
                        MiseEnPage.CentrerLeTexte("Vous devez entrer un nombre entre " + Borne_Inf + " et " + Borne_Sup + " !!!");
                        
                        verify_entry = false;
                    }
                    else
                    {
                        verify_entry = true;
                    }
                }

                tour = tour + 1;

                if (verify_entry == true)
                {

                
                    if (Player_Entry == alea)
                    {
                        MiseEnPage.PasserLignes(1);
                        MiseEnPage.CentrerLeTexte("Bravo!!!!");
                        MiseEnPage.CentrerLeTexte("Vous avez trouvé le bon numéro en " + tour + " tours!!");
                        MiseEnPage.PasserLignes(1);
                        Play.Victory();
                        win = true;
                    }

                    else if (Player_Entry < alea)
                    {
                        MiseEnPage.PasserLignes(1);
                        MiseEnPage.CentrerLeTexte("Tour " + tour);
                        MiseEnPage.CentrerLeTexte("Faux!! Le nombre recherché est supérieur à " + Player_Entry + "!!!");
                        MiseEnPage.PasserLignes(1);
                        Play.Error();
                        win = false;
                        verify_entry = false;
                        Borne_Inf = Player_Entry;
                    }

                    else
                    {
                        MiseEnPage.PasserLignes(1);
                        MiseEnPage.CentrerLeTexte("Tour " + tour);
                        MiseEnPage.CentrerLeTexte("Faux!! Le nombre recherché est inférieur à " + Player_Entry + "!!!");
                        MiseEnPage.PasserLignes(1);
                        Play.Error();
                        win = false;
                        verify_entry = false;
                        Borne_Sup = Player_Entry;
                    }

                }
            }

            Console.ReadKey();
        }
    }
}
