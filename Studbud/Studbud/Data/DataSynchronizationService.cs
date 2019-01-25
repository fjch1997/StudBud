using Studbud.Login;
using System;
using System.ComponentModel;
using System.Net.Http;

namespace Studbud.Data
{
    /// <summary>
    /// Responsible for synchronizing data with our server.
    /// </summary>
    public class DataSynchronizationService : IDataSynchronizationService, ISupportInitialize
    {
        public IAuthenticationService AuthenticationService { get; set; }
        /// <summary>
        /// An injected HttpClient to handle all HTTP calls in order to facilitate Unit Test.
        /// Read more about this technique by searching "Unit Test HttpClient".
        /// </summary>
        public HttpClient HttpClient { get; set; }

        public void BeginInit() { }

        public void EndInit()
        {
            if (AuthenticationService == null) throw new ArgumentNullException(nameof(AuthenticationService));
            if (HttpClient == null) throw new ArgumentNullException(nameof(HttpClient));
        }
    }
}
