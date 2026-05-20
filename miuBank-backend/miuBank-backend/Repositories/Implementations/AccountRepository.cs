using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.MicrosoftExtensions;
using miuBank_backend.Domain;
using miuBank_backend.Repositories.Interfaces;

namespace miuBank_backend.Repositories.Implementations;

public class AccountRepository : IAccountRepository
{
    private readonly AppDbContext _context;
    public AccountRepository(AppDbContext context)
    {
        _context = context;
    }
    
    public async Task<List<Account>> GetAccounts()
    {
        return await _context.Accounts.ToListAsync();
    }

    public async Task<List<Account>> GetPrimeAccounts()
    {
        var prime = await _context.Accounts.ToListAsync();
        List<Account> addToPrime = new List<Account>();
        
        foreach (var account in prime)
        {
            var accBalance = prime.Where(acc => acc.AccountId == account.AccountId).ToList();
            if (accBalance.First().Balance >= 50000)
            {
                addToPrime.Add(account);
            }
        }
        
        return addToPrime;
    }

    public async Task<Account> GetAccount(int id)
    {
        return await _context.Accounts.FindAsync(id);
    }

    public async Task Create(Account account)
    {
        await _context.Accounts.AddAsync(account);
    }

    public Task Update(Account account)
    {
        throw new NotImplementedException();
    }
}