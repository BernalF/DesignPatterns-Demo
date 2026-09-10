namespace OpenClose
{
    public class EmployeeFullTime : Employee
    {
        private const decimal HOUR_VALUE = 30000M;

        public EmployeeFullTime(string fullname, int hoursWorked)
            : base(fullname, hoursWorked) { }

        public override decimal CalculateSalary()
        {
            return HOUR_VALUE * HoursWorked;
        }
    }
}