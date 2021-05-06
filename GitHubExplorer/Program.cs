using System;
using GitHubExplorer.ApexLegends;
using GitHubExplorer.ApexLegends.Map;
using GitHubExplorer.ApexLegends.Player;

namespace GitHubExplorer {
    class Program {
        
        static void Main(string[] args) {

            var apiInteraction = new ApiInteraction();

            //Map Rotation
            var mapRotationResponse = ApiInteraction.Request($"https://api.mozambiquehe.re/maprotation?auth={apiInteraction.Config.Auth}");
            var currentMapInfo = new MapInfo(mapRotationResponse);
            Console.WriteLine(currentMapInfo.ToString());

            Console.Write("Which player would you like info about? ");
            var userReply = Console.ReadLine();
            if (string.IsNullOrEmpty(userReply)) userReply = "ArCh4oS";

            var playerStatsRequest = ApiInteraction.Request($"https://api.mozambiquehe.re/bridge?platform=PC&player={userReply}&auth={apiInteraction.Config.Auth}");
            var currentPlayer = new PlayerInfo(playerStatsRequest);
            Console.WriteLine(currentPlayer);
        }
    }
}