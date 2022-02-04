namespace PersonalManagement.Models
{
    public class Employee
    {
        private string lastName;
        private string firstName;

        public Employee(string lastName, string firstName)
        {
            this.lastName = lastName;
            this.firstName = firstName;
        }

        // ===================================================================================
        // Setter & Getter
        // ===================================================================================

        public string getLastName()
        {
            return this.lastName;
        }

        public string getFirstName()
        {
            return this.firstName;
        }

        public void setLastName(string value)
        {
            this.lastName = value;
        }

        public void setFirstName(string value)
        {
            this.firstName = value;
        }

        // ===================================================================================
        // Overwritten
        // ===================================================================================
        
        public override string ToString()
        {
            return base.ToString() + ": [lastName: " + this.lastName + "firstName: " + this.firstName + "]";
        }
    }
}