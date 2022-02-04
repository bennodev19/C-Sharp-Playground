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
            SalariedEmployee jeff = new SalariedEmployee("Hello", "Jeff", 80000);
            Worker jeff2 = new Worker("Bye", "Jeff", 9, 18);

            Console.WriteLine("Jeff: " + jeff.ToString());
            Console.WriteLine("Jeff2: " + jeff2.ToString());
        }
    }
}