namespace PersonalManagement.Models
{
    public class SalariedEmployee : Employee
    {
        private double bruttoSalary;

        public SalariedEmployee() : base("Unknown", "Mr")
        {
            this.setBruttoSalary(0);
        }

        public SalariedEmployee(string lastName, string firstName, double bruttoSalary) : base(lastName, firstName)
        {
            this.setBruttoSalary(bruttoSalary);
        }

        public override double getBrutto()
        {
            return this.bruttoSalary;
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