using Studbud.Login;
using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;

namespace Studbud.Data
{
    /// <summary>
    /// Process, store transactions and related data.
    /// </summary>
    public class TransactionStorageService : ITransactionStorageService
    {
        public IAuthenticationService AuthenticationService { get; set; }
        public TransactionStorageService()
        {
            // Run a background task to refresh transactions from transaction providers.
            Task.Run(async () =>
            {
                // TODO

                await Task.Delay(TimeSpan.FromMinutes(5));
            });
        }
        public void AddTransaction(Transaction transaction)
        {
            var file = GetFileName(transaction.DateTimeUtc.Month, transaction.DateTimeUtc.Year);
            List<Transaction> transactions;
            if (File.Exists(file))
            {
                transactions = AuthenticationService.DeserializeEncrypted<List<Transaction>>(file);
            }
            else
            {
                transactions = new List<Transaction>();
            }
            transactions.Add(transaction);
            AuthenticationService.SerializeEncrypted(file, transactions);
        }
        public void AddTransactionProvider(ITransactionProvider transactionProvider)
        {
            throw new NotImplementedException();
        }
        public IEnumerable<ITransactionProvider> GetTransactionProviders()
        {
            throw new NotImplementedException();
        }
        public IEnumerable<Transaction> GetTransactions(DateTime startTime, DateTime endTime)
        {
            for (int year = startTime.Year; year <= endTime.Year; year++)
            {
                for (int month = 1; month <= 12; month++)
                {
                    if (startTime.Year == year && month < startTime.Month || endTime.Year == year && month > endTime.Month)
                        continue;
                    var file = GetFileName(month, year);
                    List<Transaction> transactions;
                    if (File.Exists(file))
                    {
                        transactions = AuthenticationService.DeserializeEncrypted<List<Transaction>>(file);
                        foreach (var item in transactions)
                        {
                            if (item.DateTimeUtc > startTime && item.DateTimeUtc < endTime)
                                yield return item;
                        }
                    }
                }
            }
        }
        public bool RemoveTransaction(Transaction transaction)
        {
            var file = GetFileName(transaction.DateTimeUtc.Month, transaction.DateTimeUtc.Year);
            List<Transaction> transactions;
            if (File.Exists(file))
            {
                transactions = AuthenticationService.DeserializeEncrypted<List<Transaction>>(file);
                var result = transactions.RemoveAll(t => t.Guid == transaction.Guid);
                if (result == 0)
                    return false;
                AuthenticationService.SerializeEncrypted(file, transactions);
                return true;
            }
            else
            {
                return false;
            }
        }
        public void RemoveTransactionProvider(ITransactionProvider transactionProvider)
        {
            throw new NotImplementedException();
        }
        private string GetFileName(int month, int year)
        {
            var dir = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), AuthenticationService.Username);
            Directory.CreateDirectory(dir);
            return Path.Combine(dir, month + "-" + year + ".json");
        }
    }
}
