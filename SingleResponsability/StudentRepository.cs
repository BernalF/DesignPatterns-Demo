namespace SingleResponsibility;

/// <summary>Retrieves bet slip data from the in-memory storage.</summary>
public class BetSlipRepository
{
    private readonly FakeStorage<BetSlip> storage = new();

    /// <summary>Initializes the repository with sample bet slips.</summary>
    public BetSlipRepository()
    {
        InitializeData();
    }

    /// <summary>Seeds the example data.</summary>
    private void InitializeData()
    {
        storage.Add(new BetSlip(1, "PLAYER_001", [50m, 100m]));
        storage.Add(new BetSlip(2, "PLAYER_002", [250m, 125m]));
        storage.Add(new BetSlip(3, "PLAYER_003", [30m, 45m]));
    }

    /// <summary>Returns all bet slips.</summary>
    public IEnumerable<BetSlip> GetAll()
    {
        return storage.GetAll();
    }
}