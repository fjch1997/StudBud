using System;
using System.Collections.Generic;
using System.Text;

namespace Studbud.Data
{
    /// <summary>
    /// Responsible for synchronizing data with our server.
    /// </summary>
    public class DataSynchronizationService
    {
        private readonly ITransactionStorageService transactionStorageService;

        public DataSynchronizationService(ITransactionStorageService transactionStorageService)
        {
            this.transactionStorageService = transactionStorageService;
        }
    }
}
