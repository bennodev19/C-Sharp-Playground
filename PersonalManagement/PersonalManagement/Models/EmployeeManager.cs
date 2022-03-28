using System.Collections.Generic;

namespace PersonalManagement.Models
{
    // Singleton
    public class EmployeeManager
    {
        private List<Employee> employees = new List<Employee>();

        private EmployeeManager instance;

        private EmployeeManager()
        {
        }

        private EmployeeManager(List<Employee> initialEmployees)
        {
            this.employees = initialEmployees;
        }

        public static EmployeeManager getInstance()
        {
            return new EmployeeManager();
        }
        
        public static EmployeeManager getInstance(List<Employee> initialEmployees)
        {
            return new EmployeeManager(initialEmployees);
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