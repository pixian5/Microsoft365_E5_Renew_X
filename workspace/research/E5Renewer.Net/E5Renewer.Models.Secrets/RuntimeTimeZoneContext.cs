namespace E5Renewer.Models.Secrets;

public static class RuntimeTimeZoneContext
{
    private static TimeZoneInfo current = TimeZoneInfo.Local;

    public static TimeZoneInfo Current => current;

    public static void Set(TimeZoneInfo timeZone)
    {
        current = timeZone ?? TimeZoneInfo.Local;
    }

    public static DateTime GetNow()
    {
        return TimeZoneInfo.ConvertTime(DateTimeOffset.UtcNow, Current).DateTime;
    }
}
