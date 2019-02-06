using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Net.Http;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Studbud.Login
{
    public class AuthenticationService : IAuthenticationService, ISupportInitialize
    {
        /// <summary>
        /// An injected HttpClient to handle all HTTP calls in order to facilitate Unit Test.
        /// Read more about this technique by searching "Unit Test HttpClient".
        /// </summary>
        public HttpClient HttpClient { get; set; }
        public void BeginInit() { }
        public void EndInit()
        {
            if (HttpClient == null) throw new ArgumentNullException(nameof(HttpClient));
        }
        public bool LoggedIn { get => loggedIn; set { loggedIn = value; OnPropertyChanged(); } }
        private bool loggedIn;
        public string Token { get => token; set { token = value; OnPropertyChanged(); } }
        private string token;
        public string Username { get; set; }
        public Uri ProfilePictureUri { get; set; }
        public Task LoginAsync(string username, string password)
        {
            Username = username;
            return Task.FromResult(false);
        }
        public Task RegisterAsync(string username, string password)
        {
            // TODO
            return Task.FromResult(false);
        }
        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null) => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));

    }
}
