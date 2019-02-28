using Studbud.Data;
using Studbud.External;
using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;

namespace Studbud.Transactions
{
    public class NewTransactionPageViewModel : INotifyPropertyChanged
    {
        public ITransactionStorageService TransactionStorageService { get; set; }
        public INavigationService NavigationService { get; set; }
        public NewTransactionPageViewModel()
        {
            SaveCommand = new DelegateCommand(() =>
            {
                if (Transaction != null)
                {
                    TransactionStorageService.RemoveTransaction(Transaction);
                }
                TransactionStorageService.AddTransaction(new Transaction
                {
                    Guid = Guid.NewGuid(),
                    Amount = amount,
                    Catagory = catagory,
                    Name = name,
                    Merchant = merchant,
                    DateTimeUtc = date.Date.Add(time).ToUniversalTime(),
                });
                NavigationService.PopAsync();
            });
            DeleteCommand = new DelegateCommand(() =>
            {
                TransactionStorageService.RemoveTransaction(Transaction);
            });
        }
        public string Name { get => name; set { name = value; OnPropertyChanged(); } }
        private string name;
        public decimal Amount { get => amount; set { amount = value; OnPropertyChanged(); } }
        private decimal amount;
        public string Catagory { get => catagory; set { catagory = value; OnPropertyChanged(); } }
        private string catagory;
        public string Merchant { get => merchant; set { merchant = value; OnPropertyChanged(); } }
        public DateTime Date { get => date; set { date = value; OnPropertyChanged(); } }
        private DateTime date = DateTime.Now.Date;
        public TimeSpan Time { get => time; set { time = value; OnPropertyChanged(); } }
        private TimeSpan time = DateTime.Now.TimeOfDay;
        public ICommand SaveCommand { get; }
        public ICommand DeleteCommand { get; }
        public Transaction Transaction { get; internal set; }

        private string merchant;
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null) => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        public event PropertyChangedEventHandler PropertyChanged;
    }
}
