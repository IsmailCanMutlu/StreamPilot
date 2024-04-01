using System;
using System.Threading;
using System.Threading.Tasks;

namespace StreamPilot.Api.Utilities
{
    public static class SemaphoreHelper
    {
        private static readonly SemaphoreSlim _semaphore = new SemaphoreSlim(1, 1);

        public static async Task OnlyOneThreadAllowedAsync(Func<Task> action)
        {
            if (!await _semaphore.WaitAsync(100))
            {
                // When it times out it returns without taking any action.
                return;
            }

            try
            {
                await action();
            }
            finally
            {
                _semaphore.Release();
            }
        }
    }
}