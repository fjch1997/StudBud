using Studbud.External;
using System;
using System.ComponentModel;
using System.Net.Http;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace Studbud.Login
{
    public class LoginPageViewModel : INotifyPropertyChanged, ISupportInitialize
    {
        public HttpClient HttpClient { get; set; }
        public IAuthenticationService AuthenticationService { get; set; }
        public INavigationService NavigationService { get; set; }
        public void BeginInit() { }
        public void EndInit()
        {
            if (HttpClient == null) throw new ArgumentNullException(nameof(HttpClient));
            if (AuthenticationService == null) throw new ArgumentNullException(nameof(AuthenticationService));
            if (NavigationService == null) throw new ArgumentNullException(nameof(NavigationService));
        }

        public string Username { get => username; set { username = value; OnPropertyChanged(); } }
        private string username;
        public string Password { get => password; set { password = value; OnPropertyChanged(); } }
        private string password;
        public string ErrorMessage { get => errorMessage; set { errorMessage = value; OnPropertyChanged(); } }
        private string errorMessage;
        public bool Running { get => running; set { running = value; OnPropertyChanged(); } }
        private bool running;
        public ICommand LoginCommand { get; set; }
        public ICommand RegisterCommand { get; set; }

        public LoginPageViewModel()
        {
            LoginCommand = new AsyncCommand(async () =>
            {
                try
                {
                    ErrorMessage = null;
                    Running = true;
                    await Task.Run(async () => await AuthenticationService.LoginAsync(Username, Password));
                    NavigationService.LoadMainPage();
                }
                catch (Exception ex)
                {
                    ErrorMessage = ex.Message;
                }
                finally
                {
                    Running = false;
                }
            });
            RegisterCommand = new DelegateCommand(() =>
            {
                NavigationService.PushAsync(new RegisterPage());
            });
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

    }
}
