using System;
using System.Collections.Generic;

namespace Studbud.Data
{
    public interface ITransactionProvider
    {
        /// <summary>
        /// Connects to the internet and get the requested transatcions from third party source.
        /// </summary>
        IEnumerable<Transaction> GetTransactions(DateTime startTime, DateTime endTime);
        /// <summary>
        /// Display name for this provider. Like Paypal.
        /// </summary>
        string Name { get; }
    }
}