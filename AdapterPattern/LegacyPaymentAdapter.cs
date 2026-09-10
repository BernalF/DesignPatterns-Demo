namespace AdapterPattern;

// The adapter translates the legacy string result into the boolean withdrawal contract without altering legacy code.
internal sealed class LegacyPaymentAdapter(LegacyPaymentProvider provider) : IWithdrawalProcessor
{
    public bool ProcessWithdrawal(decimal amount) => provider.ProcessTransaction(amount) == "SUCCESS";
}
