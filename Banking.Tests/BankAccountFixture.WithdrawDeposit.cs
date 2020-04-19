using System;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Micky5991.Banking.Tests
{
    public partial class BankAccountFixture
    {
        [TestMethod]
        [DataRow(0.1d)]
        [DataRow(1)]
        [DataRow(2)]
        public void WithdrawingBalanceUpdatesValue(decimal amount)
        {
            var account = this.BankAccountWithBalance!;
            using var monitoredAccount = account.Monitor();
            var oldBalance = account.Balance;

            var success = account.TryWithdraw(amount, "No reason", null);

            success.Should().BeTrue();
            account.Balance.Should().Be(oldBalance - amount);
        }

        [TestMethod]
        public void WithdrawingBalanceTriggersEvent()
        {
            var account = this.BankAccountWithBalance!;
            using var monitoredAccount = account.Monitor();

            account.TryWithdraw(1, "No reason", null);

            monitoredAccount.Should().RaisePropertyChangeFor(x => x.Balance);
        }

        [TestMethod]
        [DataRow(0.1d)]
        [DataRow(1)]
        [DataRow(2)]
        public void DepositingBalanceUpdatesValue(decimal amount)
        {
            var account = this.BankAccountWithBalance!;
            using var monitoredAccount = account.Monitor();
            var oldBalance = account.Balance;

            var success = account.TryDeposit(amount, "No reason", null);

            success.Should().BeTrue();
            account.Balance.Should().Be(oldBalance + amount);
        }

        [TestMethod]
        public void DepositingBalanceTriggersEvent()
        {
            var account = this.BankAccountWithBalance!;
            using var monitoredAccount = account.Monitor();

            account.TryDeposit(1, "No reason", null);

            monitoredAccount.Should().RaisePropertyChangeFor(x => x.Balance);
        }

        [TestMethod]
        [DataRow(0)]
        [DataRow(-1)]
        [DataRow(-2)]
        public void WithdrawingInvalidAmountThrowsException(decimal amount)
        {
            var account = this.BankAccountWithBalance!;

            Action act = () => account.TryWithdraw(amount, "No reason", null);

            act.Should().Throw<ArgumentOutOfRangeException>()
               .Where(x => x.Message.Contains("1 or higher"));
        }

        [TestMethod]
        [DataRow(0)]
        [DataRow(-1)]
        [DataRow(-2)]
        public void DepositingingInvalidAmountThrowsException(decimal amount)
        {
            var account = this.BankAccountWithBalance!;

            Action act = () => account.TryDeposit(amount, "No reason", null);

            act.Should().Throw<ArgumentOutOfRangeException>()
               .Where(x => x.Message.Contains("1 or higher"));
        }

        [TestMethod]
        [DataRow(null)]
        [DataRow("")]
        [DataRow(" ")]
        public void WithdrawingWithInvalidReasonThrowsException(string message)
        {
            var account = this.BankAccountWithBalance!;

            Action act = () => account.TryWithdraw(1, message, null);

            act.Should().Throw<ArgumentNullException>();
        }

        [TestMethod]
        [DataRow(null)]
        [DataRow("")]
        [DataRow(" ")]
        public void DepositingWithInvalidReasonThrowsException(string message)
        {
            var account = this.BankAccountWithBalance!;

            Action act = () => account.TryDeposit(1, message, null);

            act.Should().Throw<ArgumentNullException>();
        }

        [TestMethod]
        public void WithdrawingWithEqualSenderAndInstanceThrowsException()
        {
            var account = this.BankAccountWithBalance!;

            Action act = () => account.TryWithdraw(1, "message", account);

            act.Should().Throw<ArgumentException>()
               .Where(x => x.Message.Contains("same") && x.Message.Contains("not"));
        }

        [TestMethod]
        public void DepositingWithEqualSenderAndInstanceThrowsException()
        {
            var account = this.BankAccountWithBalance!;

            Action act = () => account.TryWithdraw(1, "message", account);

            act.Should().Throw<ArgumentException>()
               .Where(x => x.Message.Contains("same") && x.Message.Contains("not"));
        }
    }
}
