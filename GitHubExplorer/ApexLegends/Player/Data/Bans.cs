using Newtonsoft.Json;

namespace GitHubExplorer.ApexLegends.Player.Data {
    public class Bans {
        [JsonProperty("isActive")] public bool IsActive { get; private set; }
        [JsonProperty("remainingSeconds")] public int RemainingSeconds { get; private set; }
        [JsonProperty("last_banReason")] public string LastBanReason { get; private set; }
    }
}