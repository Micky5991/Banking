using Micky5991.Banking.Interfaces;

namespace Micky5991.Banking.Data
{
    public class BankAccountTransaction
    {
        public BankAccountTransaction(object id, decimal amount, IBankAccount? sourceAccount, IBankAccount targetAccount, string reason)
        {
            this.Id = id;
            this.Amount = amount;
            this.SourceAccount = sourceAccount;
            this.TargetAccount = targetAccount;
            this.Reason = reason;
        }

        public object Id { get; }

        public decimal Amount { get; }

        public IBankAccount? SourceAccount { get; }

        public IBankAccount TargetAccount { get; }

        public string Reason { get; }
    }
}
