using FluentAssertions;
using Micky5991.Banking.AggregatedDependencies;
using Micky5991.Banking.Interfaces;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace Micky5991.Banking.Tests
{
    [TestClass]
    public class AggregatedBankAccountDependenciesFixture
    {

        [TestMethod]
        public void CreatingInstanceWithValidValuesSetsPropertiesCorrectly()
        {
            var repositoryMock = new Mock<IBankAccountTransactionRepository>();

            var services = new AggregatedBankAccountDependencies(repositoryMock.Object);

            services.TransactionRepository.Should().NotBeNull().And.Be(repositoryMock.Object);
        }

    }
}
