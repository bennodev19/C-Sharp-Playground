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
    /// Interaktionslogik für C_Eingabefenster.xaml
    /// </summary>
    public partial class C_Eingabefenster : Window
    {
        private static C_Eingabefenster instance;
        private C_Firma MeineFirma = null;

        private C_Eingabefenster(C_Firma Firma, int iTop, int iLeft)
        {
            InitializeComponent();
            MeineFirma = Firma;
            this.Top = iTop;
            this.Left = iLeft;
        }

        public static C_Eingabefenster getInstance(C_Firma Firma, int iTop, int iLeft)
        {
            if (instance == null)
            {
                instance = new C_Eingabefenster(Firma, iTop, iLeft);
            }
            return instance;
        }

        private void BtnHinzufuegen_Click(object sender, RoutedEventArgs e)
        {
            if (tabAngestellte.IsSelected)
            {
                string strVorname = txtAngestelltVorname.Text;
                string strNachname = txtAngestelltNachname.Text;
                double dBruttolohn;

                if (double.TryParse(txtAngestelltBruttolohn.Text, out dBruttolohn))
                {
                    //Anlage eines neuen Angestellten
                    C_Angestellte Angestellte = new C_Angestellte(strNachname, strVorname, dBruttolohn);
                    //Hinzufügen des Angestellten als neuen Mitarbeiter
                    MeineFirma.neuerMitarbeiter(Angestellte);

                    //Bereinigung der Eingabefenster
                    txtAngestelltVorname.Text = "";
                    txtAngestelltNachname.Text = "";
                    txtAngestelltBruttolohn.Text = "";
                }
            
            } else if (tabArbeiter.IsSelected)
            {
                string strVorname = txtArbeiterVorname.Text;
                string strNachname = txtArbeiterNachname.Text;
                int iStunden;
                double dStundenlohn;

                if (int.TryParse(txtArbeiterStunden.Text, out iStunden) &&
                    double.TryParse(txtArbeiterStundenlohn.Text, out dStundenlohn)
                    )
                {
                    C_Arbeiter Arbeiter = new C_Arbeiter(strNachname, strVorname, iStunden, dStundenlohn);
                    MeineFirma.neuerMitarbeiter(Arbeiter);
                    
                    //Bereinigung der Eingabefenster
                    txtArbeiterNachname.Text = "";
                    txtArbeiterVorname.Text = "";
                    txtArbeiterStunden.Text = "";
                    txtArbeiterStundenlohn.Text = "";

                }
            }
        }

        

    }
}
