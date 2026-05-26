using System;
using System.Collections.Concurrent;
using System.Threading.Tasks;

namespace SecureShoppingPlatform.Services
{
    public class LoginAttemptService
    {
        private readonly ConcurrentDictionary<string, (int Count, DateTime LastAttempt)> _attempts = new();

        public async Task WaitIfNeededAsync(string email)
        {
            if (string.IsNullOrWhiteSpace(email)) return;
            var key = email.ToLowerInvariant();
            if (_attempts.TryGetValue(key, out var entry) && entry.Count >= 3)
            {
                await Task.Delay(1500);
            }
        }

        public void AddFailedAttempt(string email)
        {
            if (string.IsNullOrWhiteSpace(email)) return;
            var key = email.ToLowerInvariant();
            _attempts.AddOrUpdate(key,
                _ => (1, DateTime.Now),
                (_, entry) => DateTime.Now.Subtract(entry.LastAttempt).TotalMinutes > 10
                    ? (1, DateTime.Now)
                    : (entry.Count + 1, DateTime.Now));
        }

        public void ClearAttempts(string email)
        {
            if (string.IsNullOrWhiteSpace(email)) return;
            _attempts.TryRemove(email.ToLowerInvariant(), out _);
        }
    }
}
