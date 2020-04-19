using JetBrains.Annotations;
using Micky5991.Banking.Entities;
using Micky5991.Banking.Interfaces;

namespace Micky5991.Banking.AggregatedDependencies
{
    /// <summary>
    /// Container for all <see cref="BankAccount"/> dependencies.
    /// </summary>
    [UsedImplicitly]
    public class AggregatedBankAccountDependencies
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="AggregatedBankAccountDependencies"/> class.
        /// </summary>
        /// <param name="transactionRepository">Instance of <see cref="IBankAccountTransactionRepository"/>.</param>
        public AggregatedBankAccountDependencies(IBankAccountTransactionRepository transactionRepository)
        {
            this.TransactionRepository = transactionRepository;
        }

        /// <summary>
        /// Gets the dependency instance of <see cref="IBankAccountTransactionRepository"/>.
        /// </summary>
        public IBankAccountTransactionRepository TransactionRepository { get; }
    }
}
