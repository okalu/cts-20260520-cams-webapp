using Microsoft.AspNetCore.Mvc;
using miuBank_backend.Domain;
using miuBank_backend.DTOs;
using miuBank_backend.Repositories.Interfaces;

namespace miuBank_backend.Controllers;
[ApiController]
[Route("/api/[controller]")]
public class CustomerController : ControllerBase
{
    private readonly ICustomerRepository _customerRepository;
    public CustomerController(ICustomerRepository customerRepository)
    {
        _customerRepository = customerRepository;
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CreateAccountDTO customer)
    {
        _customerRepository.Create(customer);
        return Ok();
    }
    
}