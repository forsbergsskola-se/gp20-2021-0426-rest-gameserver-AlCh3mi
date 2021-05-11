using Newtonsoft.Json;

namespace GitHubExplorer.ApexLegends.Player.Attributes {
    public class Stats {
        [JsonProperty("global")]public Global Global { get; private set; }
        [JsonProperty("realtime")] public RealTime RealTime { get; private set; }
        
        
    }
}