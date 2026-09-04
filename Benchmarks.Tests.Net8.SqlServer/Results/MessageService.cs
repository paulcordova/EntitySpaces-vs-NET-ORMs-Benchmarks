using System;

namespace Benchmarks.Tests.Net8.SqlServer.Results
{
    public class MessageService
    {
        public LastResult LastResult { get; set; }

        public void SetLastResult(int amount, TimeSpan tempoResult, double ram, TypeTransaction typeTransaction, OperationType operationType, double totalRam) =>
            LastResult = new LastResult(amount, tempoResult, ram, typeTransaction, operationType, totalRam);
    }
}
