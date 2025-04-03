namespace SpeedTestSharp
{
    public class Constants
    {
        public const string ServersUrl = "http://www.speedtest.net/speedtest-servers.php";
        public const string Chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
        public const int MaxUploadSize = 6;
        public static readonly int[] DownloadSizes = { 1500, 2000, 3000, 3500, 4000 };

        // The default timeout for HttpClient is 100 seconds.
        // ref: https://learn.microsoft.com/en-us/dotnet/api/system.net.http.httpclient.timeout?view=net-9.0
        public const int DefaultHttpTimeoutMilliseconds = 100000;
    }
}