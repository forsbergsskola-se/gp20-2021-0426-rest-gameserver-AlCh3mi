using GitHubExplorer.ApexLegends.Player.Data;
using Newtonsoft.Json;

namespace GitHubExplorer.ApexLegends.Player {
    public class Info {
        public readonly Stats Stats;
        public Info(string serverResponse) {
            Stats = JsonConvert.DeserializeObject<Stats>(serverResponse);
        }
        
    }
}