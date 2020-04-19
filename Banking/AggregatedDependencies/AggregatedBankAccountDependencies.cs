using Micky5991.Banking.Interfaces;

namespace Micky5991.Banking.AggregatedDependencies
{
    public class AggregatedBankAccountDependencies
    {
        public AggregatedBankAccountDependencies(IBankAccountTransactionRepository transactionRepository)
        {
            this.TransactionRepository = transactionRepository;
        }

        public IBankAccountTransactionRepository TransactionRepository { get; }
    }
}
