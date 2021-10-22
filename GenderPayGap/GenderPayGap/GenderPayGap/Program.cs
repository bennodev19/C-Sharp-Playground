using System;

namespace GenderPayGap
{
    class Program
    {
        static void Main(string[] args)
        {
            Employee firstEmployee = new Employee("frank", -10);
            printEmplyee(firstEmployee);

            firstEmployee.salary = 89;
            printEmplyee(firstEmployee);

            Employee secondEmplyee = new Employee("jeff", 100);
            printEmplyee(secondEmplyee);

            secondEmplyee.salary = -100;
            printEmplyee(secondEmplyee);

            bool isActive = true;
            Employee[] employees = [];
            while (isActive)
            {

            }
        }

        static void printEmplyee(Employee emplyee)
        {
            Console.WriteLine("First Employee: (Name: '" + emplyee.name + "', Salary: " + emplyee.salary + ")");
        }

        static Employee drawEmployeeInput()
        {
            // Draw
            Console.WriteLine(
                "Employee Input:\n" +
                "---------------------------------------------------\n");

            // Read Input
            Console.Write("Name: ");
            string nameInput = Console.ReadLine();

            Console.Write("Salary: ");
            string salaryInput = Console.ReadLine();

            // Format Salary
            float salary = float.Parse(salaryInput);

            // Create Employee
            Employee employee = new Employee(nameInput);

            employee.setSalary(salary);

            return employee;
        }
    }
}
