namespace Payments.Checker;

public class PaymentsChecker
{
    private IPaymentsHistoryService _paymentsHistoryService;
    private IUserLimitsService _userLimitsService;

    public PaymentsChecker(
        IUserLimitsService limitsService,
        IPaymentsHistoryService historyService)
    {
        _paymentsHistoryService = historyService;
        _userLimitsService = limitsService;
    }

    public CheckPaymentResult CheckPayment(Payment payment)
    {
        if (payment == null)
            throw new ArgumentNullException(nameof(payment));
        if (payment.Amount < 0)
            throw new ArgumentOutOfRangeException(nameof(payment));
        
        var userLimits =
            _userLimitsService.GetUserLimits(payment.UserId);
        
        if (payment.Amount > userLimits.SingleOperationLimit)
        {
             return CheckPaymentResult.Failure(
                CheckPaymentResultType.SingleOperationLimitExceeded,
                $"Payment amount exceeds the maximum allowed {userLimits.SingleOperationLimit}");
        }

        DateTime toDate = payment.OperationTime;
        DateTime fromDate = toDate.AddHours(-24);
        IList<Payment> lastPayments =
            _paymentsHistoryService.GetPayments(payment.UserId, fromDate, toDate).ToList();
        
        decimal totalAmountLastPayments = 
            lastPayments.Sum(payment => payment.Amount);
        if (totalAmountLastPayments + payment.Amount > userLimits.DailyLimit)
        {
            return CheckPaymentResult.Failure(
                CheckPaymentResultType.DailyLimitExceeded,
                $"Summ of amounts for last 24 hours exceeds the maximum allowed {userLimits.DailyLimit}");
        }

        return CheckPaymentResult.Success();
    }
}
