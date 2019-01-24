using System;
using System.Collections.Generic;
using System.Text;

namespace Studbud.Data
{
    public class PaypalTransactionProvider : ITransactionProvider
    {
        public string Name => throw new NotImplementedException();

        public IEnumerable<Transaction> GetTransactions(DateTime startTime, DateTime endTime)
        {
            throw new NotImplementedException();
        }
    }
}
