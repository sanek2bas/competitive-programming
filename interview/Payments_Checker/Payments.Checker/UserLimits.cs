namespace Payments.Checker;

public class UserLimits
{
    public int UserId { get; set; }

    public decimal DailyLimit { get; set; }
    
    public decimal SingleOperationLimit { get; set; }
}