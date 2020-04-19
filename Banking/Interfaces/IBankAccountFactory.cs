using System;
using JetBrains.Annotations;

namespace Micky5991.Banking.Interfaces
{
    /// <summary>
    /// Factory that is responsible to create <see cref="IBankAccount"/> instances.
    /// </summary>
    [PublicAPI]
    public interface IBankAccountFactory
    {
        /// <summary>
        /// Method that creates a new <see cref="IBankAccount"/> instance with the given parameters.
        /// </summary>
        /// <param name="identifier">Human readable identifier of this <see cref="IBankAccount"/>.</param>
        /// <param name="balance">Current balance this account has.</param>
        /// <exception cref="ArgumentNullException"><paramref name="identifier"/> is null, empty or whitespace.</exception>
        /// <returns>Newly created instance of <see cref="IBankAccount"/>.</returns>
        IBankAccount CreateBankAccount(string identifier, decimal balance);
    }
}
