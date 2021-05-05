using System;
using System.Collections.Generic;

namespace GitHubExplorer {
    public class ApexMapInfo {

        public string Name { get; private set; }
        public TimeSpan RemainingTime { get; private set; }

        Dictionary<string, string> currentMapInfo = new();

        public void InterpretFromApiResponse(string response) {
            ExtractCurrentMapInfo(response);
            
        }

        void ExtractCurrentMapInfo(string info) {

            const string current = "\"current\": {";
            const string next = "\"next\": {";
            
            if (string.IsNullOrEmpty(info)) return;
            
            var currentStartsAt = info.IndexOf(current, StringComparison.Ordinal);
            var nextStartsAt = info.IndexOf(next, StringComparison.Ordinal);

            var currentInfo = info.Substring(currentStartsAt, nextStartsAt - currentStartsAt);
            
            Name = FindInResponse("map", currentInfo);
            var remainingMins = int.Parse(FindInResponse("remainingMins", currentInfo));
            RemainingTime = TimeSpan.FromMinutes(remainingMins);
        }

        string FindInResponse(string header, string toSearch) {

            if (!toSearch.Contains(header)) return null;

            var indexOf = toSearch.IndexOf(header, StringComparison.Ordinal);
            var response = string.Empty;
            for (int i = indexOf + header.Length + 2; i < toSearch.Length; i++) {
                if (toSearch[i] == ',') break;
                
                response += toSearch[i];
            }

            response = response.Trim();
            return response.Trim('\"');
        }
    }
}