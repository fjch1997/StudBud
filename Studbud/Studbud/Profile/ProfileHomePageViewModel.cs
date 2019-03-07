using Studbud.Data;
using Studbud.External;
using Studbud.Login;
using System;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;

namespace Studbud.Profile
{
    public class ProfileHomePageViewModel : INotifyPropertyChanged, ISupportInitialize
    {
        public ITransactionStorageService TransactionStorageService { get; set; }
        public IAuthenticationService AuthenticationService { get; set; }
        public INavigationService NavigationService { get; set; }
        public ProfileHomePageViewModel()
        {
            LogoutCommand = new DelegateCommand(() =>
            {
                AuthenticationService.Logout();
                NavigationService.LoadLoginPage();
            });
        }

        public decimal Savings => Budget - Spent;
        private Task saveBudgetTask;
        public decimal Budget
        {
            get => budget; set
            {
                if (value == 0) return;
                budget = value; OnPropertyChanged();
                OnPropertyChanged(nameof(Savings));
                AuthenticationService.Budget = value;
                saveBudgetTask = Task.Delay(2000);
                saveBudgetTask.ContinueWith(t =>
                {
                    if (saveBudgetTask == t) AuthenticationService.SaveUserInfo();
                });
            }
        }
        private decimal budget;
        public decimal Spent { get => spent; set { spent = value; OnPropertyChanged(); } }
        private decimal spent;

        public DelegateCommand LogoutCommand { get; }

        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null) => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));

        public void BeginInit()
        {
        }

        public void EndInit()
        {
            var startTime = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1).AddDays(-1);
            var endTime = DateTime.UtcNow;
            Spent = TransactionStorageService.GetTransactions(startTime, endTime).Sum(t => t.Amount);
            Budget = AuthenticationService.Budget;
        }
    }
}
