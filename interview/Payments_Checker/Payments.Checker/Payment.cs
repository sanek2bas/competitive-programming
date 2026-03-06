namespace Payments.Checker;

public class Payment
{
    public int Id { get; set; }
    
    public int UserId { get; set; }
    
    public decimal Amount { get; set; }
    
    public DateTime OperationTime { get; set; }

    //OperationType => Write-off
}