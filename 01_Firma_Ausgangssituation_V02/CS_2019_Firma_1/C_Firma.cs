using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CS_2019_Firma_01
{
    public class C_Firma
    {
        private List<C_Mitarbeiter> Mitarbeiter = null; 
        private C_Mitarbeiterliste MitarbeiterListe = null;
        private C_Mitarbeiterstatistik MitarbeiterStatistik = null;
        private C_Eingabefenster Eingabefenster = null;

        public C_Firma()
        {
            this.Mitarbeiter = new List<C_Mitarbeiter>();
            this.Eingabefenster = new C_Eingabefenster(this, 100, 150);
            this.MitarbeiterListe = new C_Mitarbeiterliste(100, 450);
            this.MitarbeiterStatistik = new C_Mitarbeiterstatistik(400, 450);
            Eingabefenster.Show();
            MitarbeiterListe.Show();
            MitarbeiterStatistik.Show();
        }

      
        public void neuerMitarbeiter(C_Mitarbeiter neuerMitarbeiter)
        {
            this.Mitarbeiter.Add(neuerMitarbeiter);
            MitarbeiterListe.zeigeMitarbeiter(neuerMitarbeiter);
            MitarbeiterStatistik.zeigeDurchschnitt(Mitarbeiter);
        }

   
        public List<C_Mitarbeiter> getMitarbeiter()
        {
            return Mitarbeiter;
        }


    }
}
