using System;
using System.Collections.Generic;
using System.ComponentModel;
using JetBrains.Annotations;
using Micky5991.Banking.Data;

namespace Micky5991.Banking.Interfaces
{
    /// <summary>
    /// Instance of an bank account with a balance.
    /// </summary>
    [PublicAPI]
    public interface IBankAccount : IDisposable, INotifyPropertyChanged
    {
        /// <summary>
        /// Event that will be invoked when this instance has been disposed.
        /// </summary>
        event EventHandler? Disposed;

        /// <summary>
        /// Gets the instance to the identifier of this <see cref="IBankAccount"/> in the database.
        /// </summary>
        object? DatabaseIdentifier { get; }

        /// <summary>
        /// Gets the human readable and display identifier of this <see cref="IBankAccount"/>.
        /// </summary>
        string Identifier { get; }

        /// <summary>
        /// Gets the current balance of this <see cref="IBankAccount"/>.
        /// </summary>
        decimal Balance { get; }

        /// <summary>
        /// Returns an unordered list of <see cref="BankAccountTransaction"/> that manipulated the balance of this <see cref="IBankAccount"/>.
        /// </summary>
        /// <param name="transactionLimit">The maximum amount of transactions that should be returned.</param>
        /// <returns>Collection of <see cref="BankAccountTransaction"/> with a length limit of <paramref name="transactionLimit"/>.</returns>
        ICollection<BankAccountTransaction> GetTransactions(int transactionLimit = 50);

        /// <summary>
        /// Withdraws (reduces <see cref="Balance"/>) the given <see cref="amount"/> from this <see cref="IBankAccount"/>.
        /// If <paramref name="receiver"/> is null, this <paramref name="amount"/> will be voided.
        /// The parameter <paramref name="receiver"/> is only an informative value and should be used for persistance (e.g. <see cref="BankAccountTransaction"/> to remember to opposite side.
        /// </summary>
        /// <param name="amount">Value that should be subtracted from <see cref="Balance"/>.</param>
        /// <param name="reason">Reason why this value was withdrawn.</param>
        /// <param name="receiver">Reference to the <see cref="IBankAccount"/> that receives the balance.</param>
        /// <exception cref="ArgumentOutOfRangeException"><paramref name="amount"/> is 0 or lower.</exception>
        /// <exception cref="ArgumentNullException"><paramref name="reason"/> is null, empty or whitespace.</exception>
        /// <returns>true if transaction was accepted, false otherwise.</returns>
        bool TryWithdraw(decimal amount, string reason, IBankAccount? receiver = null);

        /// <summary>
        /// Deposits (increases <see cref="Balance"/>) the given <paramref name="amount"/> to this <see cref="IBankAccount"/>.
        /// If <paramref name="sender"/> is null, this <paramref name="amount"/> will be voided.
        /// The parameter <paramref name="sender"/> is only an informative value and should be used for persistance (e.g. <see cref="BankAccountTransaction"/> to remember to opposite side.
        /// </summary>
        /// <param name="amount">Value that should be added to <see cref="Balance"/>.</param>
        /// <param name="reason">Reason why this value was deposited.</param>
        /// <param name="sender">Reference to the <see cref="IBankAccount"/> that sent this balance.</param>
        /// <exception cref="ArgumentOutOfRangeException"><paramref name="amount"/> is 0 or lower.</exception>
        /// <exception cref="ArgumentNullException"><paramref name="reason"/> is null, empty or whitespace.</exception>
        /// <returns>true if transaction was accepted, false otherwise.</returns>
        bool TryDeposit(decimal amount, string reason, IBankAccount? sender = null);

        /// <summary>
        /// Transfers the given <paramref name="amount"/> from this account to <see cref="targetAccount"/>.
        /// </summary>
        /// <param name="targetAccount"><see cref="IBankAccount"/> that should receive the <paramref name="amount"/>.</param>
        /// <param name="amount">Value which should be withdrawn from this account and deposited to <paramref name="targetAccount"/>.</param>
        /// <param name="reason">Reason why this <paramref name="amount"/> was transferred.</param>
        /// <exception cref="ArgumentNullException"><paramref name="targetAccount"/> or <paramref name="reason"/> is null, empty or whitespace.</exception>
        /// <exception cref="ArgumentOutOfRangeException"><paramref name="amount"/> is 0 or lower.</exception>
        /// <returns>true of the transfer was successful.</returns>
        bool TryTransfer(IBankAccount targetAccount, decimal amount, string reason);

        /// <summary>
        /// Transfers the given <paramref name="amount"/> from this account to <see cref="targetAccount"/>.
        /// </summary>
        /// <param name="targetAccount"><see cref="IBankAccount"/> that should receive the <paramref name="amount"/>.</param>
        /// <param name="amount">Value which should be withdrawn from this account and deposited to <paramref name="targetAccount"/>.</param>
        /// <param name="reasonOnSourceAccount">Reason why this transaction was executed that will appear in the transaction history of this <see cref="IBankAccount"/>.</param>
        /// <param name="reasonOnTargetAccount">Reason why this transaction was executed that will appear in the transaction history of <paramref name="targetAccount"/>.</param>
        /// <exception cref="ArgumentNullException"><paramref name="targetAccount"/>, <paramref name="reasonOnSourceAccount"/> or <paramref name="reasonOnTargetAccount"/> is null, empty or whitespace.</exception>
        /// <exception cref="ArgumentOutOfRangeException"><paramref name="amount"/> is 0 or lower.</exception>
        /// <returns>true of the transfer was successful.</returns>
        bool TryTransfer(IBankAccount targetAccount, decimal amount, string reasonOnSourceAccount, string reasonOnTargetAccount);
    }
}
