namespace SingleResponsibility;

/// <summary>Provides an in-memory collection for the student example.</summary>
public class FakeStorage<T>
{
    private readonly List<T> collection = [];

    /// <summary>Adds an item to the storage.</summary>
    public T Add(T item)
    {
        collection.Add(item);
        return item;
    }

    /// <summary>Removes an item from the storage.</summary>
    public T Remove(T item)
    {
        collection.Remove(item);
        return item;
    }

    /// <summary>Returns all stored items.</summary>
    public IEnumerable<T> GetAll()
    {
        return collection;
    }
}