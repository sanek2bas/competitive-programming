namespace Payments.Checker;

public interface IPaymentsHistoryService
{
    IEnumerable<Payment> GetPayments(
        int userId, DateTime fromDate, DateTime toDate);
}