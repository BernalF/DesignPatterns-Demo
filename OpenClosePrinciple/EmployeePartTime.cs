namespace OpenClose
{
    public class EmployeePartTime : Employee
    {
        private const decimal HOUR_VALUE = 20000M;
        private const decimal EFFORT_COMPENSATION = 5000M;

        public EmployeePartTime(string fullname, int hoursWorked) : base(fullname, hoursWorked)
        {
        }

        public override decimal CalculateSalary()
        {
            decimal salary = HOUR_VALUE * HoursWorked;

            if (HoursWorked > 160)
            {
                int extraDays = HoursWorked - 160;
                salary += EFFORT_COMPENSATION * extraDays;
            }

            return salary;
        }
    }
}