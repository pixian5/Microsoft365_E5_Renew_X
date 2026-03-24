namespace E5Renewer.Models.Statistics;

/// <summary>
/// The api interface to manage user status.
/// </summary>
public interface IStatusManager
{
    /// <summary>Get all running users' names.</summary>
    public Task<IEnumerable<string>> GetRunningUsersAsync();

    /// <summary>Get all waiting users' names.</summary>
    public Task<IEnumerable<string>> GetWaitingUsersAsync();

    /// <summary>Get all stopped users' names.</summary>
    public Task<IEnumerable<string>> GetStoppedUsersAsync();

    /// <summary>Check whether the user is stopped.</summary>
    public Task<bool> IsUserStoppedAsync(string name);

    /// <summary>Set user status by user name.</summary>
    public Task SetUserStatusAsync(string name, bool running);

    /// <summary>Set user stopped state.</summary>
    public Task SetUserStoppedAsync(string name, bool stopped);

    /// <summary>Get all results by user name and api id.</summary>
    public Task<IEnumerable<string>> GetResultsAsync(string name, string id);

    /// <summary>Get summarized success and failure count by user name.</summary>
    public Task<(int SuccessCount, int FailureCount)> GetUserResultSummaryAsync(string name);

    /// <summary>Update result by user name, api id and result string.</summary>
    public Task SetResultAsync(string name, string id, string result);
}
