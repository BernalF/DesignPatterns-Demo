namespace SingleResponsibility;

/// <summary>Exports a collection of bet slips to an external representation.</summary>
public interface IExporter
{
    /// <summary>Exports the supplied bet slips.</summary>
    void Export(IEnumerable<BetSlip> betSlips);
}
