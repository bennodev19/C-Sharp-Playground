namespace PersonalManagement.Models
{
    public class Worker : Employee
    {
        private int workedHours;
        private double hoursSalary;

        public Worker() : base("TheFirst", "Jeff")
        {
            // do nothing?
        }

        public Worker(string lastName, string firstName, int workedHours, double hoursSalary) : base(lastName,
            firstName)
        {
            this.workedHours = workedHours;
            this.hoursSalary = hoursSalary;
        }

        // ===================================================================================
        // Setter & Getter
        // ===================================================================================

        public int getWorkedHours()
        {
            return this.workedHours;
        }

        public bool setWorkedHours(int value)
        {
            bool isValid = value >= 0;
            if (isValid)
            {
                this.workedHours = value;
            }

            return isValid;
        }

        public double getHoursSalary()
        {
            return this.hoursSalary;
        }

        public bool setHoursSalary(double value)
        {
            bool isValid = value > 0;
            if (isValid)
            {
                this.hoursSalary = value;
            }

            return isValid;
        }


        // ===================================================================================
        // Overwritten
        // ===================================================================================

        public override string ToString()
        {
            return base.ToString() + ": [workedHours: '" + this.workedHours + "', hoursSalary: '" + hoursSalary +
                   "']";
        }
    }
}