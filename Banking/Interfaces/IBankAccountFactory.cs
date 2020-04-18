using JetBrains.Annotations;

namespace Micky5991.Banking.Interfaces
{
    [PublicAPI]
    public interface IBankAccountFactory
    {
        IBankAccount CreateBankAccount(decimal balance, string? identifier = null);
    }
}
