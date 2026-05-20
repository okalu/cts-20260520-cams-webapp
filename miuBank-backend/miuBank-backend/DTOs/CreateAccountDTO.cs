namespace miuBank_backend.DTOs;

public class CreateAccountDTO
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string AccountNumber { get; set; }
    public string AccountType { get; set; } = null!;
    public double Balance { get; set; }
}