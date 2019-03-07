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
                        Amount = 50M,
                        Merchant = "Fogo De Chao",
                        Catagory = "Food",
                        DateTimeUtc = new DateTime(2019, 1, 28, 12, 32, 49),
                    });
                    TransactionStorageService.AddTransaction(new Transaction
                    {
                        Name = "Movie",
                        Amount = 12.50M,
                        Merchant = "AMC",
                        Catagory = "Entertainment",
                        DateTimeUtc = new DateTime(2019, 2, 20, 9, 20, 37),
                    });
                    TransactionStorageService.AddTransaction(new Transaction
                    {
                        Name = "Sandwich",
                        Amount = 5.99M,
                        Merchant = "Burger King",
                        Catagory = "Food",
                        DateTimeUtc = new DateTime(2019, 3, 18, 2, 45, 17),
                    });
                    TransactionStorageService.AddTransaction(new Transaction
                    {
                        Name = "Coffee",
                        Amount = 5.99M,
                        Merchant = "Starbucks",
                        Catagory = "Food",
                        DateTimeUtc = new DateTime(2019, 4, 29, 3, 46, 18),
                    });
                    TransactionStorageService.AddTransaction(new Transaction
                    {
                        Name = "Books",
                        Amount = 100M,
                        Merchant = "Drexel",
                        Catagory = "School",
                        DateTimeUtc = new DateTime(2019, 5, 30, 4, 47, 19),
                    });
                    TransactionStorageService.AddTransaction(new Transaction
                    {
                        Name = "Sandwich",
                        Amount = 5.99M,
                        Merchant = "Drexel",
                        Catagory = "Food",
                        DateTimeUtc = new DateTime(2019, 6, 1, 5, 48, 20),
                    });
                    TransactionStorageService.AddTransaction(new Transaction
                    {
                        Name = "Flight",
                        Amount = 200M,
                        Merchant = "Spirit",
                        Catagory = "Travel",
                        DateTimeUtc = new DateTime(2019, 7, 2, 6, 49, 21),
                    });
                    TransactionStorageService.AddTransaction(new Transaction
                    {
                        Name = "Bus",
                        Amount = 5.99M,
                        Merchant = "Septa",
                        Catagory = "Travel",
                        DateTimeUtc = new DateTime(2019, 8, 3, 7, 50, 22),
                    });
                    TransactionStorageService.AddTransaction(new Transaction
                    {
                        Name = "Taco",
                        Amount = 5.99M,
                        Merchant = "TacoBell",
                        Catagory = "Food",
                        DateTimeUtc = new DateTime(2019, 9, 4, 8, 51, 23),
                    });
                    TransactionStorageService.AddTransaction(new Transaction
                    {
                        Name = "Clothes",
                        Amount = 120M,
                        Merchant = "H&M",
                        Catagory = "Shopping",
                        DateTimeUtc = new DateTime(2019, 10, 5, 9, 52, 24),
                    });
                    TransactionStorageService.AddTransaction(new Transaction
                    {
                        Name = "Rent",
                        Amount = 600M,
                        Merchant = "Drexel",
                        Catagory = "Home",
                        DateTimeUtc = new DateTime(2019, 11, 6, 10, 53, 25),
                    });
                    TransactionStorageService.AddTransaction(new Transaction
                    {
                        Name = "Gas",
                        Amount = 24.29M,
                        Merchant = "Wawa",
                        Catagory = "Car",
                        DateTimeUtc = new DateTime(2019, 12, 7, 11, 54, 26),
                    });
                    TransactionStorageService.AddTransaction(new Transaction
                    {
                        Name = "Shoes",
                        Amount = 120M,
                        Merchant = "Shoe Carnival",
                        Catagory = "Shopping",
                        DateTimeUtc = new DateTime(2019, 1, 8, 12, 45, 17),
                    });
                    TransactionStorageService.AddTransaction(new Transaction
                    {
                        Name = "Uber",
                        Amount = 13.39M,
                        Merchant = "Uber",
                        Catagory = "Travel",
                        DateTimeUtc = new DateTime(2019, 2, 9, 1, 55, 27),
                    });
                    TransactionStorageService.AddTransaction(new Transaction
                    {
                        Name = "Bag",
                        Amount = 140M,
                        Merchant = "Amazon",
                        Catagory = "Shopping",
                        DateTimeUtc = new DateTime(2019, 3, 10, 2, 56, 28),
                    });
                    TransactionStorageService.AddTransaction(new Transaction
                    {
                        Name = "Car Parts",
                        Amount = 70M,
                        Merchant = "Auto Parts",
                        Catagory = "Car",
                        DateTimeUtc = new DateTime(2019, 4, 11, 3, 57, 29),
                    });
                    TransactionStorageService.AddTransaction(new Transaction
                    {
                        Name = "Flight",
                        Amount = 980M,
                        Merchant = "US Airways",
                        Catagory = "Travel",
                        DateTimeUtc = new DateTime(2019, 5, 12, 4, 58, 30),
                    });
                    TransactionStorageService.AddTransaction(new Transaction
                    {
                        Name = "Wrap",
                        Amount = 399M,
                        Merchant = "Dunkin Donuts",
                        Catagory = "Food",
                        DateTimeUtc = new DateTime(2019, 6, 13, 5, 59, 31),
                    });
                    TransactionStorageService.AddTransaction(new Transaction
                    {
                        Name = "Netflix Subscription",
                        Amount = 12.99M,
                        Merchant = "Amazon",
                        Catagory = "Entertainment",
                        DateTimeUtc = new DateTime(2019, 7, 14, 6, 1, 32),
                    });
                    TransactionStorageService.AddTransaction(new Transaction
                    {
                        Name = "Chair",
                        Amount = 298M,
                        Merchant = "Raymour and Fanigan",
                        Catagory = "Home",
                        DateTimeUtc = new DateTime(2019, 8, 15, 7, 2, 33),
                    });
                    TransactionStorageService.AddTransaction(new Transaction
                    {
                        Name = "Electricity Bill",
                        Amount = 67.43M,
                        Merchant = "PECO",
                        Catagory = "Home",
                        DateTimeUtc = new DateTime(2019, 9, 16, 8, 3, 34),
                    });
                    TransactionStorageService.AddTransaction(new Transaction
                    {
                        Name = "Engine Oil",
                        Amount = 25M,
                        Merchant = "Pepboys",
                        Catagory = "Car",
                        DateTimeUtc = new DateTime(2019, 10, 17, 9, 4, 35),
                    });
                    TransactionStorageService.AddTransaction(new Transaction
                    {
                        Name = "Groceries",
                        Amount = 47.98M,
                        Merchant = "Shop Rite",
                        Catagory = "Food",
                        DateTimeUtc = new DateTime(2019, 11, 18, 10, 5, 36),
                    });
                    TransactionStorageService.AddTransaction(new Transaction
                    {
                        Name = "Medicine",
                        Amount = 11.12M,
                        Merchant = "CVS Pharmacy",
                        Catagory = "Other",
                        DateTimeUtc = new DateTime(2019, 12, 19, 11, 6, 37),
                    });
                    TransactionStorageService.AddTransaction(new Transaction
                    {
                        Name = "Prime Subscription",
                        Amount = 13.99M,
                        Merchant = "Amazon",
                        Catagory = "Entertainment",
                        DateTimeUtc = new DateTime(2019, 1, 20, 12, 7, 38),
                    });
                    TransactionStorageService.AddTransaction(new Transaction
                    {
                        Name = "Humidifier",
                        Amount = 24.99M,
                        Merchant = "Walmart",
                        Catagory = "Home",
                        DateTimeUtc = new DateTime(2019, 2, 21, 1, 8, 39),
                    });
                    TransactionStorageService.AddTransaction(new Transaction
                    {
                        Name = "Smoothie",
                        Amount = 5.99M,
                        Merchant = "Baskin Robbins",
                        Catagory = "Food",
                        DateTimeUtc = new DateTime(2019, 3, 22, 2, 9, 40),
                    });
                    TransactionStorageService.AddTransaction(new Transaction
                    {
                        Name = "Internet Bill",
                        Amount = 90M,
                        Merchant = "Comcast",
                        Catagory = "Home",
                        DateTimeUtc = new DateTime(2019, 4, 23, 3, 10, 41),
                    });
                    TransactionStorageService.AddTransaction(new Transaction
                    {
                        Name = "Flowers",
                        Amount = 69.99M,
                        Merchant = "Kremp",
                        Catagory = "Other",
                        DateTimeUtc = new DateTime(2019, 2, 14, 9, 11, 42),
                    });
                    TransactionStorageService.AddTransaction(new Transaction
                    {
                        Name = "Phone",
                        Amount = 916M,
                        Merchant = "Apple",
                        Catagory = "Shopping",
                        DateTimeUtc = new DateTime(2019, 6, 25, 5, 12, 43),
                    });
                    TransactionStorageService.AddTransaction(new Transaction
                    {
                        Name = "Spotify",
                        Amount = 9.99M,
                        Merchant = "Spotify",
                        Catagory = "Entertainment",
                        DateTimeUtc = new DateTime(2019, 7, 26, 6, 13, 44),
                    });
                    TransactionStorageService.AddTransaction(new Transaction
                    {
                        Name = "Milk",
                        Amount = 3.99M,
                        Merchant = "Wawa",
                        Catagory = "Food",
                        DateTimeUtc = new DateTime(2019, 8, 27, 7, 14, 45),
                    });
                    TransactionStorageService.AddTransaction(new Transaction
                    {
                        Name = "Games",
                        Amount = 14.99M,
                        Merchant = "GameStop",
                        Catagory = "Entertainment",
                        DateTimeUtc = new DateTime(2019, 9, 28, 8, 15, 46),
                    });
                    TransactionStorageService.AddTransaction(new Transaction
                    {
                        Name = "Photos",
                        Amount = 5.12M,
                        Merchant = "Walgreens",
                        Catagory = "Other",
                        DateTimeUtc = new DateTime(2019, 10, 29, 9, 16, 47),
                    });
                    TransactionStorageService.AddTransaction(new Transaction
                    {
                        Name = "Donation",
                        Amount = 3M,
                        Merchant = "American Heart Association",
                        Catagory = "Other",
                        DateTimeUtc = new DateTime(2019, 11, 30, 10, 17, 48),
                    });
                    TransactionStorageService.AddTransaction(new Transaction
                    {
                        Name = "Gas Bill",
                        Amount = 67.15M,
                        Merchant = "PGW",
                        Catagory = "Home",
                        DateTimeUtc = new DateTime(2019, 12, 1, 11, 18, 49),
                    });
                    TransactionStorageService.AddTransaction(new Transaction
                    {
                        Name = "Jewelry",
                        Amount = 180M,
                        Merchant = "Macys",
                        Catagory = "Shopping",
                        DateTimeUtc = new DateTime(2019, 1, 2, 12, 19, 50),
                    });
                    TransactionStorageService.AddTransaction(new Transaction
                    {
                        Name = "Lyft",
                        Amount = 7.29M,
                        Merchant = "Lyft",
                        Catagory = "Travel",
                        DateTimeUtc = new DateTime(2019, 2, 3, 1, 20, 51),
                    });
                    TransactionStorageService.AddTransaction(new Transaction
                    {
                        Name = "Train",
                        Amount = 6M,
                        Merchant = "Septa",
                        Catagory = "Travel",
                        DateTimeUtc = new DateTime(2019, 3, 4, 2, 21, 52),
                    });
                    TransactionStorageService.AddTransaction(new Transaction
                    {
                        Name = "Laptop",
                        Amount = 780M,
                        Merchant = "Best Buy",
                        Catagory = "School",
                        DateTimeUtc = new DateTime(2019, 4, 5, 3, 22, 53),
                    });
                    TransactionStorageService.AddTransaction(new Transaction
                    {
                        Name = "Hoggie",
                        Amount = 3.50M,
                        Merchant = "Food Truck",
                        Catagory = "Food",
                        DateTimeUtc = new DateTime(2019, 5, 6, 4, 23, 54),
                    });
                    TransactionStorageService.AddTransaction(new Transaction
                    {
                        Name = "Air Conditioner",
                        Amount = 320M,
                        Merchant = "Home Depot",
                        Catagory = "Home",
                        DateTimeUtc = new DateTime(2019, 6, 7, 5, 24, 55),
                    });
                    TransactionStorageService.AddTransaction(new Transaction
                    {
                        Name = "Latte",
                        Amount = 4.10M,
                        Merchant = "Dunkin Donuts",
                        Catagory = "Food",
                        DateTimeUtc = new DateTime(2019, 7, 8, 6, 25, 56),
                    });
                    TransactionStorageService.AddTransaction(new Transaction
                    {
                        Name = "Transfer",
                        Amount = 30M,
                        Merchant = "PayPal",
                        Catagory = "Other",
                        DateTimeUtc = new DateTime(2019, 8, 9, 7, 26, 57),
                    });
                    TransactionStorageService.AddTransaction(new Transaction
                    {
                        Name = "Tuition",
                        Amount = 829.52M,
                        Merchant = "Drexel",
                        Catagory = "School",
                        DateTimeUtc = new DateTime(2019, 9, 10, 8, 27, 58),
                    });
                    TransactionStorageService.AddTransaction(new Transaction
                    {
                        Name = "Water Bill",
                        Amount = 50.37M,
                        Merchant = "PWD",
                        Catagory = "Home",
                        DateTimeUtc = new DateTime(2019, 10, 11, 9, 28, 59),
                    });
                    TransactionStorageService.AddTransaction(new Transaction
                    {
                        Name = "Camera",
                        Amount = 580M,
                        Merchant = "Best Buy",
                        Catagory = "Shopping",
                        DateTimeUtc = new DateTime(2019, 11, 12, 10, 29, 1),
                    });
                    TransactionStorageService.AddTransaction(new Transaction
                    {
                        Name = "HandBag",
                        Amount = 240M,
                        Merchant = "Micheal Kors",
                        Catagory = "Shopping",
                        DateTimeUtc = new DateTime(2019, 12, 13, 11, 30, 2),
                    });
                    TransactionStorageService.AddTransaction(new Transaction
                    {
                        Name = "Games",
                        Amount = 5.99M,
                        Merchant = "Xbox",
                        Catagory = "Entertainment",
                        DateTimeUtc = new DateTime(2019, 1, 14, 12, 31, 3),
                    });
                    TransactionStorageService.AddTransaction(new Transaction
                    {
                        Name = "Pizza",
                        Amount = 12.99M,
                        Merchant = "Dominos",
                        Catagory = "Food",
                        DateTimeUtc = new DateTime(2019, 2, 15, 1, 32, 4),
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
