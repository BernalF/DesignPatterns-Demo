namespace OpenClose;

/// <summary>
/// Runs the Open/Closed Principle console demonstration.
/// </summary>
public static class PrincipleDemo
{
    /// <summary>
    /// Calculates and prints the salary for different employee types.
    /// </summary>
    public static void Run()
    {
        CalculateSalaryMonthly(new List<Employee>
        {
            new EmployeeFullTime("Peter Parker", 160),
            new EmployeePartTime("Mary Watson", 180)
        });
    }

    /// <summary>
    /// Prints each salary while relying on the employee abstraction.
    /// </summary>
    private static void CalculateSalaryMonthly(List<Employee> employees)
    {
        foreach (Employee employee in employees)
        {
            decimal salary = employee.CalculateSalary();
            Console.WriteLine($"Employee: {employee.Fullname}, Payment: {salary:C1}");
        }
    }
}

internal static class Program
{
    /// <summary>
    /// Runs the demonstration when this project is executed directly.
    /// </summary>
    private static void Main()
    {
        PrincipleDemo.Run();
    }
}