using Studbud.Data;
using Studbud.External;
using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Studbud.Transactions
{
    public class NewTransactionPageViewModel : INotifyPropertyChanged
    {
        public ITransactionStorageService TransactionStorageService { get; set; }
        public INavigationService NavigationService { get; set; }
        public NewTransactionPageViewModel()
        {
            SaveCommand = new AsyncCommand(async () =>
            {
                if (Name == "AddTestData")
                {
                    TransactionStorageService.AddTransaction(new Transaction
                    {
                        Name = "Steak",
                        Amount = 12.95M,
                        Merchant = "Drexel",
                        Catagory = "Food",
                        DateTimeUtc = new DateTime(2019, 2, 28, 12, 32, 49),
                    });
                    TransactionStorageService.AddTransaction(new Transaction
                    {
                        Name = "Steak",
                        Amount = 12.95M,
                        Merchant = "Drexel",
                        Catagory = "Food",
                        DateTimeUtc = new DateTime(2019, 2, 28, 12, 32, 49),
                    });
                    TransactionStorageService.AddTransaction(new Transaction
                    {
                        Name = "Steak",
                        Amount = 12.95M,
                        Merchant = "Drexel",
                        Catagory = "Food",
                        DateTimeUtc = new DateTime(2019, 2, 28, 12, 32, 49),
                    });
                }
                if (Transaction != null)
                {
                    TransactionStorageService.RemoveTransaction(Transaction);
                }
                await Task.Run(() => TransactionStorageService.AddTransaction(new Transaction
                {
                    Guid = Guid.NewGuid(),
                    Amount = amount,
                    Catagory = catagory,
                    Name = name,
                    Merchant = merchant,
                    DateTimeUtc = date.Date.Add(time).ToUniversalTime(),
                }));
                await NavigationService.PopAsync();
            });
            DeleteCommand = new AsyncCommand(async () =>
            {
                await Task.Run(() => TransactionStorageService.RemoveTransaction(Transaction));
                await NavigationService.PopAsync();
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
        public Transaction Transaction { get => transaction; set { transaction = value; OnPropertyChanged(); } }
        private Transaction transaction;
        public ICommand SaveCommand { get; }
        public ICommand DeleteCommand { get; }

        private string merchant;
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null) => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        public event PropertyChangedEventHandler PropertyChanged;
    }
}
