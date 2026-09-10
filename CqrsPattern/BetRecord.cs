namespace CqrsPattern;

internal sealed record BetRecord(Guid Id, string PlayerId, decimal Amount, DateTime PlacedAt);
