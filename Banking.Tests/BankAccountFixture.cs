using FluentAssertions;
using Micky5991.Banking.Entities;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Micky5991.Banking.Tests
{
    [TestClass]
    public class BankAccountFixture : BankAccountTest
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
    }
}
