using System;
using Micky5991.Banking.AggregatedDependencies;
using Micky5991.Banking.Factories;
using Micky5991.Banking.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace Micky5991.Banking.Extensions
{
    /// <summary>
    /// Provides extensions for <see cref="IServiceCollection"/> to simplify registrations.
    /// </summary>
    public static class BankingDependencyInjectionExtensions
    {
        /// <summary>
        /// Registers all default banking services.
        /// </summary>
        /// <param name="serviceCollection">Collection of services in which these services should be registered to.</param>
        /// <returns>Passed service in <paramref name="serviceCollection"/>.</returns>
        /// <exception cref="ArgumentNullException"><paramref name="serviceCollection"/> is null.</exception>
        public static IServiceCollection AddDefaultBankingDependencies(this IServiceCollection serviceCollection)
        {
            serviceCollection
                .AddDefaultAggregatedBankingDependencies()
                .AddDefaultBankAccountFactory();

            return serviceCollection;
        }

        /// <summary>
        /// Registes the default aggregated banking service dependencies.
        /// </summary>
        /// <param name="serviceCollection">Collection of services in which these services should be registered to.</param>
        /// <returns>Passed service in <paramref name="serviceCollection"/>.</returns>
        /// <exception cref="ArgumentNullException"><paramref name="serviceCollection"/> is null.</exception>
        public static IServiceCollection AddDefaultAggregatedBankingDependencies(
            this IServiceCollection serviceCollection)
        {
            serviceCollection.AddTransient<AggregatedBankAccountDependencies>();

            return serviceCollection;
        }

        /// <summary>
        /// Registers the default implementation for <see cref="IBankAccountFactory"/>.
        /// </summary>
        /// <param name="serviceCollection">Collection of services in which these services should be registered to.</param>
        /// <returns>Passed service in <paramref name="serviceCollection"/>.</returns>
        /// <exception cref="ArgumentNullException"><paramref name="serviceCollection"/> is null.</exception>
        public static IServiceCollection AddDefaultBankAccountFactory(this IServiceCollection serviceCollection)
        {
            serviceCollection.AddTransient<IBankAccountFactory, BankAccountFactory>();

            return serviceCollection;
        }
    }
}
