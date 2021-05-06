using System;

namespace GitHubExplorer {
    public class MapInfo {

        //https://api.mozambiquehe.re/maprotation?auth=X8MmHiCTDGB3tCgZe0iv
        
        public string Name { get; private set; }
        public TimeSpan RemainingTime { get; private set; }
        
        const string Current = "\"current\": {";
        const string Next = "\"next\": {";

        public MapInfo(string serverMapRotationInfo) {
            ExtractCurrentMapInfo(serverMapRotationInfo);
        }

        void ExtractCurrentMapInfo(string info) {

            if (string.IsNullOrEmpty(info)) return;
            
            var currentInfo = GetCurrentInfo(info);
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