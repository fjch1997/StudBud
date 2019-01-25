using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Studbud.Data
{
    /// <summary>
    /// Process, store transactions and related data.
    /// </summary>
    public class TransactionStorageService : ITransactionStorageService
    {
        // TODO: Create fields that stores data and call file storage APIs to storage those data.
        
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
            throw new NotImplementedException();
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
            throw new NotImplementedException();
        }
        public void RemoveTransaction(Transaction transaction)
        {
            throw new NotImplementedException();
        }
        public void RemoveTransactionProvider(ITransactionProvider transactionProvider)
        {
            throw new NotImplementedException();
        }
    }
}
