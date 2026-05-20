using miuBank_backend.Domain;
using miuBank_backend.DTOs;

namespace miuBank_backend.Repositories.Interfaces;

public interface ICustomerRepository
{
    Task<List<Customer>> GetAll();
    Task<Customer> GetById(int id);
    Task Create(CreateAccountDTO customer);
    Task Update(Customer customer);
    Task Delete(long id);
}