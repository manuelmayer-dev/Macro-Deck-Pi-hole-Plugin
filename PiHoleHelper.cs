using SuchByte.MacroDeck.Logging;
using SuchByte.MacroDeck.Variables;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Timers;

namespace SuchByte.PiHolePlugin
{



    public class PiHoleHelper
    {
        private static string _host;
        private static string _token;

        private static bool _lastUpdateFinished = true;

        private static HttpClient _httpClient = new HttpClient();
        
        public static PiHoleApiClient.PiHoleApiClient PiHoleApiClient { get; private set; }

        public static void Initialize(string host, string token)
        {
            Task.Run(() =>
            {
                var result = Connect(host, token).Result;
                if (result)
                {
                    UpdateVariables();
                }
            });

            Timer variableUpdateTimer = new Timer()
            {
                Enabled = true,
                Interval = 1000,
            };
            variableUpdateTimer.Elapsed += VariableUpdateTimer_Elapsed;
            variableUpdateTimer.Start();
        }

        private static void VariableUpdateTimer_Elapsed(object sender, ElapsedEventArgs e)
        {
            UpdateVariables();
        }

        private static void UpdateVariables()
        {
            if (!_lastUpdateFinished || PiHoleApiClient == null) return;
            Task.Run(() =>
            {
                _lastUpdateFinished = false;
                try
                {
                    var summary = PiHoleApiClient.GetSummaryAsync().Result;
                    if (summary == null) return;
                    var status = summary.Status;
                    var totalQueries = Int32.Parse(summary.DnsQueriesAllTypes.Replace(",", "").Replace(".", ""));
                    var domainsAdlists = Int32.Parse(summary.DomainsBeingBlocked.Replace(",", "").Replace(".", ""));
                    var queriesBlocked = Int32.Parse(summary.AdsBlockedToday.Replace(",", "").Replace(".", ""));
                    var percentageBlocked = float.Parse(summary.AdsPercentageToday.Replace(".", ","));

                    VariableManager.SetValue("pi_hole_enabled", status == "enabled", VariableType.Bool, Main.Instance);
                    VariableManager.SetValue("pi_hole_total_queries", totalQueries, VariableType.Integer, Main.Instance);
                    VariableManager.SetValue("pi_hole_domains_adlists", domainsAdlists, VariableType.Integer, Main.Instance);
                    VariableManager.SetValue("pi_hole_queries_blocked", queriesBlocked, VariableType.Integer, Main.Instance);
                    VariableManager.SetValue("pi_hole_percentage_blocked", percentageBlocked, VariableType.Float, Main.Instance);
                }
                catch (Exception ex)
                {
                    MacroDeckLogger.Trace(Main.Instance, $"Failed to update variables: {ex.Message}");
                }
                _lastUpdateFinished = true;
            });
        }

        public static async Task<bool> Connect(string host, string token)
        {
            _host = host;
            _token = token;
            MacroDeckLogger.Info(Main.Instance, $"Connecting to {_host}...");

            PiHoleApiClient = new PiHoleApiClient.PiHoleApiClient(_httpClient, $"{_host}/admin/api.php", _token);

            try
            {
                var version = await PiHoleApiClient.GetApiVersionAsync();
                MacroDeckLogger.Info(Main.Instance, $"Connected to {_host} api version {version.Version}");
                return true;
            } catch
            {
                MacroDeckLogger.Info(Main.Instance, $"Failed to connect to Pi-hole instance on {_host}");
                PiHoleApiClient = null;
            }

            return false;
        }

        public static void Disable(long seconds = 0)
        {
            if (PiHoleApiClient == null) return;
            Task.Run(() =>
            {
                try
                {
                    _ = PiHoleApiClient.Disable(seconds);
                    UpdateVariables();
                }
                catch
                {
                    MacroDeckLogger.Error(Main.Instance, "Failed to disable. Perhaps the host or the token is wrong?");
                }
            });
        }
        public static void Enable()
        {
            if (PiHoleApiClient == null) return;
            Task.Run(() =>
            {
                try
                {
                    _ = PiHoleApiClient.Enable();
                    UpdateVariables();
                }
                catch
                {
                    MacroDeckLogger.Error(Main.Instance, "Failed to enable. Perhaps the host or the token is wrong?");
                }
            });
        }


    }
}
