using Newtonsoft.Json;
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
        private JsonSerializerSettings serializerSettings = new JsonSerializerSettings() { TypeNameHandling = TypeNameHandling.Auto };
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
            var file = GetFileName(transaction.DateTime.Month, transaction.DateTime.Year);
            List<Transaction> transactions;
            if (File.Exists(file))
            {
                transactions = JsonConvert.DeserializeObject<List<Transaction>>(File.ReadAllText(file), serializerSettings);
            }
            else
            {
                transactions = new List<Transaction>();
            }
            transactions.Add(transaction);
            File.WriteAllText(file, JsonConvert.SerializeObject(transactions));
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
                        transactions = JsonConvert.DeserializeObject<List<Transaction>>(File.ReadAllText(file), serializerSettings);
                        foreach (var item in transactions)
                        {
                            yield return item;
                        }
                    }
                }
            }
        }
        public bool RemoveTransaction(Transaction transaction)
        {
            var file = GetFileName(transaction.DateTime.Month, transaction.DateTime.Year);
            List<Transaction> transactions;
            if (File.Exists(file))
            {
                transactions = JsonConvert.DeserializeObject<List<Transaction>>(File.ReadAllText(file), serializerSettings);
                var result = transactions.RemoveAll(t => t.Guid == transaction.Guid);
                if (result == 0)
                    return false;
                File.WriteAllText(file, JsonConvert.SerializeObject(transactions));
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
            return Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), month + "-" + year + ".json");
        }
    }
}
