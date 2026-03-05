namespace ConsoleApp;

public class PaymentsChecker
{
    IPaymentsHistoryService _paymentsHistoryService;
    IUserLimitsService _userLimitsService;

    public PaymentsChecker(
        IUserLimitsService limitsService,
        IPaymentsHistoryService historyService)
    {
        _paymentsHistoryService = historyService;
        _userLimitsService = limitsService;
    }

    public CheckPaymentResult CheckPayment(Payment payment)
    {
        var result = new CheckPaymentResult()
        {
            PaymentId = payment.Id
        };

        var userOnceLimit = 
            _userLimitsService.GetOnceLimit(payment.UserId);
        if (payment.Summ > userOnceLimit)
        {
            result.Result = false;
            result.Error = "The once limit was exceeded";
            return result;
        }

        DateTime endDateTime = DateTime.Now;
        DateTime startDateTime = endDateTime - TimeSpan.FromDays(1);
        var userDayLimit =
            _userLimitsService.GetOnceLimit(payment.UserId);
        IList<Payment> lastPayments =
            _paymentsHistoryService.GetPayments(
                payment.UserId, startDateTime, endDateTime);
        if (lastPayments.Sum(x => x.Summ) + payment.Summ > userDayLimit)
        {
            result.Result = false;
            result.Error = "The day limit was exceeded";
            return result;
        }

        result.Result = true;
        result.Error = string.Empty;
        return result;
    }
}