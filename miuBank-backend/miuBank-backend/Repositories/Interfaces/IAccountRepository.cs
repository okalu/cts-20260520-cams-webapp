using miuBank_backend.Domain;

namespace miuBank_backend.Repositories.Interfaces;

public interface IAccountRepository
{
    Task<List<Account>> GetAccounts();
    Task<List<Account>> GetPrimeAccounts();
    Task<Account> GetAccount(int id);
    Task Create(Account account);
    Task Update(Account account);
}