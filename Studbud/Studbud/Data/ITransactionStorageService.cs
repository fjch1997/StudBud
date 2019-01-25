using System;
using System.Collections.Generic;
using System.Text;

namespace Studbud.Data
{
    /// <summary>
    /// Consumers of this class will use this interface for dependency injection. Unit tests will use this to build mock up TransactionStorageManager.
    /// If you need additional features from <see cref="ITransactionStorageService"/>, feel free to coordinate to get those methods/properties implemented.
    /// </summary>
    public interface ITransactionStorageService
    {
        void AddTransaction(Transaction transaction);
        IEnumerable<Transaction> GetTransactions(DateTime startTime, DateTime endTime);
        void RemoveTransaction(Transaction transaction);
        void AddTransactionProvider(ITransactionProvider transactionProvider);
        void RemoveTransactionProvider(ITransactionProvider transactionProvider);
        IEnumerable<ITransactionProvider> GetTransactionProviders();
    }
}
