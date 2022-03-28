using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CS_2019_Firma_01
{
    public abstract class C_Mitarbeiter
    {

        private string strNachname;
        private string strVorname;

        public C_Mitarbeiter(string strNachname, string strVorname)
        {
            this.setNachname(strNachname);
            this.setVorname(strVorname);
        }

        public string getNachname()
        {
            return strNachname;
        }

        public string getVorname()
        {
            return strVorname;
        }

        private void setNachname(string strNachname)
        {
            this.strNachname = strNachname;
        }

        private void setVorname(string strVorname)
        {
            this.strVorname = strVorname;
        }

        public abstract double getBrutto();

        public override string ToString()
        {
            return getNachname() + " " + getVorname() + " \t" + getBrutto() + " EUR";
        }

    }
}
