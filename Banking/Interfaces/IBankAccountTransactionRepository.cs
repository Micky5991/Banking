using System.Collections.Generic;
using Micky5991.Banking.Data;

namespace Micky5991.Banking.Interfaces
{
    public interface IBankAccountTransactionRepository
    {
        ICollection<BankAccountTransaction> GetTransactions(IBankAccount bankAccount);
    }
}
