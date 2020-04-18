using System.ComponentModel;
using System.Runtime.CompilerServices;
using JetBrains.Annotations;

namespace Micky5991.Banking.Entities
{
    /// <content>
    /// Property implementations and <see cref="INotifyPropertyChanged"/> implementation.
    /// </content>
    public partial class BankAccount
    {
        private decimal balance;

        /// <inheritdoc/>
        public event PropertyChangedEventHandler? PropertyChanged;

        /// <inheritdoc />
        public string Identifier { get; }

        /// <inheritdoc />
        public decimal Balance
        {
            get => this.balance;
            private set
            {
                if (value == this.balance)
                {
                    return;
                }

                this.balance = value;

                this.OnPropertyChanged();
            }
        }

        /// <summary>
        /// Invocator for the interface <see cref="INotifyPropertyChanged"/>.
        /// </summary>
        /// <param name="propertyName">Name of the property that has been changed.</param>
        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string? propertyName = null)
        {
            this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
