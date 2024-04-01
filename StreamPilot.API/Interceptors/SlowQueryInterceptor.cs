using System.Data.Common;
using Microsoft.EntityFrameworkCore.Diagnostics;

namespace StreamPilot.Api.Interceptors
{
    public class SlowQueryInterceptor : DbCommandInterceptor
    {
        private const int _slowQueryThreshold = 200; // miliseconds

        public override DbDataReader ReaderExecuted(DbCommand command, CommandExecutedEventData eventData, DbDataReader result)
        {
            if (eventData.Duration.TotalMilliseconds > _slowQueryThreshold)
            {
                // Log slow query. We must replace this with our logging mechanism.
                Console.WriteLine($"Slow query ({eventData.Duration.TotalMilliseconds} ms): {command.CommandText}");
            }

            return base.ReaderExecuted(command, eventData, result);
        }
    }
}