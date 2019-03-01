using Studbud.Data;
using Studbud.External;
using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Studbud.Transactions
{
    public class TransactionsHomePageViewModel : INotifyPropertyChanged
    {
        public ITransactionStorageService TransactionStorageService { get; set; }
        public INavigationService NavigationService { get; set; }
        public ObservableCollection<Transaction> Transactions { get => transactions; set { transactions = value; OnPropertyChanged(); } }
        private ObservableCollection<Transaction> transactions;
        public ICommand RefreshTransactionsCommand { get; }
        public ICommand OpenAddTransactionsPageCommand { get; }
        public Transaction SelectedItem { set { if (value != null) NavigationService.PushAsync(new NewTransactionPage(value)); } }
        public bool Running { get => running; set { running = value; OnPropertyChanged(); } }
        private bool running;
        public TransactionsHomePageViewModel()
        {
            RefreshTransactionsCommand = new AsyncCommand(async () =>
            {
                Running = true;
                try
                {
                    Transactions = new ObservableCollection<Transaction>(await Task.Run(() => TransactionStorageService.GetTransactions(DateTime.UtcNow.AddMonths(-3), DateTime.UtcNow).OrderByDescending(t => t.DateTimeUtc)));
                }
                finally
                {
                    Running = false;
                }
            });
            OpenAddTransactionsPageCommand = new DelegateCommand(() =>
            {
                NavigationService.PushAsync(new NewTransactionPage());
            });
        }
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null) => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        public event PropertyChangedEventHandler PropertyChanged;
    }
}
