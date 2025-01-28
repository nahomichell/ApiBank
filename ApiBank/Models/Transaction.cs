namespace ApiBank.Models
{
    public class Transaction
    {
        public int Id { get; set; }
        public string Type { get; set; } // Deposit or Withdrawal
        public decimal Amount { get; set; }
        public decimal BalanceAfter { get; set; }
    }
}
