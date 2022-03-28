using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CS_2019_Firma_01
{
    public class C_Angestellte : C_Mitarbeiter
    {

        private double dBruttogehalt;

        public C_Angestellte(string strNachname, string strVorname, double dBrutto)
           : base(strNachname, strVorname)
        {

            if (!setBrutto(dBrutto))
            {
                setBrutto(1);
            }

        }

        public bool setBrutto(double dBrutto)
        {
            if (dBrutto > 0)
            {
                this.dBruttogehalt = dBrutto;
                return true;
            }
            else
            {
                return false;
            }
        }

        public override double getBrutto()
        {
            return this.dBruttogehalt;

        }

    }
}
