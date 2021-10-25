using System;
using System.Collections.Generic;

namespace GenderPayGap
{
    class Program
    {
        static void Main(string[] args)
        {
            //Employee firstEmployee = new Employee("frank", -10);
            //drawEmployee(firstEmployee);

            //firstEmployee.salary = 89;
            //drawEmployee(firstEmployee);

            //Employee secondEmplyee = new Employee("jeff", 100);
            //drawEmployee(secondEmplyee);

            //secondEmplyee.salary = -100;
            //drawEmployee(secondEmplyee);

            bool isActive = true;
            List<Employee> employees = new List<Employee>();

            while (isActive)
            {
                // Draw Menu
                int selectedMenuPoint = Program.drawMenu();

                switch (selectedMenuPoint)
                {
                    case 1:
                        employees.Add(drawEmployeeInput());
                      break;

                    case 2:
                        drawEmployees(employees);
                      break;

                    case 0:
                        isActive = false;
                      break;

                    default: 
                        isActive = false;
                      break;
                }
            }
        }


        static void drawEmployee(Employee emplyee)
        {
            Console.WriteLine("Employee: (Name: '" + emplyee.name + "', Salary: " + emplyee.salary + ")");
        }

        static void drawEmployees(List<Employee> employees)
        {
            clearConsole();

            // Draw Header
            Console.WriteLine(
                "===================================================\n" +
                "List:\n" +
                "===================================================\n");

            // Draw empty List
            if (employees.Count <= 0)
            {
                Console.Write("No Element found!\n\n");
            }

            // Draw List
            employees.ForEach(delegate (Employee emplyee)
            {
                drawEmployee(emplyee);
            });

            Console.WriteLine(
         "===================================================\n");

            drawPressKeyToGoToMenu();
        }

        static int drawMenu() {
            clearConsole();

            // Draw
            Console.WriteLine(
                "===================================================\n" +
                "Menu\n" +
                "===================================================\n" +
                "1 = Add Employee\n" +
                "2 = Print Employees\n" +
                "0 = End\n" +
                "---------------------------------------------------\n");
            Console.Write("Auswahl: ");

            // Read Input
            string input = Console.ReadLine();

            // Format Input
            try
            {
                return Int32.Parse(input);
            }
            catch (FormatException e)
            {
                Console.WriteLine("Invalid Input");
            }

            return -1;
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

        static void clearConsole()
        {
            Console.Clear();
        }

        static void drawPressKeyToGoToMenu()
        {
            Console.WriteLine("Press any key to go back to menu!");
            Console.ReadLine();
        }
    }
}
