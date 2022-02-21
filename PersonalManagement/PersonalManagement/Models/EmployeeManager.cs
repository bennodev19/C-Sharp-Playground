using System.Collections.Generic;

namespace PersonalManagement.Models
{
    public class EmployeeManager
    {
        private List<Employee> employees = new List<Employee>();

        public EmployeeManager()
        {
        }

        public EmployeeManager(List<Employee> initialEmployees)
        {
            this.employees = initialEmployees;
        }

        public void addWorker(string lastName, string firstName, int workedHours, int hoursSalary)
        {
            this.employees.Add(new Worker(lastName, firstName, workedHours, hoursSalary));
        }

        public void addSalariedEmployee(string lastName, string firstName, int salary)
        {
            this.employees.Add(new SalariedEmployee(lastName, firstName, salary));
        }

        public void addEmployee(Employee employee)
        {
            this.employees.Add(employee);
        }
    }
}