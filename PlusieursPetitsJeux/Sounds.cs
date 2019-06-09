using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlusieursPetitsJeux
{
    class Sounds
    {
        
        int noteDo = 262;
        int noteMi = 330;
        int noteSol = 392;
        int noteDo2 = 523;
        int triolet = 100;
        int noireTrio = 266;
        int blanche = 800;
        int noteRe = 294;
        int noteFa = 349;
        int noire = 400;
        int erreur = 100;
        int tirage = 900;
        int bip;
        int noteSol_g = 98;
        int noteMi_g = 82;
        int noteRe_g = 73;
        int noteDoDieze_g = 69;


        public void Victory ()
        {


            Console.Beep(noteDo, triolet);
            Console.Beep(noteMi, triolet);
            Console.Beep(noteSol, triolet);
            Console.Beep(noteDo2, noireTrio);
            Console.Beep(noteSol, triolet);
            Console.Beep(noteDo2, blanche);
        }

        public void Intro ()
        {


            Console.Beep(noteDo, noire);
            Console.Beep(noteRe, noire);
            Console.Beep(noteMi, noire);
            Console.Beep(noteFa, blanche);

        }

        public void Error ()
        {
            Console.Beep(erreur, blanche);
        }

        public void Suspens ()
        {
            int i;
            for (i = 0; i <= 100; i++)
            {
                Console.Beep(noteMi, noire);
                Console.Beep(noteDo, noire);
                Console.Beep(noteRe, noire);
                noire = noire - i;
                i = i + 20;
            }
            Console.Beep(noteMi, noire);
            Console.Beep(noteDo, noire);
            Console.Beep(noteRe, noire);
            Console.Beep(noteMi, noire);
            Console.Beep(noteFa, blanche);
        }

        public void AnimationTirage ()
        {
            PositionText MiseEnPage = new PositionText();
            Random alea = new Random();
            bip = 50;
            for (int i = 0; i <= 30; i++)
            {
                int aleatoire = alea.Next(0 , 50);
                string aleatoire_string = Convert.ToString(aleatoire);
                MiseEnPage.PasserLignes(10);
                MiseEnPage.CentrerLeTexte(aleatoire_string);
                Console.Beep(tirage, bip);
                Console.Clear();
                bip = bip + (2 *i);

            }


        }

        public void Over()
        {
            Console.Beep(noteSol_g, noire);
            Console.Beep(noteMi_g, noire);
            Console.Beep(noteRe_g, noire);
            Console.Beep(noteDoDieze_g, blanche);
        }

    }
}
