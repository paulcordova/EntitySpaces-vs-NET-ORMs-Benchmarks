namespace Benchmarks.Tests.Net8.SqlServer.Results
{
    public enum TypeTransaction
    {
        Dapper,
        Ef6,
        EfCore,
        EfCoreAsNoTracking,
        EfCoreAsNoTrackingSqlHard,
        Ado
    }
}
