using Microsoft.Data.SqlClient;
using System;

namespace Benchmarks.Tests.Net8.SqlServer.Extensions
{
    public static class DataReaderHelpers
    {
        public static T GetFieldValue<T>(this SqlDataReader dr, string name)
        {
            T ret = default;

            if (!dr[name].Equals(DBNull.Value))
                ret = (T)dr[name];

            return ret;
        }
    }
}
