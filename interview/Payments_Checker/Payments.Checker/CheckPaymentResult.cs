namespace Payments.Checker;

public class CheckPaymentResult
{
    public bool CanProcess { get; }

    public CheckPaymentResultType FailureType { get; }
    
    public string FailureMessage { get; }

    private CheckPaymentResult(
        bool canProcess = true, 
        CheckPaymentResultType failureType = default, 
        string failureMessage = "")
    {
        CanProcess = canProcess;
        FailureType = failureType;
        FailureMessage = failureMessage;
    }

    public static CheckPaymentResult Success()
    {
        return new CheckPaymentResult(true);
    }

    public static CheckPaymentResult Failure(
        CheckPaymentResultType failureType, string message)
    {
        return new CheckPaymentResult(false, failureType, message);
    }
}

public enum CheckPaymentResultType
{
    None,
    SingleOperationLimitExceeded,
    DailyLimitExceeded
}