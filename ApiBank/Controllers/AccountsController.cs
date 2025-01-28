using ApiBank.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ApiBank.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountsController : ControllerBase
    {
        private static List<Account> accounts = new();

        [HttpPost("create")]
        public IActionResult CreateAccount(string accountNumber, decimal initialBalance)
        {
            if (accounts.Any(a => a.AccountNumber == accountNumber))
            {
                return BadRequest("Esta cuenta ya existe, por favor ingrese otra.");
            }

            var account = new Account(accountNumber, initialBalance);
            accounts.Add(account);
            return Ok(account);
        }

        [HttpGet("{accountNumber}")]
        public IActionResult GetBalance(string accountNumber)
        {
            var account = accounts.FirstOrDefault(a => a.AccountNumber == accountNumber);
            if (account == null)
            {
                return NotFound("No existe la cuenta ingresada");
            }
            return Ok(new { account.AccountNumber, account.Balance });
        }

        [HttpPost("{accountNumber}/deposit")]
        public IActionResult Deposit(string accountNumber, decimal amount)
        {
            var account = accounts.FirstOrDefault(a => a.AccountNumber == accountNumber);
            if (account == null)
            {
                return NotFound("No existe la cuenta ingresada.");
            }

            account.Deposit(amount);
            return Ok(account);
        }

        [HttpPost("{accountNumber}/withdraw")]
        public IActionResult Withdraw(string accountNumber, decimal amount)
        {
            var account = accounts.FirstOrDefault(a => a.AccountNumber == accountNumber);
            if (account == null)
            {
                return NotFound("No existe la cuenta ingresada.");
            }

            try
            {
                account.Withdraw(amount);
                return Ok(account);
            }
            catch (InvalidOperationException ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("{accountNumber}/transactions")]
        public IActionResult GetTransactions(string accountNumber)
        {
            var account = accounts.FirstOrDefault(a => a.AccountNumber == accountNumber);
            if (account == null)
            {
                return NotFound("No existe la cuenta ingresada");
            }

            return Ok(account.Transactions);
        }
    }
}
