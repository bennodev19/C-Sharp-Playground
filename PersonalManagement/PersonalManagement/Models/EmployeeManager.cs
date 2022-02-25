using System.Collections.Generic;
using System.Linq;

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

        // ===================================================================================
        // Overwritten
        // ===================================================================================

        public override string ToString()
        {
            string output = "";
            foreach (var employee in this.employees)
            {
                output += employee.ToString() + "\n";
            }

            return output;
        }
    }
}