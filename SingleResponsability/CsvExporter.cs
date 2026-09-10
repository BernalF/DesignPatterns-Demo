using System.Text;

namespace SingleResponsibility;

/// <summary>Exports bets as a CSV file.</summary>
public class CsvExporter : IExporter
{
    /// <summary>Writes the supplied bets to Bets.csv.</summary>
    public void Export(IEnumerable<Bet> bets)
    {
        StringBuilder sb = new();
        sb.AppendLine("Id;PlayerId;Amount");
        foreach (Bet item in bets)
        {
            sb.AppendLine($"{item.Id};{item.PlayerId};{item.Amount:F2}");
        }

        File.WriteAllText(
            Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Bets.csv"),
            sb.ToString(),
            Encoding.UTF8);
    }
}
