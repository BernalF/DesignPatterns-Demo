namespace SingleResponsibility;

/// <summary>Retrieves bet data from the in-memory storage.</summary>
public class BetRepository
{
    private readonly FakeStorage<Bet> storage = new();

    /// <summary>Initializes the repository with sample bets.</summary>
    public BetRepository()
    {
        InitializeData();
    }

    /// <summary>Seeds the example data.</summary>
    private void InitializeData()
    {
        storage.Add(new Bet(1, "PLAYER_001", 50m));
        storage.Add(new Bet(2, "PLAYER_002", 250m));
        storage.Add(new Bet(3, "PLAYER_003", 30m));
        storage.Add(new Bet(4, "PLAYER_001", 100m));
        storage.Add(new Bet(5, "PLAYER_002", 125m));
    }

    /// <summary>Returns all bets.</summary>
    public IEnumerable<Bet> GetAll()
    {
        return storage.GetAll();
    }
}