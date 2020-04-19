using System;
using FluentAssertions;
using Micky5991.Banking.Data;
using Micky5991.Banking.Interfaces;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace Micky5991.Banking.Tests
{
    [TestClass]
    public class BankAccountTransactionFixture
    {
        private Mock<IBankAccount>? bankAccountMock;
        private Mock<IBankAccount>? otherBankAccountMock;

        [TestInitialize]
        public void Setup()
        {
            this.bankAccountMock = new Mock<IBankAccount>();
            this.otherBankAccountMock = new Mock<IBankAccount>();
        }

        [TestMethod]
        public void CreatingInstanceWithNullRecipientThrowsException()
        {
            Action act = () => new BankAccountTransaction(
                                                          null!,
                                                          this.otherBankAccountMock!.Object,
                                                          1,
                                                          "No reason");

            act.Should().Throw<ArgumentNullException>();
        }

        [TestMethod]
        [DataRow(null)]
        [DataRow("")]
        [DataRow(" ")]
        public void CreatingInstanceWithNullMessageThrowsException(string message)
        {
            Action act = () => new BankAccountTransaction(
                                                          this.bankAccountMock!.Object,
                                                          this.otherBankAccountMock!.Object,
                                                          1,
                                                          message);

            act.Should().Throw<ArgumentNullException>();
        }

        [TestMethod]
        public void CreatingInstanceWithZeroAmountThrowsException()
        {
            Action act = () => new BankAccountTransaction(
                                                          this.bankAccountMock!.Object,
                                                          this.otherBankAccountMock!.Object,
                                                          0,
                                                          "No reason");

            act.Should().Throw<ArgumentOutOfRangeException>()
               .Where(x => x.Message.Contains("not 0"));
        }

        [TestMethod]
        [DataRow(-2, "Message")]
        [DataRow(-1, "Secondmessage")]
        [DataRow(1, "Positive message")]
        [DataRow(2, "Greetings")]
        public void CreatingInstanceReturnsTransaction(int amount, string message)
        {
            var transaction = new BankAccountTransaction(
                                                         this.bankAccountMock!.Object,
                                                         this.otherBankAccountMock!.Object,
                                                         amount,
                                                         message);

            transaction.TransactionRecipient.Should().NotBeNull().And.Be(this.bankAccountMock.Object);
            transaction.TransactionOpposite.Should().NotBeNull().And.Be(this.otherBankAccountMock.Object);
            transaction.Amount.Should().Be(amount);
            transaction.Reason.Should().Be(message);
        }

        [TestMethod]
        public void CreatingInstanceWithZeroOppositeReturnsTransaction()
        {
            var transaction = new BankAccountTransaction(
                                                         this.bankAccountMock!.Object,
                                                         null,
                                                         0,
                                                         "No reason");

            transaction.TransactionOpposite.Should().BeNull();
        }
    }
}
