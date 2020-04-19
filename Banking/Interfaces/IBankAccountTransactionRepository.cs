using System;
using JetBrains.Annotations;
using Micky5991.Banking.Data;

namespace Micky5991.Banking.Interfaces
{
    /// <summary>
    /// Repository that abstracts common actions on a database in the context of <see cref="BankAccountTransaction"/>.
    /// </summary>
    [PublicAPI]
    public interface IBankAccountTransactionRepository
    {
        /// <summary>
        /// Logs a transaction that should be assigned to <paramref name="transactionReceipient"/> and remembers the <paramref name="transactionOpposite"/> <see cref="IBankAccount"/>.
        /// Because the transactions are persisted in a double-entry ledger the <paramref name="transactionReceipient"/> can be either the sender of this amount and the receiver.
        /// </summary>
        /// <param name="transactionReceipient">Reference to the <see cref="IBankAccount"/> that should this transaction be assigned to.</param>
        /// <param name="transactionOpposite">Nullable reference to the opposite side of this transaction. If null, the opposite site cannot be determined.</param>
        /// <param name="amount">Non-zero amount this transaction changed the balance of <paramref name="transactionReceipient"/> and <paramref name="transactionOpposite"/>.</param>
        /// <exception cref="ArgumentOutOfRangeException"><paramref name="amount"/> is zero.</exception>
        /// <exception cref="ArgumentNullException"><paramref name="transactionReceipient"/> is null. <paramref name="reason"/> is null, empty or whitespace.</exception>
        /// <param name="reason">Message that explained the reason of this transaction of the view of <paramref name="transactionReceipient"/>.</param>
        void CreateTransaction(IBankAccount transactionReceipient, IBankAccount? transactionOpposite, decimal amount, string reason);
    }
}
