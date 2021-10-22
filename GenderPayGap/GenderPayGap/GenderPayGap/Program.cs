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
        }

        static void printEmplyee(Employee emplyee)
        {
            Console.WriteLine("First Employee: (Name: '" + emplyee.name + "', Salary: " + emplyee.salary + ")");
        }
    }
}
