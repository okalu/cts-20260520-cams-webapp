namespace miuBank_backend.Domain;

public class Account
{
    public long AccountId { get; set; }
    public string AccountNumber { get; set; } = null!;
    public string AccountType { get; set; } = null!;
    public double Balance { get; set; }
    public DateTime DateOpened { get; set; } = DateTime.UtcNow;
    public long CustomerId { get; set; }
    public Customer? Customer { get; set; }
    
}