namespace AdapterPattern;

internal sealed class LegacyPaymentAdapter(LegacyPaymentProvider provider) : IWithdrawalProcessor
{
    public bool ProcessWithdrawal(decimal amount) => provider.ProcessTransaction(amount) == "SUCCESS";
}
