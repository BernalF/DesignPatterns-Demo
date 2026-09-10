namespace SingleResponsibility;

/// <summary>Exports a collection of bets to an external representation.</summary>
public interface IExporter
{
    // This contract keeps export formats separate from the repository that supplies the data.
    /// <summary>Exports the supplied bets.</summary>
    void Export(IEnumerable<Bet> bets);
}
