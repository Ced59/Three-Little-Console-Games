using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlusieursPetitsJeux
{
    class Loto
    {
        public void JeuLoto ( string pseudo )
        {


            Console.Clear();

            PositionText MiseEnPage = new PositionText();
            Sounds Play = new Sounds();

            

            MiseEnPage.CentrerLeTexte("////////////////////////");
            MiseEnPage.CentrerLeTexte("/                      0");
            MiseEnPage.CentrerLeTexte("/    Tirage du Loto    0");
            MiseEnPage.CentrerLeTexte("/                      0");
            MiseEnPage.CentrerLeTexte("000000000000000000000000");

            MiseEnPage.PasserLignes(3);
            MiseEnPage.CentrerLeTexte("Bienvenue " + pseudo);

            MiseEnPage.PasserLignes(2);

            MiseEnPage.CentrerLeTexte("Règles: ");
            MiseEnPage.PasserLignes(1);
            MiseEnPage.CentrerLeTexte("Vous devez tirer 7 numéros entre 1 et 49.");
            MiseEnPage.CentrerLeTexte("Un tirage aléatoire sera ensuite éffectué.");
            MiseEnPage.CentrerLeTexte("Votre score correspondra au nombre de bons numéros choisis qui seront tirés.");
            MiseEnPage.CentrerLeTexte("Bonne chance!!");
            MiseEnPage.PasserLignes(4);

            Play.Intro();


            int[] tirage_joueur = new int[] { 0 , 0 , 0 , 0 , 0 , 0 , 0 }; // On définit le tableau du jeu du joueur.


            int valeur = -1;
            for (int i = 0; i < tirage_joueur.Length; i++)
            {
                bool test_egalite = false;

                while (!test_egalite) // On teste les entrées du joueur (bien un nombre compris entre 1 et 49, et qui n'a pas été entré précédemment)
                {
                    while (( tirage_joueur[i] < 1 ) || ( tirage_joueur[i] > 49 ))
                    {
                        bool saisie_is_valid = false;
                        while (!saisie_is_valid)
                        {
                            Console.WriteLine("Veuillez entrer le numéro n° " + ( i + 1 ));
                            string saisie = Console.ReadLine();
                            MiseEnPage.PasserLignes(2);
                            if (int.TryParse(saisie, out valeur))
                            {
                                saisie_is_valid = true;
                            }
                            else
                            {
                                saisie_is_valid = false;
                                Console.WriteLine("Vous n'avez pas entré un nombre correct. Veuillez recommencer!");
                                Play.Error();

                            }
                        }

                        if (( valeur < 1 ) || ( valeur > 49 ))
                        {
                            Console.WriteLine("Le nombre doit être compris entre 1 et 49! Veuillez recommencer!");
                            Play.Error();
                        }

                        else
                        {
                            break;
                        }

                    }

                    for (int j = 0; j < tirage_joueur.Length; j++)  // On verifie que le joueur n'a pas entré deux nombres égaux
                    {
                        if (tirage_joueur[j] == valeur)
                        {
                            test_egalite = false;
                            Console.WriteLine("Vous devez entrer des nombres différents!");
                            Play.Error();
                            break;
                        }
                        else
                        {
                            test_egalite = true;
                        }
                    }
                }

                tirage_joueur[i] = valeur;   // Quand toutes les vérifications sont faites, on insère le nombre du joueur dans le tableau.
            }


            Console.WriteLine(Environment.NewLine);
            Console.WriteLine("Voici votre jeu: " + tirage_joueur[0] + " " + tirage_joueur[1] + " " + tirage_joueur[2] + " " + tirage_joueur[3] + " " + tirage_joueur[4] + " " + tirage_joueur[5] + " " + tirage_joueur[6]);
            Console.WriteLine(Environment.NewLine);
            Console.WriteLine("Attention! On va procéder au tirage du Loto!!");
            Console.WriteLine(Environment.NewLine);
            Play.Suspens();


            int[] tirage_loto = TirageLoto(); //On récupère la valeur du tableau aléatoire dans un nouveau tableau

            Console.WriteLine("Les numéros gagnants sont: " + tirage_loto[0] + " " + tirage_loto[1] + " " + tirage_loto[2] + " " + tirage_loto[3] + " " + tirage_loto[4] + " " + tirage_loto[5] + " " + tirage_loto[6]);

            Console.WriteLine(Environment.NewLine);
            Console.WriteLine("Vous avez trouvé " + NumerosGagnants(tirage_joueur, tirage_loto) + " bons numéros!!!");
            Console.WriteLine(Environment.NewLine);
            Play.Victory();

            Console.WriteLine("Vous voulez faire quoi?");
            MiseEnPage.Tab("Rejouer: Tapez R", 4);
            MiseEnPage.Tab("Retour au menu: Tapez M", 4);
            MiseEnPage.Tab("Quitter: Tapez n'importe quelle autre touche.", 4); // A finir voir comment rappeler Main

            ConsoleKeyInfo test = Console.ReadKey(true);

            




        }










        static int[] TirageLoto () //Définition de la méthode qui renverra la valeur du tableau aléatoire du tirage du Loto
        {
            int[] alea = new int[] { 0 , 0 , 0 , 0 , 0 , 0 , 0 };

            Random aleatoire = new Random();

            for (int i = 0; i < alea.Length; i++)
            {


                alea[i] = aleatoire.Next(1, 50);  // On attribue une valeur aléatoire entre 1 et 49

                for (int j = 0; j < i; j++)
                {
                    if (alea[j] == alea[i])
                    {
                        alea[j] = aleatoire.Next(0, 50);// Si égalité avec une case précédente du tableau on réaffecte un nouveau nombre aléatoire au rang j
                        i = 0; //On réinitialise la boucle pour comparer la dernière valeur avec les entrées déjà présentes
                    }
                }

            }


            return alea; // On retourne le tableau aléatoire

        }


        static int NumerosGagnants ( int[] joueur, int[] loto ) //On créé une methode pour comparer les résultats avec le jeu, qui renverra le nombre de numéros gagnants joués par le joueur
        {
            int result = 0;
            for (int i = 0; i < joueur.Length; i++)
            {
                for (int j = 0; j < loto.Length; j++)
                {
                    if (joueur[i] == loto[j])
                    {
                        result += 1;
                    }
                }
            }

            return result;

        }
    }
}
