using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CS_2019_Firma_01
{
    public class C_Arbeiter : C_Mitarbeiter
    {

        private int iStunden;
        private double dStundenlohn;

        public C_Arbeiter(string strNachname, string strVorname, int iStunden, double dStundenlohn) : base(strNachname, strVorname)
        {
            if (!setStunden(iStunden))
            {
                setStunden(0);
            }
            
            if (!setStundenlohn(dStundenlohn))
            {
                setStundenlohn(12);
            }
        }

        public bool setStunden(int iStunden)
        {
            if (iStunden >= 0)
            {
                this.iStunden = iStunden;
                return true;
            }
            else
            {
                return false;
            }
        }
        public bool setStundenlohn(double dStundenlohn)
        {
            if (dStundenlohn > 0)
            {
                this.dStundenlohn = dStundenlohn;
                return true;
            }
            else
            {
                return false;
            }

        }

        public override double getBrutto()
        {
            //Stundenlohn pro Woche * Anzahl Jahreswochen * Lohn
            return this.iStunden * 52 * this.dStundenlohn;
        }




    }
}
