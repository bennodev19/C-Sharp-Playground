using System;
namespace GenderPayGap
{
    public class Employee
    {
        private string id;

        private string _name;
        // https://stackoverflow.com/questions/6709072/c-getter-setter
        public string name
        {
            get { return _name; }
            set { _name = value; }
        }

        private float _salary;
        public float salary
        {
            get { return _salary; }
            set {
                 _salary = this.formatSalary(value);
            }
        }

        public Employee(string name, float salary)
        {
            id = Guid.NewGuid().ToString("N");
            this.salary = this.formatSalary(salary);
            this.name = name;
        }

        private float formatSalary(float value)
        {
            if (value >= 1)
                return value;
            else
                return 0;
        }
    }
}
