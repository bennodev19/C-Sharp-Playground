namespace PersonalManagement.Models
{
    public class SalariedEmployee : Employee
    {
        private double bruttoSalary;

        public SalariedEmployee() : base("TheSecond", "Jeff")
        {
            // do nothing?
        }

        public SalariedEmployee(string lastName, string firstName, double bruttoSalary) : base(lastName, firstName)
        {
            this.bruttoSalary = bruttoSalary;
        }

        // ===================================================================================
        // Setter & Getter
        // ===================================================================================

        public double getBruttoSalary()
        {
            return this.bruttoSalary;
        }

        public bool setBruttoSalary(double value)
        {
            bool isValid = value > 0;
            if (isValid)
            {
                this.bruttoSalary = value;
            }

            return isValid;
        }

        // ===================================================================================
        // Overwritten
        // ===================================================================================

        public override string ToString()
        {
            return base.ToString() + ": [bruttoSalary: '" + this.bruttoSalary + "']";
        }
    }
}