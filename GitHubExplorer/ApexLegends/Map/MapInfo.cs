using System;

namespace GitHubExplorer.ApexLegends.Map {
    public class MapInfo : IApexInfo {

        //https://api.mozambiquehe.re/maprotation?auth=?????
        
        public string Name { get; private set; }
        TimeSpan RemainingTime { get; set; }
        
        const string Current = "\"current\": {";
        const string Next = "\"next\": {";

        public MapInfo(string serverMapRotationInfo) {
            Initialize(serverMapRotationInfo);
        }

        public void Initialize(string serverResponse) {

            if (string.IsNullOrEmpty(serverResponse)) return;
            
            var currentInfo = GetCurrentInfo(serverResponse);
            Name = ApiInteraction.FindInResponse("map", currentInfo);
            var remainingMins = int.Parse(ApiInteraction.FindInResponse("remainingMins", currentInfo));
            RemainingTime = TimeSpan.FromMinutes(remainingMins);
        }

        static string GetCurrentInfo(string info) {
            var currentStartsAt = info.IndexOf(Current, StringComparison.Ordinal);
            var nextStartsAt = info.IndexOf(Next, StringComparison.Ordinal);
            var currentInfo = info.Substring(currentStartsAt, nextStartsAt - currentStartsAt);
            return currentInfo;
        }

        public override string ToString()
            => $"{Name} for {RemainingTime.Days}d, {RemainingTime.Hours}h:{RemainingTime.Minutes}m.";
    
    }
}