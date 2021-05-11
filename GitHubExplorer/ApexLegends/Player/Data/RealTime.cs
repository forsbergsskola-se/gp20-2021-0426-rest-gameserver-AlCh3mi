﻿using Newtonsoft.Json;

namespace GitHubExplorer.ApexLegends.Player.Data {
    public class RealTime {
        [JsonProperty("lobbyState")] public string LobbyState { get; private set; }
        [JsonProperty("isOnline")] public int IsOnline { get; private set; }
        [JsonProperty("isInGame")] public int IsInGame { get; private set; }
        [JsonProperty("canJoin")] public int CanJoin { get; private set; }
        [JsonProperty("partyFull")] public int PartyFull { get; private set; }
        [JsonProperty("selectedLegend")] public string SelectedLegend { get; private set; }
    }
}