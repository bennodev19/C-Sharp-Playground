using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace CS_2019_Firma_01
{
    /// <summary>
    /// Interaktionslogik für C_Mitarbeiterstatistik.xaml
    /// </summary>
    public partial class C_Mitarbeiterstatistik : Window
    {
        private static C_Mitarbeiterstatistik instance;
        
        public C_Mitarbeiterstatistik(int iTop, int iLeft)
        {
            InitializeComponent();
            this.Top = iTop;
            this.Left = iLeft;
        }

        public static C_Mitarbeiterstatistik getInstance(int iTop, int iLeft)
        {
            if (instance == null)
            {
                instance = new C_Mitarbeiterstatistik(iTop, iLeft);
            }
            return instance;
        }
        public void zeigeDurchschnitt(List<C_Mitarbeiter> MeineMitarbeiter)
        {
            double dSumme = 0.0;
            int iAnzahl = MeineMitarbeiter.Count();
            double dDurchschnitt = 0.0;

            foreach (var Eintrag in MeineMitarbeiter)
            {
                dSumme += Eintrag.getBrutto();
             }

            dDurchschnitt = dSumme / iAnzahl;

            txtDurchschnitt.Text = Math.Round(dDurchschnitt, 2).ToString() + " EUR";

        }

    }
}
