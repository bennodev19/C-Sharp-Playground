namespace PersonalManagement.Models
{
    public class Worker : Employee
    {
        private int workedHours;
        private double hoursSalary;

        public Worker() : base("Unknown", "Mr")
        {
            this.setWorkedHours(0);
            this.setHoursSalary(0);
        }

        public Worker(string lastName, string firstName, int workedHours, double hoursSalary) : base(lastName,
            firstName)
        {
            this.setWorkedHours(workedHours);
            this.setHoursSalary(hoursSalary);
        }

        public override string output()
        {
            return this.ToString();
        }

        public double getBrutto()
        {
            return this.hoursSalary * this.workedHours;
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
            return base.ToString() + ": [workedHours: '" + this.workedHours + "', hoursSalary: '" + hoursSalary + "']";
        }
    }
}