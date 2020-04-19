using System;
using Micky5991.Banking.AggregatedDependencies;
using Micky5991.Banking.Entities;
using Micky5991.Banking.Extensions;
using Micky5991.Banking.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using Moq;

namespace Micky5991.Banking.Tests
{
    public abstract class BankAccountTest
    {
        protected IServiceProvider? ServiceProvider;

        protected IBankAccountFactory? BankAccountFactory;

        protected AggregatedBankAccountDependencies? BankAccountServices;

        protected Mock<IBankAccountFactory>? BankAccountFactoryMock;

        protected BankAccount? BankAccountWithBalance;
        protected BankAccount? BankAccountNoBalance;

        public virtual void Setup()
        {
            this.SetupDependencies();
        }

        public virtual void TearDown()
        {
            this.BankAccountFactory = null;

            this.BankAccountFactoryMock = null;
        }

        protected virtual void SetupDependencies()
        {
            var serviceCollection = new ServiceCollection();

            serviceCollection.AddDefaultAggregatedBankingDependencies();

            if (this.BankAccountFactoryMock == null)
            {
                serviceCollection.AddDefaultBankAccountFactory();
            }
            else
            {
                serviceCollection.AddTransient(x => this.BankAccountFactoryMock.Object);
            }

            this.BuildServiceProvider(serviceCollection);
        }

        private void BuildServiceProvider(IServiceCollection serviceCollection)
        {
            this.ServiceProvider = serviceCollection.BuildServiceProvider();

            this.BankAccountFactory = this.ServiceProvider.GetRequiredService<IBankAccountFactory>();
            this.BankAccountServices = this.ServiceProvider.GetRequiredService<AggregatedBankAccountDependencies>();

            if (this.BankAccountFactory.CreateBankAccount("account", 100) is BankAccount bankAccount)
            {
                this.BankAccountWithBalance = bankAccount;
            }

            if (this.BankAccountFactory.CreateBankAccount("account-nobalance", 0) is BankAccount noBalanceAccount)
            {
                this.BankAccountNoBalance = noBalanceAccount;
            }
        }
    }
}
