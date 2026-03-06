namespace Payments.Checker;

public interface IPaymentsHistoryService
{
    IList<Payment> GetPayments(
        int userId, DateTime start, DateTime end);
}