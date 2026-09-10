namespace OpenClose
{
    public abstract class Employee
    {
        public string Fullname { get; set; }
        public int HoursWorked { get; set; }

        protected Employee(string fullname, int hoursWorked)
        {
            Fullname = fullname;
            HoursWorked = hoursWorked;
        }

        public abstract decimal CalculateSalary();
    }
}