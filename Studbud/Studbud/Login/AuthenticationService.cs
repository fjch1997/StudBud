using Newtonsoft.Json;
using System;
using System.ComponentModel;
using System.IO;
using System.Net.Http;
using System.Runtime.CompilerServices;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Studbud.Login
{
    public class AuthenticationService : IAuthenticationService, ISupportInitialize
    {
        private const string InitializationVector = "hg84138ru982qfei";
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
        public string Username { get => username; set { username = value; OnPropertyChanged(); } }
        private string username;
        public string Nickname { get => nickname; set { nickname = value; OnPropertyChanged(); } }
        private string nickname;
        public decimal Budget { get => budget; set { budget = value; OnPropertyChanged(); } }
        private decimal budget;
        public Uri ProfilePictureUri { get; set; }
        private string password;
        public Task LoginAsync(string username, string password)
        {
            Username = username;
            var userInfoFileName = GetUserInfoFileName(username);
            if (!File.Exists(userInfoFileName))
                throw new InvalidOperationException("This user does not exist.");
            this.password = password;
            try
            {
                var info = DeserializeEncrypted<UserInfo>(userInfoFileName);
                Username = info.Username;
                Nickname = info.NickName;
                Budget = info.Budget;
                LoggedIn = true;
            }
            catch (Exception)
            {
                throw new InvalidOperationException("Password incorrect.");
            }
            return Task.FromResult(false);
        }
        public Task RegisterAsync(string username, string password)
        {
            Username = username;
            var userInfoFileName = GetUserInfoFileName(username);
            if (File.Exists(userInfoFileName))
                throw new InvalidOperationException("User already exists.");
            var info = new UserInfo()
            {
                Username = username,
                NickName = username,
                Budget = 500M,
            };
            Budget = 500M;
            this.password = password;
            Directory.CreateDirectory(GetUserInfoDirectoryName());
            SerializeEncrypted(userInfoFileName, info);
            return Task.FromResult(false);
        }
        public void SerializeEncrypted(string fileName, object obj)
        {
            var key = new PasswordDeriveBytes(password, null).GetBytes(256 / 8);
            using (var symmetricKey = Aes.Create())
            {
                symmetricKey.Key = key;
                symmetricKey.IV = Encoding.UTF8.GetBytes(InitializationVector);
                using (var encryptor = symmetricKey.CreateEncryptor(symmetricKey.Key, symmetricKey.IV))
                using (var fileStream = File.Create(fileName))
                using (var stream = new CryptoStream(fileStream, encryptor, CryptoStreamMode.Write))
                using (var writer = new StreamWriter(stream, Encoding.UTF8))
                using (var jsonWriter = new JsonTextWriter(writer))
                {
                    var serializer = new JsonSerializer();
                    serializer.Serialize(jsonWriter, obj);
                }
            }
        }
        public T DeserializeEncrypted<T>(string fileName)
        {
            var key = new PasswordDeriveBytes(password, null).GetBytes(256 / 8);
            using (var symmetricKey = Aes.Create())
            {
                symmetricKey.Key = key;
                symmetricKey.IV = Encoding.UTF8.GetBytes(InitializationVector);
                using (var decryptor = symmetricKey.CreateDecryptor(symmetricKey.Key, symmetricKey.IV))
                using (var fileStream = File.Open(fileName, FileMode.Open))
                using (var stream = new CryptoStream(fileStream, decryptor, CryptoStreamMode.Read))
                using (var reader = new StreamReader(stream, Encoding.UTF8))
                using (var jsonReader = new JsonTextReader(reader))
                {
                    var text = reader.ReadToEnd();
                    return JsonConvert.DeserializeObject<T>(text);
                    //var serializer = new JsonSerializer();
                    //return serializer.Deserialize<T>(jsonReader);
                }
            }
        }
        public void Logout()
        {
            LoggedIn = false;
            Username = null;
            Nickname = null;
            ProfilePictureUri = null;
            password = null;
        }
        private static string GetUserInfoFileName(string username)
        {
            return Path.Combine(GetUserInfoDirectoryName(), username + ".json");
        }

        private static string GetUserInfoDirectoryName()
        {
            return Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "UserInfo");
        }
        public void SaveUserInfo()
        {
            var userInfoFileName = GetUserInfoFileName(username);
            var info = new UserInfo()
            {
                Username = username,
                NickName = username,
                Budget = Budget,
            };
            SerializeEncrypted(userInfoFileName, info);
        }
        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null) => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}
