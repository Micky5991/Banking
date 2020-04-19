using System;
using Micky5991.Banking.AggregatedDependencies;
using Micky5991.Banking.Interfaces;

namespace Micky5991.Banking.Entities
{
    /// <inheritdoc />
    public partial class BankAccount : IBankAccount
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="BankAccount"/> class.
        /// </summary>
        /// <param name="identifier">Human readable identifier of this bankaccount.</param>
        /// <param name="balance">Initial balance this <see cref="BankAccount"/> should have.</param>
        /// <param name="dependencies">Instance of the <see cref="AggregatedBankAccountDependencies"/> this <see cref="BankAccount"/> needs.</param>
        public BankAccount(string identifier, decimal balance, AggregatedBankAccountDependencies dependencies)
        {
            this.Identifier = identifier;
            this.Balance = balance;
        }

        /// <inheritdoc />
        public event EventHandler? Disposed;

        /// <inheritdoc />
        public void Dispose()
        {
            this.Disposed?.Invoke(this, EventArgs.Empty);
        }

        /// <inheritdoc />
        public bool TryWithdraw(decimal amount, string reason, IBankAccount? receiver = null)
        {
            throw new NotImplementedException();
        }

        /// <inheritdoc />
        public bool TryDeposit(decimal amount, string reason, IBankAccount? sender = null)
        {
            throw new NotImplementedException();
        }

        /// <inheritdoc />
        public bool TryTransfer(IBankAccount targetAccount, decimal amount, string reason)
        {
            throw new NotImplementedException();
        }

        /// <inheritdoc />
        public bool TryTransfer(
                IBankAccount targetAccount,
                decimal amount,
                string reasonOnSourceAccount,
                string reasonOnTargetAccount)
        {
            throw new NotImplementedException();
        }
    }
}
