using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Threading.Tasks;

namespace Studbud.Login
{
    public interface IAuthenticationService : INotifyPropertyChanged
    {
        bool LoggedIn { get; }
        /// <summary>
        /// An authenticated token to be used by other services within the app to communicate with our backend.
        /// </summary>
        string Token { get; }
        /// <summary>
        /// To login with our backend. Any login error will be returned by an exception. Exception message will be displayed to the user.
        /// TODO: Create and list all possible exceptions here (Password incorrect, server is down etc.).
        /// </summary>
        Task LoginAsync(string username, string password);
        string Username { get; }
        Uri ProfilePictureUri { get; }

        /// TODO: other user data.
    }
}
