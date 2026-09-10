namespace SingleResponsibility;

/// <summary>Retrieves student data from the in-memory storage.</summary>
public class StudentRepository
{
    private readonly FakeStorage<Student> storage = new();

    /// <summary>Initializes the repository with sample students.</summary>
    public StudentRepository()
    {
        InitializeData();
    }

    /// <summary>Seeds the example data.</summary>
    private void InitializeData()
    {
        storage.Add(new Student(1, "Peter Parker", [3, 4.5]));
        storage.Add(new Student(2, "Mary Watson", [4, 5]));
        storage.Add(new Student(3, "John Smith", [2, 3]));
    }

    /// <summary>Returns all students.</summary>
    public IEnumerable<Student> GetAll()
    {
        return storage.GetAll();
    }
}