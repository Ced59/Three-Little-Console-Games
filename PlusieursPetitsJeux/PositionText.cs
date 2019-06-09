using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlusieursPetitsJeux
{
    class PositionText
    {

        public void CentrerLeTexte ( string texte )
        {
            int nbEspaces = (Console.WindowWidth - texte.Length) / 2;
            Console.SetCursorPosition(nbEspaces, Console.CursorTop);
            Console.WriteLine(texte);
        }

        public void PasserLignes (int nbre)
        {
            for (int i = 1; i<nbre; i++)
            {
                Console.WriteLine(Environment.NewLine);
            }
            
           
        }

        public void Tab (string texte , int nbre)
        {
            string espace = "";
            for (int i = 1; i <= nbre; i++)
            {
                espace = espace + " ";
            }

            Console.WriteLine(espace + texte);
        }

       
    }
}
