namespace SingleResponsibility;

/// <summary>Represents a student and their grades.</summary>
public class Student(int id, string fullname, List<double> grades)
{
    /// <summary>Gets or sets the student identifier.</summary>
    public int Id { get; set; } = id;
    /// <summary>Gets or sets the student's full name.</summary>
    public string Fullname { get; set; } = fullname;
    /// <summary>Gets or sets the student's grades.</summary>
    public List<double> Grades { get; set; } = grades;

    /// <summary>Initializes an empty student.</summary>
    public Student() : this(0, string.Empty, [])
    {
    }
}