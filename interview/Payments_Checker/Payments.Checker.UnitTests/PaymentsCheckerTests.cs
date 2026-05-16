namespace Payments.Checker.UnitTests;

public class PaymentsCheckerTests
{
    private const int User_Id = 123;

    [Fact]
    public void PaymentsChecker_ValidPayment_ReturnsSuccess()
    {
        var payment = new Payment
        {
            UserId = User_Id,
            Amount = 500m,
            OperationTime = DateTime.UtcNow
        };
        var userLimits = new UserLimits
        {
            UserId = User_Id,
            DailyLimit = 1000m,
            SingleOperationLimit = 600m
        };
        var recentPayments = new List<Payment>
        {
            new Payment { Amount = 200m, OperationTime = DateTime.UtcNow.AddHours(-2) },
            new Payment { Amount = 100m, OperationTime = DateTime.UtcNow.AddHours(-5) }
        };
        var mockLimitsService = new FakeUserLimitsService();
        mockLimitsService.UserLimits = userLimits;
        var mockHistoryService = new FakePaymentsHistoryService();
        mockHistoryService.Payments = recentPayments;

        var sut = new PaymentsChecker(mockLimitsService, mockHistoryService);
        var result = sut.CheckPayment(payment);

        Assert.True(result.CanProcess);
        Assert.Equal(CheckPaymentResultType.None, result.FailureType);
        Assert.Equal(string.Empty, result.FailureMessage);
    }

    [Fact]
    public async Task PaymentsChecker_ExceedsSingleOperationLimit_ReturnsFailure()
    {
        var payment = new Payment
        {
            UserId = User_Id,
            Amount = 900m,
            OperationTime = DateTime.UtcNow
        };
        var userLimits = new UserLimits
        {
            UserId = User_Id,
            DailyLimit = 1000m,
            SingleOperationLimit = 600m
        };
        var recentPayments = new List<Payment>
        {
            new Payment { Amount = 200m, OperationTime = DateTime.UtcNow.AddHours(-2) },
            new Payment { Amount = 100m, OperationTime = DateTime.UtcNow.AddHours(-5) }
        };
        var mockLimitsService = new FakeUserLimitsService();
        mockLimitsService.UserLimits = userLimits;
        var mockHistoryService = new FakePaymentsHistoryService();
        mockHistoryService.Payments = recentPayments;

        var sut = new PaymentsChecker(mockLimitsService, mockHistoryService);
        var result = sut.CheckPayment(payment);

        Assert.False(result.CanProcess);
        Assert.Equal(CheckPaymentResultType.SingleOperationLimitExceeded, 
                     result.FailureType);
        Assert.Contains($"Payment amount exceeds the maximum allowed {userLimits.SingleOperationLimit}", 
                        result.FailureMessage);
    }

    [Fact]
    public async Task PaymentsChecker_ExceedsDailyLimit_ReturnsFailure()
    {
        var payment = new Payment
        {
            UserId = User_Id,
            Amount = 500m,
            OperationTime = DateTime.UtcNow
        };
        var userLimits = new UserLimits
        {
            UserId = User_Id,
            DailyLimit = 1000m,
            SingleOperationLimit = 600m
        };
        var recentPayments = new List<Payment>
        {
            new Payment { Amount = 300m, OperationTime = DateTime.UtcNow.AddHours(-2) },
            new Payment { Amount = 200m, OperationTime = DateTime.UtcNow.AddHours(-2) },
            new Payment { Amount = 100m, OperationTime = DateTime.UtcNow.AddHours(-5) }
        };
        var mockLimitsService = new FakeUserLimitsService();
        mockLimitsService.UserLimits = userLimits;
        var mockHistoryService = new FakePaymentsHistoryService();
        mockHistoryService.Payments = recentPayments;

        var sut = new PaymentsChecker(mockLimitsService, mockHistoryService);
        var result = sut.CheckPayment(payment);

        Assert.False(result.CanProcess);
        Assert.Equal(CheckPaymentResultType.DailyLimitExceeded,
                     result.FailureType);
        Assert.Contains($"Summ of amounts for last 24 hours exceeds the maximum allowed {userLimits.DailyLimit}",
                        result.FailureMessage);
    }

}

public class FakeUserLimitsService : IUserLimitsService
{
    public UserLimits UserLimits { get; set; }

    public UserLimits GetUserLimits(int userId)
    {
        return UserLimits;
    }
}

public class FakePaymentsHistoryService : IPaymentsHistoryService
{
    public IList<Payment> Payments { get; set; }

    public IEnumerable<Payment> GetPayments(
        int userId,
        DateTime start,
        DateTime end)
    {
        return Payments;
    }
}