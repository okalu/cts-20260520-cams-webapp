namespace miuBank_backend.Domain;

public class Customer
{
    public long CustomerId { get; set; }
    public string FirstName { get; set; } = null!;
    public string LastName { get; set; } = null!;
    public List<Account> Accounts { get; set; } = null!;

    public List<Account> GetAccounts(long id)
    {
        return Accounts.Where(a => a.CustomerId == id).ToList();
    }
}