using Studbud.Data;
using Studbud.External;
using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
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

        public TransactionsHomePageViewModel()
        {
            RefreshTransactionsCommand = new DelegateCommand(() =>
            {
                Transactions = new ObservableCollection<Transaction>(TransactionStorageService.GetTransactions(DateTime.Now.AddMonths(-3), DateTime.Now).OrderByDescending(t=>t.DateTime));
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
