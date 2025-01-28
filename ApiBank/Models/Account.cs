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
                AddTransaction("Deposit", amount);
            }

            public void Withdraw(decimal amount)
            {
                if (Balance < amount)
                {
                    throw new InvalidOperationException("Insufficient funds");
                }
                Balance -= amount;
                AddTransaction("Withdrawal", amount);
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
