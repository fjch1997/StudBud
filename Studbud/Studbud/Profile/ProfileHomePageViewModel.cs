using Studbud.Data;
using Studbud.External;
using Studbud.Login;
using System;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Windows.Input;

namespace Studbud.Profile
{
    public class ProfileHomePageViewModel : INotifyPropertyChanged
    {
        public ITransactionStorageService TransactionStorageService { get; set; }
        public IAuthenticationService AuthenticationService { get; set; }
        public INavigationService NavigationService { get; set; }
        public ProfileHomePageViewModel()
        {
            var startTime = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);
            var endTime = new DateTime(DateTime.Now.Year, DateTime.Now.Month + 1, 1).AddDays(-1);
            spent = TransactionStorageService.GetTransactions(startTime, endTime).Sum(t => t.Amount);
            LogoutCommand = new DelegateCommand(() =>
            {
                AuthenticationService.Logout();
                NavigationService.LoadLoginPage();
            });
        }

        public decimal Savings => Budget - Spent;
        public decimal Budget { get => budget; set { budget = value; OnPropertyChanged(); OnPropertyChanged(nameof(Savings)); } }
        private decimal budget;
        public decimal Spent { get => spent; set { spent = value; OnPropertyChanged(); } }

   

        private decimal spent;

        public DelegateCommand LogoutCommand { get; }

        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null) => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        
    }
}
