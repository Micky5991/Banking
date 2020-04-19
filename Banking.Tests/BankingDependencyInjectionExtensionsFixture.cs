using System;
using FluentAssertions;
using Micky5991.Banking.AggregatedDependencies;
using Micky5991.Banking.Extensions;
using Micky5991.Banking.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Micky5991.Banking.Tests
{
    [TestClass]
    public class BankingDependencyInjectionExtensionsFixture
    {
        private IServiceCollection? serviceCollection;

        private IServiceProvider? serviceProvider;

        [TestInitialize]
        public void Setup()
        {
            this.serviceCollection = new ServiceCollection();
        }

        [TestCleanup]
        public void TearDown()
        {
            this.serviceCollection = null;
            this.serviceProvider = null;
        }

        private void BuildServiceProvider()
        {
            this.serviceProvider = this.serviceCollection.BuildServiceProvider();
        }

        [TestMethod]
        public void UseNullAsServiceCollectionForAggregatedServicesThrowsException()
        {
            Action act = () => BankingDependencyInjectionExtensions.AddDefaultAggregatedBankingDependencies(null!);

            act.Should().Throw<ArgumentNullException>();
        }

        [TestMethod]
        public void UseNullAsServiceCollectionForBankAccountFactoryThrowsException()
        {
            Action act = () => BankingDependencyInjectionExtensions.AddDefaultBankAccountFactory(null!);

            act.Should().Throw<ArgumentNullException>();
        }

        [TestMethod]
        public void UseNullAsServiceCollectionForDefaultBankingDependenciesThrowsException()
        {
            Action act = () => BankingDependencyInjectionExtensions.AddDefaultBankingDependencies(null!);

            act.Should().Throw<ArgumentNullException>();
        }

        [TestMethod]
        public void AddDefaultBankingDependenciesRegistersRightServices()
        {
            BankingDependencyInjectionExtensions.AddDefaultBankingDependencies(this.serviceCollection!);

            this.BuildServiceProvider();

            this.serviceProvider.GetRequiredService<AggregatedBankAccountDependencies>().Should().NotBeNull();
            this.serviceProvider.GetRequiredService<IBankAccountFactory>().Should().NotBeNull(); // TODO: Add actual implementation type.
        }

        [TestMethod]
        public void AddDefaultAggregatedBankingDependenciesRegistersRightService()
        {
            BankingDependencyInjectionExtensions.AddDefaultAggregatedBankingDependencies(this.serviceCollection!);

            this.BuildServiceProvider();

            this.serviceProvider.GetRequiredService<AggregatedBankAccountDependencies>().Should().NotBeNull();
        }

        [TestMethod]
        public void AddDefaultBankAccountFactoryRegistersRightService()
        {
            BankingDependencyInjectionExtensions.AddDefaultBankAccountFactory(this.serviceCollection!);

            this.BuildServiceProvider();

            this.serviceProvider.GetRequiredService<IBankAccountFactory>().Should().NotBeNull(); // TODO: Add actual implementation type.
        }

    }
}
