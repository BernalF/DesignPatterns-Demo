namespace SingleResponsibility;

/// <summary>Exports a collection of bets to an external representation.</summary>
public interface IExporter
{
    /// <summary>Exports the supplied bets.</summary>
    void Export(IEnumerable<Bet> bets);
}
