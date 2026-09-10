namespace SingleResponsibility;

/// <summary>Exports a collection of students to an external representation.</summary>
public interface IExporter
{
    /// <summary>Exports the supplied students.</summary>
    void Export(IEnumerable<Student> students);
}
