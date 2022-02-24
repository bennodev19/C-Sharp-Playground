using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using PersonalManagement.Models;
using ReactiveUI;

namespace PersonalManagement.ViewModels
{
    public class MainWindowViewModel : ViewModelBase
    {
        // Button callbacks
        public ICommand onAdd { get; }
        public ICommand onShowAll { get; }

        private string? _employeeFirstName;

        public string? employeeFirstName
        {
            get => _employeeFirstName;
            // RaiseAndSetIfChanged() notifies (re-renders) the UI if it is called
            // -> everytime the ItemName property is updated it is called in the setter method.
            // https://docs.avaloniaui.net/docs/data-binding/change-notifications
            set => this.RaiseAndSetIfChanged(ref _employeeFirstName, value);
        }

        private string? _employeeLastName;

        public string? employeeLastName
        {
            get => _employeeLastName;
            // RaiseAndSetIfChanged() notifies (re-renders) the UI if it is called
            // -> everytime the ItemName property is updated it is called in the setter method.
            // https://docs.avaloniaui.net/docs/data-binding/change-notifications
            set => this.RaiseAndSetIfChanged(ref _employeeLastName, value);
        }

        private int? _salariedEmployeeSalary;

        public int? salariedEmployeeSalary
        {
            get => _salariedEmployeeSalary;
            // RaiseAndSetIfChanged() notifies (re-renders) the UI if it is called
            // -> everytime the ItemName property is updated it is called in the setter method.
            // https://docs.avaloniaui.net/docs/data-binding/change-notifications
            set => this.RaiseAndSetIfChanged(ref _salariedEmployeeSalary, value);
        }

        private int? _workerHoursSalary;

        public int? workerHoursSalary
        {
            get => _workerHoursSalary;
            // RaiseAndSetIfChanged() notifies (re-renders) the UI if it is called
            // -> everytime the ItemName property is updated it is called in the setter method.
            // https://docs.avaloniaui.net/docs/data-binding/change-notifications
            set => this.RaiseAndSetIfChanged(ref _workerHoursSalary, value);
        }

        private int? _workerWorkedHours;

        public int? workerWorkedHours
        {
            get => _workerWorkedHours;
            // RaiseAndSetIfChanged() notifies (re-renders) the UI if it is called
            // -> everytime the ItemName property is updated it is called in the setter method.
            // https://docs.avaloniaui.net/docs/data-binding/change-notifications
            set => this.RaiseAndSetIfChanged(ref _workerWorkedHours, value);
        }

        // or using a ListBox (https://docs.avaloniaui.net/docs/controls/listbox)
        private string? _output;

        public string? output
        {
            get => _output;
            // RaiseAndSetIfChanged() notifies (re-renders) the UI if it is called
            // -> everytime the ItemName property is updated it is called in the setter method.
            // https://docs.avaloniaui.net/docs/data-binding/change-notifications
            set => this.RaiseAndSetIfChanged(ref _output, value);
        }

        private EmployeeManager employeeManager;

        public MainWindowViewModel()
        {
            // SalariedEmployee jeff = new SalariedEmployee("Bezos", "Jeff", 80000);
            // Worker elon = new Worker("Musk", "Elon", 9, 18);
            //
            // Console.WriteLine("Jeff: " + jeff.ToString());
            // Console.WriteLine("Elon: " + elon.ToString());

            this.employeeManager = new EmployeeManager();

            // Register Callbacks
            this.onAdd = ReactiveCommand.Create(async () => { this.addEmployee(); });
            this.onShowAll = ReactiveCommand.Create(async () => { this.showAllEmployees(); });
        }

        private bool addEmployee()
        {
            // Add Worker (TODO optimize)
            if (this.workerHoursSalary.HasValue || this.workerWorkedHours.HasValue)
            {
                // Validate Worker
                if (!this.workerHoursSalary.HasValue || !this.workerWorkedHours.HasValue ||
                    this.employeeFirstName == null || this.employeeLastName == null)
                {
                    // TODO Error
                    Console.WriteLine("Invalid Input provided for Worker!");
                    return false;
                }

                // Add Worker
                this.employeeManager.addWorker(this.employeeLastName, this.employeeFirstName,
                    this.workerWorkedHours.Value,
                    this.workerHoursSalary.Value);
            }
            // Add salaried Employee (TODO optimize)
            else if (this.salariedEmployeeSalary.HasValue)
            {
                // Validate salaried Employee
                if (!this.salariedEmployeeSalary.HasValue ||
                    this.employeeFirstName == null || this.employeeLastName == null)
                {
                    // TODO Error
                    Console.WriteLine("Invalid Input provided for salaried Employee!");
                    return false;
                }

                // Add salaried Employee
                this.employeeManager.addSalariedEmployee(this.employeeLastName, this.employeeFirstName,
                    this.salariedEmployeeSalary.Value);
            }
            else
            {
                // TODO Error
                Console.WriteLine("Invalid Input provided!");
                return false;
            }

            // Reset all input properties
            this.employeeFirstName = null;
            this.employeeLastName = null;
            this.salariedEmployeeSalary = null;
            this.workerHoursSalary = null;
            this.workerWorkedHours = null;

            Console.WriteLine("Added Employee");

            return true;
        }

        private void showAllEmployees()
        {
            this.output = this.employeeManager.ToString();
        }
    }
}