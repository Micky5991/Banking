using System;
using FluentAssertions;
using Micky5991.Banking.Entities;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Micky5991.Banking.Tests
{
    [TestClass]
    public partial class BankAccountFixture : BankAccountTest
    {
        [TestInitialize]
        public override void Setup()
        {
            base.Setup();
        }

        [TestCleanup]
        public override void TearDown()
        {
            base.TearDown();
        }

        [TestMethod]
        public void CreatingBankAccountPassesRightValues()
        {
            var account = new BankAccount("identifier", 10, this.BankAccountServices!);

            account.Identifier.Should().Be("identifier");
            account.Balance.Should().Be(10);
        }

        [TestMethod]
        [DataRow(null)]
        [DataRow("")]
        [DataRow(" ")]
        public void CreatingBankAccountWithInvalidIdentifierThrowsException(string message)
        {
            Action act = () => new BankAccount(message, 10, this.BankAccountServices!);

            act.Should().Throw<ArgumentNullException>();
        }

        [TestMethod]
        public void PassingNullAsBankAccountServicesThrowsException()
        {
            Action act = () => new BankAccount("identifier", 10, null!);

            act.Should().Throw<ArgumentNullException>();
        }

        [TestMethod]
        [DataRow("identifier1")]
        [DataRow("identifier2")]
        [DataRow("identifier3")]
        public void CreatingBankAccountWithDifferentIdentifierReturnsRightValue(string identifier)
        {
            var account = new BankAccount(identifier, 10, this.BankAccountServices!);

            account.Identifier.Should().Be(identifier);
        }

        [TestMethod]
        [DataRow(-1d)]
        [DataRow(-0.5d)]
        [DataRow(0d)]
        [DataRow(0.5d)]
        [DataRow(1d)]
        public void CreatingBankAccountWithDifferentBalancesReturnsRightValue(decimal balance)
        {
            var account = new BankAccount("identifier", balance, this.BankAccountServices!);

            account.Balance.Should().Be(balance);
        }
    }
}
