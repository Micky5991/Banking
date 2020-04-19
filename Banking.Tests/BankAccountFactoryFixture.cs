using System;
using FluentAssertions;
using Micky5991.Banking.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Micky5991.Banking.Tests
{
    [TestClass]
    public class BankAccountFactoryFixture : BankAccountTest
    {
        private IBankAccountFactory? bankAccountFactory;

        [TestInitialize]
        public override void Setup()
        {
            base.Setup();

            this.bankAccountFactory = this.ServiceProvider.GetRequiredService<IBankAccountFactory>();
        }

        [TestCleanup]
        public override void TearDown()
        {
            base.TearDown();
        }

        [TestMethod]
        public void CreatingBankAccountWithRightValuesReturnsInstance()
        {
            var result = this.BankAccountFactory!.CreateBankAccount("account", 1);

            result.Should().BeOfType<IBankAccount>()
                  .And.NotBeNull();

            result.Balance.Should().Be(1);
            result.Identifier.Should().Be("account");
        }

        [TestMethod]
        [DataRow("name")]
        [DataRow("12345")]
        [DataRow("fsdklfsd")]
        public void PassedValuesToIdentifierAreRepresented(string identifier)
        {
            var result = this.BankAccountFactory!.CreateBankAccount(identifier, 1);

            result.Identifier.Should().Be(identifier);
        }

        [TestMethod]
        [DataRow(-2.3d)]
        [DataRow(-2d)]
        [DataRow(-1.7d)]
        [DataRow(-1.3d)]
        [DataRow(-1d)]
        [DataRow(-0.7d)]
        [DataRow(-0.3d)]
        [DataRow(0d)]
        [DataRow(0.3d)]
        [DataRow(0.7d)]
        [DataRow(1d)]
        [DataRow(1.3d)]
        [DataRow(1.7d)]
        [DataRow(2d)]
        public void PassedBalanceWillBeCorrectlySet(decimal balance)
        {
            var result = this.BankAccountFactory!.CreateBankAccount("account", balance);

            result.Balance.Should().Be(balance);
        }

        [TestMethod]
        [DataRow(null)]
        [DataRow("")]
        [DataRow(" ")]
        public void PassingInvalidIdentifierThrowsException(string identifier)
        {
            Action act = () => this.BankAccountFactory!.CreateBankAccount(identifier, 1);

            act.Should().Throw<ArgumentNullException>();
        }
    }
}
