using Studbud.Login;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace Studbud
{
    public partial class App : Application
    {
        private NavigationService NavigationService => (NavigationService)Resources[nameof(NavigationService)];
        private AuthenticationService AuthenticationService => (AuthenticationService)Resources[nameof(AuthenticationService)];
        public App()
        {
            InitializeComponent();
        }

        private void AuthenticationService_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            var authenticationService = (AuthenticationService)sender;
            if (e.PropertyName == nameof(AuthenticationService.LoggedIn))
            {
                NavigateBasedOnLogin();
            }
        }

        protected override void OnStart()
        {
            AuthenticationService.PropertyChanged += AuthenticationService_PropertyChanged;
            NavigateBasedOnLogin();
        }

        private void NavigateBasedOnLogin()
        {
            if (AuthenticationService.LoggedIn)
                NavigationService.LoadMainPage();
            else
                NavigationService.LoadLoginPage();
        }
    }
}
