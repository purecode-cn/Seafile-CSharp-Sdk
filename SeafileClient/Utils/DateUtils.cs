using System;
namespace SeafileClient.Utils
{
    public static class DateUtils
    {
        private static readonly DateTime _unixEpoch = new DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc);

        public static DateTime TimestampToDateTime(long time)
        {
            return _unixEpoch.AddSeconds(time).ToLocalTime();
        }

        public static long DateTimeToTimestamp(DateTime time)
        {
            return (long)time.ToUniversalTime().Subtract(_unixEpoch).TotalSeconds;
        }
    }
}
