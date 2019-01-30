using Studbud.External;
using System.ComponentModel;
using System.Net.Http;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using Xamarin.Forms;

namespace Studbud.Login
{
    public class LoginPageViewModel : INotifyPropertyChanged
    {
        public HttpClient HttpClient { get; set; }
        public IAuthenticationService AuthenticationService { get; set; }

        public string Username { get => username; set { username = value; OnPropertyChanged(); } }
        private string username;
        public string Password { get => password; set { password = value; OnPropertyChanged(); } }
        private string password;

        public ICommand LoginCommand { get; set; }

        public LoginPageViewModel()
        {
            LoginCommand = new DelegateCommand(async () =>
            {
                Username = "****";
                var result = await HttpClient.GetAsync("https://server.com/login");
                if (true)
                {
                    Application.Current.MainPage = new MainPage();
                }
            });
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
