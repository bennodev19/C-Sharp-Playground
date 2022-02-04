using System;
using System.Collections.Generic;
using System.Text;
using PersonalManagement.Models;

namespace PersonalManagement.ViewModels
{
    public class MainWindowViewModel : ViewModelBase
    {
        public MainWindowViewModel()
        {
            SalariedEmployee jeff = new SalariedEmployee("Bezos", "Jeff", 80000);
            Worker elon = new Worker("Musk", "Elon", 9, 18);

            Console.WriteLine("Jeff: " + jeff.ToString());
            Console.WriteLine("Elon: " + elon.ToString());
        }
    }
}