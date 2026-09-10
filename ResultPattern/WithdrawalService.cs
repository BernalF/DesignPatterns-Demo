namespace ResultPattern;

internal sealed class WithdrawalService
{
    public Result<string> RequestWithdrawal(decimal amount) => amount > 0
        ? Result<string>.Success($"Withdrawal of {amount:C} approved.")
        : Result<string>.Failure("Withdrawal amount must be greater than zero.");
}
