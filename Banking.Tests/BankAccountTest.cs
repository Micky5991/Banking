using System;
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

        protected void SetupDependencies()
        {
            var serviceCollection = new ServiceCollection();

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

            if (this.BankAccountFactory.CreateBankAccount(100, "account") is BankAccount bankAccount)
            {
                this.BankAccountWithBalance = bankAccount;
            }

            if (this.BankAccountFactory.CreateBankAccount(0, "account-nobalance") is BankAccount noBalanceAccount)
            {
                this.BankAccountNoBalance = noBalanceAccount;
            }
        }
    }
}
