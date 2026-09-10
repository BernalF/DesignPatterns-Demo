namespace AdapterPattern;

internal interface IWithdrawalProcessor
{
    bool ProcessWithdrawal(decimal amount);
}
