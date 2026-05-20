using Microsoft.AspNetCore.Mvc;
using miuBank_backend.Repositories.Interfaces;

namespace miuBank_backend.Controllers;
[ApiController]
[Route("api/account")]
public class AccountController : ControllerBase
{
    private readonly IAccountRepository _accountRepository;
    public AccountController(IAccountRepository accountRepository)
    {
        _accountRepository = accountRepository;
    }
    
    [HttpGet("prime")]
    public async Task<IActionResult> GetPrime()
    {
        var primeAccounts = await _accountRepository.GetPrimeAccounts();
        
        if (primeAccounts.Count == 0) return NotFound();
        
        return Ok(primeAccounts);
    }
}