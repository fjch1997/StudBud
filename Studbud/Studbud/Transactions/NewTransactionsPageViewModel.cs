using Studbud.Data;
using Studbud.External;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;
using System.Windows.Input;

namespace Studbud.Transactions
{
    public class NewTransactionsPageViewModel : INotifyPropertyChanged
    {
        public ITransactionStorageService TransactionStorageService { get; set; }
        public INavigationService NavigationService { get; set; }
        public NewTransactionsPageViewModel()
        {
            SaveCommand = new DelegateCommand(() =>
            {
                TransactionStorageService.AddTransaction(new Transaction
                {
                    Guid = Guid.NewGuid(),
                    Amount = amount,
                    Catagory = catagory,
                    Name = name,
                    Merchant = merchant,
                });
                NavigationService.PopAsync();
            });
        }
        public string Name { get => name; set { name = value; OnPropertyChanged(); } }
        private string name;
        public decimal Amount { get => amount; set { amount = value; OnPropertyChanged(); } }
        private decimal amount;
        public string Catagory { get => catagory; set { catagory = value; OnPropertyChanged(); } }
        private string catagory;
        public string Merchant { get => merchant; set { merchant = value; OnPropertyChanged(); } }
        public ICommand SaveCommand { get; }
        private string merchant;
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null) => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        public event PropertyChangedEventHandler PropertyChanged;
    }
}
