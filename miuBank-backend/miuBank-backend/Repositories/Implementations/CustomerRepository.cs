using Microsoft.EntityFrameworkCore;
using miuBank_backend.Domain;
using miuBank_backend.DTOs;
using miuBank_backend.Repositories.Interfaces;

namespace miuBank_backend.Repositories.Implementations;

public class CustomerRepository : ICustomerRepository
{
    private readonly AppDbContext _context;

    public CustomerRepository(AppDbContext context)
    {
        _context = context;
    }
    
    public async Task<List<Customer>> GetAll()
    {
        return await _context.Customers.ToListAsync();
    }

    public async Task<Customer> GetById(int id)
    {
        return await _context.Customers.FindAsync(id);
    }

    public async Task Create(CreateAccountDTO customer)
    {
        var newCustomer = new Customer()
        {
            FirstName = customer.FirstName,
            LastName = customer.LastName,
        };
        await _context.Customers.AddAsync(newCustomer);
        var newAccount = new Account()
        {
            AccountType = customer.AccountType,
            Balance = customer.Balance,
            AccountNumber = customer.AccountNumber,
            CustomerId = newCustomer.CustomerId,
            Customer = newCustomer
        };
        await _context.Accounts.AddAsync(newAccount);
        await _context.SaveChangesAsync();
    }

    public async Task Update(Customer customer)
    {
        var cust = _context.Customers.FindAsync(customer.CustomerId);
        if (cust != null)
        {
            _context.Customers.Update(customer);
            await _context.SaveChangesAsync();
        }
    }

    public async Task Delete(long id)
    {
        var customer = await _context.Customers.FindAsync(id);
        if (customer != null)
        {
            _context.Customers.Remove(customer);
            await _context.SaveChangesAsync();
        }
    }
}