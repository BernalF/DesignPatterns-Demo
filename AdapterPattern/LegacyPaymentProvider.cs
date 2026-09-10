namespace AdapterPattern;

internal sealed class LegacyPaymentProvider
{
    public string ProcessTransaction(decimal amount) => amount > 0 ? "SUCCESS" : "FAILED";
}
