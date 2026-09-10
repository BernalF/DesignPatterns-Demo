using System.Text;
using static System.String;

namespace SingleResponsibility;

/// <summary>Exports bet slips as a CSV file.</summary>
public class CsvExporter : IExporter
{
    /// <summary>Writes the supplied bet slips to BetSlips.csv.</summary>
    public void Export(IEnumerable<BetSlip> betSlips)
    {
        StringBuilder sb = new();
        sb.AppendLine("Id;PlayerId;BetAmounts");
        foreach (BetSlip item in betSlips)
        {
            sb.AppendLine($"{item.Id};{item.PlayerId};{Join("|", item.BetAmounts)}");
        }

        File.WriteAllText(
            Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "BetSlips.csv"),
            sb.ToString(),
            Encoding.UTF8);
    }
}
