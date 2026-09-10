using System.Text;
using static System.String;

namespace SingleResponsibility;

/// <summary>Exports students as a CSV file.</summary>
public class CsvExporter : IExporter
{
    /// <summary>Writes the supplied students to Students.csv.</summary>
    public void Export(IEnumerable<Student> students)
    {
        StringBuilder sb = new();
        sb.AppendLine("Id;Fullname;Grades");
        foreach (Student item in students)
        {
            sb.AppendLine($"{item.Id};{item.Fullname};{Join("|", item.Grades)}");
        }

        File.WriteAllText(
            Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Students.csv"),
            sb.ToString(),
            Encoding.UTF8);
    }
}
