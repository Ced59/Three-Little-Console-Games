using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlusieursPetitsJeux
{
    class VerifEntree
    {
        public bool GoodEntryNumber( string saisie)
        {
            int test = 0;
            bool saisie_is_valid = false;

            if (int.TryParse(saisie, out test))
            {
                saisie_is_valid = true;
                return saisie_is_valid;
            }
            else
            {
                saisie_is_valid = false;
                return saisie_is_valid;
            }
        }


        public bool GoodEntryNumberBetween ( int saisie, int borne_inf, int borne_sup )
        {
            bool test = false;
            if ((saisie <= borne_sup) && (saisie >= borne_inf))
            {
                test = true;
                return test;
            }
            else
            {
                test = false;
                return test;
            }

        }

        public bool Solde (int saisie)
        {
            bool result = false;

            if (saisie > 0)
            {
                result = true;
                return result;
            }

            else
            {
                result = false;
                return result;
            }
        }

       
    }
}
