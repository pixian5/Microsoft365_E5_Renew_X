using System.Reflection;
using Microsoft365_E5_Renew_X.Configuration;

namespace Microsoft365_E5_Renew_X;

public static class SystemConfig
{
    public static class Static
    {
        public static class Serivce
        {
            public static class ICP
            {
                public static string Text { get; set; } = "";

                public static string Link { get; set; } = "";
            }

            public static class CDN
            {
                public static string CSS { get; set; } = "";

                public static string JS { get; set; } = "";
            }

            public static string Port { get; set; } = "51066";

            public static string LoginPassword { get; set; } = "";

            public static bool CoreMultiThread { get; set; } = true;
        }

        public static class HTTPS
        {
            public static bool Enable { get; set; }

            public static string Certificate { get; set; } = "";

            public static string Password { get; set; } = "";
        }

        public static class ShareSite
        {
            public static bool Enable { get; set; }

            public static class SMTP
            {
                public static string Email { get; set; } = "";

                public static string Password { get; set; } = "";

                public static string Host { get; set; } = "";

                public static int Port { get; set; } = 587;

                public static bool EnableSSL { get; set; } = true;
            }

            public static class OAuth
            {
                public static class Microsoft
                {
                    public static bool Enable { get; set; }

                    public static string ClientId { get; set; } = "";

                    public static string ClientSecret { get; set; } = "";
                }

                public static class Github
                {
                    public static bool Enable { get; set; }

                    public static string ClientId { get; set; } = "";

                    public static string ClientSecret { get; set; } = "";
                }
            }

            public static class System
            {
                public static bool AllowRegister { get; set; }

                public static string Notice { get; set; } = "";

                public static string Master { get; set; } = "";

                public static string MasterLink { get; set; } = "";

                public static int DefaultQuota { get; set; } = 1;

                public static int AutoSpecialPardonInterval { get; set; } = 30;
            }
        }

        public static class Program
        {
            public static Version Version { get; set; } = new(10, 0, 0);

            public static DateTime CompileTime { get; set; } = DateTime.UtcNow;

            public static string Copyright { get; set; } = "";
        }
    }

    public static class Dynamic
    {
        public static int LoginRequest { get; set; }
        public static int LoginSuccess { get; set; }
        public static int LoginFail { get; set; }
        public static int NoLoginRequest { get; set; }
        public static int NoLoginSuccess { get; set; }
        public static int NoLoginFail { get; set; }
        public static int TodayRequest { get; set; }
        public static int TodaySuccess { get; set; }
        public static int TodayFail { get; set; }
        public static int LastLoginRequest { get; set; }
        public static int LastLoginSuccess { get; set; }
        public static int LastLoginFail { get; set; }
        public static int LastNoLoginRequest { get; set; }
        public static int LastNoLoginSuccess { get; set; }
        public static int LastNoLoginFail { get; set; }
        public static int LastRequest { get; set; }
        public static int LastSuccess { get; set; }
        public static int LastFail { get; set; }
        public static TimeSpan DataSyncTime { get; set; } = TimeSpan.Zero;
        public static TimeSpan APIRequestTime { get; set; } = TimeSpan.Zero;
        public static TimeSpan IdleTime { get; set; } = TimeSpan.Zero;
        public static TimeSpan LastDataSyncTime { get; set; } = TimeSpan.Zero;
        public static TimeSpan LastAPIRequestTime { get; set; } = TimeSpan.Zero;
        public static TimeSpan LastIdleTime { get; set; } = TimeSpan.Zero;
        public static double SystemLoad { get; set; }
        public static double LastSystemLoad { get; set; }
        public static double PerAPITime { get; set; }
        public static double LastPerAPITime { get; set; }
        public static APIAnalyse APIAnalyse { get; set; } = new();
        public static List<APIAnalyse.APIAnalyseBase> LastAPIAnalyseList { get; set; } = new();
        public static DateTime StartTime { get; set; } = DateTime.Now;
        public static bool SpecialPardon { get; set; }
        public static DateTime LastSpecialPardonTime { get; set; } = DateTime.MinValue;
    }

    public static void Initialize(AppOptions options, string contentRoot)
    {
        var legacy = options.LegacySite;

        Static.Serivce.Port = legacy.Service.Port.ToString();
        Static.Serivce.LoginPassword = legacy.Service.LoginPassword;
        Static.Serivce.CoreMultiThread = legacy.Service.CoreMultiThread;
        Static.Serivce.ICP.Text = legacy.Service.ICP.Text;
        Static.Serivce.ICP.Link = legacy.Service.ICP.Link;
        Static.Serivce.CDN.CSS = legacy.Service.CDN.CSS;
        Static.Serivce.CDN.JS = legacy.Service.CDN.JS;

        Static.HTTPS.Enable = legacy.Https.Enable;
        Static.HTTPS.Certificate = legacy.Https.Certificate;
        Static.HTTPS.Password = legacy.Https.Password;

        Static.ShareSite.Enable = legacy.ShareSite.Enable;
        Static.ShareSite.SMTP.Email = legacy.ShareSite.SMTP.Email;
        Static.ShareSite.SMTP.Password = legacy.ShareSite.SMTP.Password;
        Static.ShareSite.SMTP.Host = legacy.ShareSite.SMTP.Host;
        Static.ShareSite.SMTP.Port = legacy.ShareSite.SMTP.Port;
        Static.ShareSite.SMTP.EnableSSL = legacy.ShareSite.SMTP.EnableSSL;
        Static.ShareSite.OAuth.Microsoft.Enable = legacy.ShareSite.OAuth.Microsoft.Enable;
        Static.ShareSite.OAuth.Microsoft.ClientId = legacy.ShareSite.OAuth.Microsoft.ClientId;
        Static.ShareSite.OAuth.Microsoft.ClientSecret = legacy.ShareSite.OAuth.Microsoft.ClientSecret;
        Static.ShareSite.OAuth.Github.Enable = legacy.ShareSite.OAuth.Github.Enable;
        Static.ShareSite.OAuth.Github.ClientId = legacy.ShareSite.OAuth.Github.ClientId;
        Static.ShareSite.OAuth.Github.ClientSecret = legacy.ShareSite.OAuth.Github.ClientSecret;
        Static.ShareSite.System.AllowRegister = legacy.ShareSite.System.AllowRegister;
        Static.ShareSite.System.Notice = legacy.ShareSite.System.Notice;
        Static.ShareSite.System.Master = legacy.ShareSite.System.Master;
        Static.ShareSite.System.MasterLink = legacy.ShareSite.System.MasterLink;
        Static.ShareSite.System.DefaultQuota = legacy.ShareSite.System.DefaultQuota;
        Static.ShareSite.System.AutoSpecialPardonInterval = legacy.ShareSite.System.AutoSpecialPardonInterval;

        var assembly = Assembly.GetExecutingAssembly();
        Static.Program.Version = assembly.GetName().Version ?? new Version(10, 0, 0);
        Static.Program.CompileTime = File.Exists(assembly.Location)
            ? File.GetLastWriteTime(assembly.Location)
            : DateTime.Now;
        Static.Program.Copyright = "Microsoft365_E5_Renew_X .NET 10";
        Dynamic.StartTime = DateTime.Now;
    }
}
