using SuchByte.MacroDeck.Logging;
using SuchByte.MacroDeck.Variables;
using System;
using System.Net.Http;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Timers;

namespace SuchByte.PiHolePlugin;

public static class PiHoleHelper
{
    private static string _host = string.Empty;
    private static string _token = string.Empty;

    private static bool _lastUpdateFinished = true;

    private static PiHoleApiClient.PiHoleApiClient? PiHoleApiClient { get; set; }

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

    private static void VariableUpdateTimer_Elapsed(object? sender, ElapsedEventArgs e)
    {
        UpdateVariables();
    }

    private static void UpdateVariables()
    {
        if (!_lastUpdateFinished || PiHoleApiClient == null)
        {
            return;
        }
        
        _lastUpdateFinished = false;
        Task.Run(async () =>
        {
            try
            {
                var summary = await PiHoleApiClient.GetSummaryAsync();
                if (summary == null)
                {
                    return;
                }
                
                var status = summary.Status;
                VariableManager.SetValue("pi_hole_enabled",
                    status.Equals("enabled", StringComparison.OrdinalIgnoreCase), VariableType.Bool, Main.Instance,
                    null);

                if (TrySanitizeAndParseIntValue(summary.DnsQueriesAllTypes, out var totalQueries))
                {
                    VariableManager.SetValue("pi_hole_total_queries", totalQueries, VariableType.Integer, Main.Instance,
                        null);
                }
                
                if (TrySanitizeAndParseIntValue(summary.DomainsBeingBlocked, out var domainsAdlists))
                {
                    VariableManager.SetValue("pi_hole_domains_adlists", domainsAdlists, VariableType.Integer,
                        Main.Instance, null);
                }
                
                if (TrySanitizeAndParseIntValue(summary.AdsBlockedToday, out var queriesBlocked))
                {
                    VariableManager.SetValue("pi_hole_queries_blocked", queriesBlocked, VariableType.Integer,
                        Main.Instance, null);
                }
                
                if (TrySanitizeAndParseIntValue(summary.AdsPercentageToday, out var percentageBlocked))
                {
                    VariableManager.SetValue("pi_hole_percentage_blocked", percentageBlocked, VariableType.Float,
                        Main.Instance, null);
                }
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

        var httpClient = new HttpClient();
        PiHoleApiClient = new PiHoleApiClient.PiHoleApiClient(httpClient, $"{_host}/admin/api.php", _token);

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
        Task.Run(async () =>
        {
            try
            {
                await PiHoleApiClient.Disable(seconds);
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
        Task.Run(async () =>
        {
            try
            {
                await PiHoleApiClient.Enable();
                UpdateVariables();
            }
            catch
            {
                MacroDeckLogger.Error(Main.Instance, "Failed to enable. Perhaps the host or the token is wrong?");
            }
        });
    }
    
    private static bool TrySanitizeAndParseIntValue(string? value, out int result)
    {
        result = 0;
        if (string.IsNullOrWhiteSpace(value))
        {
            return false;
        }

        var valueSanitized = Regex.Replace(value, "[^0-9]", "");
        return int.TryParse(valueSanitized, out result);
    }
}