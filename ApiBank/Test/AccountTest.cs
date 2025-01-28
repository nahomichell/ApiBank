using ApiBank.Models;
using Xunit;

namespace ApiBank.Test
{
    public class AccountTest
    {
        [Fact]
        public void CreateAccount_ShouldInitializeWithCorrectValues()
        {
            // Arrange
            var accountNumber = "12345";
            var initialBalance = 1000m;

            // Act
            var account = new Account(accountNumber, initialBalance);

            // Assert
            Assert.Equal(accountNumber, account.AccountNumber);
            Assert.Equal(initialBalance, account.Balance);
            Assert.Empty(account.Transactions);
        }

        [Fact]
        public void Deposit_ShouldIncreaseBalanceAndRecordTransaction()
        {
            // Arrange
            var account = new Account("12345", 1000m);

            // Act
            account.Deposit(500m);

            // Assert
            Assert.Equal(1500m, account.Balance);
            Assert.Single(account.Transactions);
            Assert.Equal("Deposito", account.Transactions[0].Type);
            Assert.Equal(500m, account.Transactions[0].Amount);
            Assert.Equal(1500m, account.Transactions[0].BalanceAfter);
        }


        [Fact]
        public void Withdraw_ShouldDecreaseBalanceAndRecordTransaction()
        {
            // Arrange
            var account = new Account("12345", 1000m);

            // Act
            account.Withdraw(200m);

            // Assert
            Assert.Equal(800m, account.Balance);
            Assert.Single(account.Transactions);
            Assert.Equal("Retiro", account.Transactions[0].Type);
            Assert.Equal(200m, account.Transactions[0].Amount);
            Assert.Equal(800m, account.Transactions[0].BalanceAfter);
        }

        [Fact]
        public void Withdraw_ShouldThrowException_WhenInsufficientFunds()
        {
            // Arrange
            var account = new Account("12345", 500m);

            // Act & Assert
            var exception = Assert.Throws<InvalidOperationException>(() => account.Withdraw(1000m));
            Assert.Equal("Fondos insuficientes", exception.Message);
            Assert.Equal(500m, account.Balance); // El saldo no debe cambiar
            Assert.Empty(account.Transactions); // No debe registrarse ninguna transacción
        }

        [Fact]
        public void GetTransactions_ShouldReturnAllTransactions()
        {
            // Arrange
            var account = new Account("12345", 1000m);

            // Act
            account.Deposit(500m); // Saldo: 1500
            account.Withdraw(300m); // Saldo: 1200
            account.Deposit(200m); // Saldo: 1400

            // Assert
            Assert.Equal(3, account.Transactions.Count);

            Assert.Equal("Deposito", account.Transactions[0].Type);
            Assert.Equal(500m, account.Transactions[0].Amount);
            Assert.Equal(1500m, account.Transactions[0].BalanceAfter);

            Assert.Equal("Retiro", account.Transactions[1].Type);
            Assert.Equal(300m, account.Transactions[1].Amount);
            Assert.Equal(1200m, account.Transactions[1].BalanceAfter);

            Assert.Equal("Deposito", account.Transactions[2].Type);
            Assert.Equal(200m, account.Transactions[2].Amount);
            Assert.Equal(1400m, account.Transactions[2].BalanceAfter);
        }






    }
}
