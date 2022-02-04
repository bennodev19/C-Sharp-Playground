namespace PersonalManagement.Models
{
    public class Employee
    {
        private string lastName;
        private string firstName;

        public Employee(string lastName, string firstName)
        {
            this.setLastName(lastName);
            this.setFirstName(firstName);
        }

        // ===================================================================================
        // Setter & Getter
        // ===================================================================================

        public string getLastName()
        {
            return this.lastName;
        }

        private void setLastName(string value)
        {
            this.lastName = value;
        }

        public string getFirstName()
        {
            return this.firstName;
        }

        private void setFirstName(string value)
        {
            this.firstName = value;
        }

        // ===================================================================================
        // Overwritten
        // ===================================================================================

        public override string ToString()
        {
            return base.ToString() + ": [lastName: '" + this.lastName + "', firstName: '" + this.firstName + "']";
        }
    }
}