namespace Payments.Checker;

public class Payment
{
    public string UserId { get; set; }
    
    public decimal Amount { get; set; }
    
    public DateTime OperationTime { get; set; }

    //OperationType => Write-off
}