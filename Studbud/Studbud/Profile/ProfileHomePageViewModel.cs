using Studbud.Data;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace Studbud.Profile
{
    public class ProfileHomePageViewModel : INotifyPropertyChanged
    {
        public ITransactionStorageService TransactionStorageService { get; set; }
        public ProfileHomePageViewModel()
        {
            // TODO: Populate properties with data.
        }
        public decimal Savings { get => savings; set { savings = value; OnPropertyChanged(); } }
        private decimal savings;
        public decimal Budget { get => budget; set { budget = value; OnPropertyChanged(); } }
        private decimal budget;
        public decimal Spent { get => spent; set { spent = value; OnPropertyChanged(); } }
        private decimal spent;
        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null) => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}
