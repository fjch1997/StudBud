using Studbud.Login;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace Studbud
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            var authenticationService = (AuthenticationService)Resources[nameof(AuthenticationService)];
            authenticationService.PropertyChanged += AuthenticationService_PropertyChanged;
            if (authenticationService.LoggedIn)
                MainPage = new MainPage();
            else
                MainPage = new LoginPage();
        }

        private void AuthenticationService_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            var authenticationService = (AuthenticationService)sender;
            if (e.PropertyName == nameof(AuthenticationService.LoggedIn))
            {
                if (authenticationService.LoggedIn)
                    MainPage = new MainPage();
                else
                    MainPage = new LoginPage();
            }
        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
