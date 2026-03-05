namespace ConsoleApp.UnitTest
{
    public class PaymentsCheckerTests
    {
        [Fact]
        public void PaymentsChecker_Check_TwoGoodLimits()
        {
            var mockUserLimitsService = new FakeUserLimitsService();
            mockUserLimitsService.OnceLimit = 2000;
            mockUserLimitsService.DayLimit = 10000;
            var mockPaymentsHistoryService = new FakePaymentsHistoryService();

            var sut = new PaymentsChecker(
                mockUserLimitsService, 
                mockPaymentsHistoryService);
            var payment = new Payment()
            {
                UserId = 1,
                Summ = 1000,
                Time = DateTime.Now
            };

            var answer = sut.CheckPayment(payment);
            Assert.True(answer.Result);
            Assert.Equal(string.Empty, answer.Error);
        }

        [Fact]
        public void PaymentsChecker_Check_OnceLimitExceeded()
        {
            var mockUserLimitsService = new FakeUserLimitsService();
            mockUserLimitsService.OnceLimit = 500;
            mockUserLimitsService.DayLimit = 10000;
            var mockPaymentsHistoryService = new FakePaymentsHistoryService();

            var sut = new PaymentsChecker(
                mockUserLimitsService,
                mockPaymentsHistoryService);
            var payment = new Payment()
            {
                UserId = 1,
                Summ = 1000,
                Time = DateTime.Now
            };

            var result = sut.CheckPayment(payment);
            Assert.False(result.Result);
            Assert.Equal("The once limit was exceeded", result.Error);

        }

        [Fact]
        public void PaymentsChecker_Check_DayLimitExceeded()
        {
            var mockUserLimitsService = new FakeUserLimitsService();
            mockUserLimitsService.OnceLimit = 2000;
            mockUserLimitsService.DayLimit = 10000;
            var mockPaymentsHistoryService = new FakePaymentsHistoryService();
            mockPaymentsHistoryService.Payments.Add(
                new Payment() { UserId = 1, Summ = 10000 });

            var sut = new PaymentsChecker(
                mockUserLimitsService,
                mockPaymentsHistoryService);
            var payment = new Payment()
            {
                UserId = 1,
                Summ = 1000,
                Time = DateTime.Now
            };

            var result = sut.CheckPayment(payment);
            Assert.False(result.Result);
            Assert.Equal("The day limit was exceeded", result.Error);

        }
    }

    public class FakeUserLimitsService : IUserLimitsService
    {
        public int OnceLimit { get; set; }
        public int DayLimit { get; set; }

        public double GetDayLimit(int userId)
        {
            return DayLimit;
        }

        public double GetOnceLimit(int userId)
        {
            return OnceLimit;
        }
    }

    public class FakePaymentsHistoryService : IPaymentsHistoryService
    {
        public IList<Payment> Payments = new List<Payment>();

        public IList<Payment> GetPayments(
            int userId, 
            DateTime start, 
            DateTime end)
        {
            return Payments;
        }
    }
}
