using System;
using System.Collections.Generic;
using System.ComponentModel;
using JetBrains.Annotations;
using Micky5991.Banking.Data;

namespace Micky5991.Banking.Interfaces
{
    [PublicAPI]
    public interface IBankAccount : IDisposable, INotifyPropertyChanged
    {
        event EventHandler? Disposed;

        object DatabaseIdentifier { get; }

        string Identifier { get; }

        decimal Balance { get; }

        ICollection<BankAccountTransaction> GetTransactions(int transactionLimit = 50);

        bool TryWithdraw(decimal amount, string reason);

        bool TryDeposit(decimal amount, string reason);

        bool TryTransfer(IBankAccount targetAccount, decimal amount, string reason);
    }
}
