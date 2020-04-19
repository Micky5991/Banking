using System;
using JetBrains.Annotations;
using Micky5991.Banking.Interfaces;

namespace Micky5991.Banking.Data
{
    /// <summary>
    /// Representation of a transaction of <see cref="IBankAccount"/>.
    /// </summary>
    [PublicAPI]
    public class BankAccountTransaction
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="BankAccountTransaction"/> class.
        /// </summary>
        /// <param name="transactionAccount"><see cref="IBankAccount"/> that was associated with this transaction.</param>
        /// <param name="transactionOppositeAccount">Opposite <see cref="IBankAccount"/> of this transaction that receives/sent the <paramref name="amount"/>.</param>
        /// <param name="amount">Non-Zero amount which was added to the <see cref="IBankAccount"/>. This can be negative.</param>
        /// <param name="reason">Message that describes why this <see cref="BankAccountTransaction"/> has been executed.</param>
        /// <exception cref="ArgumentNullException"><paramref name="transactionAccount"/> was null. <paramref name="reason"/> was null, empty or whitespace.</exception>
        /// <exception cref="ArgumentOutOfRangeException"><paramref name="amount"/> was 0.</exception>
        public BankAccountTransaction(IBankAccount transactionAccount, IBankAccount? transactionOppositeAccount, decimal amount, string reason)
        {
            this.TransactionAccount = transactionAccount;
            this.TransactionOppositeAccount = transactionOppositeAccount;
            this.Amount = amount;
            this.Reason = reason;
        }

        /// <summary>
        /// Gets the <see cref="IBankAccount"/> that owns this transaction.
        /// </summary>
        public IBankAccount TransactionAccount { get; }

        /// <summary>
        /// Gets the opposite <see cref="IBankAccount"/> that either sent or received <see cref="Amount"/>.
        /// </summary>
        public IBankAccount? TransactionOppositeAccount { get; }

        /// <summary>
        /// Gets the amount that was sent to or received from <see cref="TransactionOppositeAccount"/>.
        /// </summary>
        public decimal Amount { get; }

        /// <summary>
        /// Gets the message why this transaction was executed.
        /// </summary>
        public string Reason { get; }
    }
}
