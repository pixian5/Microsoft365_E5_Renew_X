using Microsoft.Extensions.Logging;

namespace Microsoft365_E5_Renew_X.Infrastructure;

public sealed class RuntimeHistoryLoggerProvider(RuntimeHistoryService historyService) : ILoggerProvider
{
    public ILogger CreateLogger(string categoryName) => new RuntimeHistoryLogger(categoryName, historyService);

    public void Dispose()
    {
    }

    private sealed class RuntimeHistoryLogger(string categoryName, RuntimeHistoryService historyService) : ILogger
    {
        public IDisposable? BeginScope<TState>(TState state) where TState : notnull => null;

        public bool IsEnabled(LogLevel logLevel) => logLevel != LogLevel.None;

        public void Log<TState>(
            LogLevel logLevel,
            EventId eventId,
            TState state,
            Exception? exception,
            Func<TState, Exception?, string> formatter)
        {
            if (!IsEnabled(logLevel))
            {
                return;
            }

            string message = formatter(state, exception);
            if (string.IsNullOrWhiteSpace(message) && exception is null)
            {
                return;
            }

            historyService.Add(categoryName, logLevel.ToString(), message, exception);
        }
    }
}
