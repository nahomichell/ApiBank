using System.Transactions;

namespace ApiBank.Models
{
    public class Account
    {
        
            public string AccountNumber { get; set; }
            public decimal Balance { get; set; }
            public List<Transaction> Transactions { get; set; }

            public Account(string accountNumber, decimal initialBalance)
            {
                AccountNumber = accountNumber;
                Balance = initialBalance;
                Transactions = new List<Transaction>();
            }

            public void Deposit(decimal amount)
            {
                Balance += amount;
                AddTransaction("Deposito", amount);
            }

            public void Withdraw(decimal amount)
            {
                if (Balance < amount)
                {
                    throw new InvalidOperationException("Fondos Insuficientes");
                }
                Balance -= amount;
                AddTransaction("Retiro", amount);
            }

            private void AddTransaction(string type, decimal amount)
            {
                Transactions.Add(new Transaction
                {
                    Id = Transactions.Count + 1,
                    Type = type,
                    Amount = amount,
                    BalanceAfter = Balance
                });
            }
        }
    
}
