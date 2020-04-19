using Micky5991.Banking.Interfaces;

namespace Micky5991.Banking.Factories
{
    /// <inheritdoc />
    public class BankAccountFactory : IBankAccountFactory
    {
        /// <inheritdoc />
        public IBankAccount CreateBankAccount(string identifier, decimal balance)
        {
            throw new System.NotImplementedException();
        }
    }
}
