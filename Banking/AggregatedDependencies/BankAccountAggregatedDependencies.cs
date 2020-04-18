using Micky5991.Banking.Interfaces;

namespace Micky5991.Banking.AggregatedDependencies
{
    public class BankAccountAggregatedDependencies
    {
        public BankAccountAggregatedDependencies(IBankAccountTransactionRepository transactionRepository)
        {
            this.TransactionRepository = transactionRepository;
        }

        public IBankAccountTransactionRepository TransactionRepository { get; }
    }
}
