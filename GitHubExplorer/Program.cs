using System;
using System.Threading;
using GitHubExplorer.ApexLegends;
using GitHubExplorer.ApexLegends.Map;
using GitHubExplorer.ApexLegends.Player;

namespace GitHubExplorer {
    class Program {
        static void Main(string[] args) {
            
            var apiInteraction = new ApiInteraction();

            Console.WriteLine(1.1 );
            var mapResponse = ApiInteraction.Request($"https://api.mozambiquehe.re/maprotation?version=2&auth={apiInteraction.Config.Auth}");
            var mapInfo = new MapInfo(mapResponse);
            mapInfo.NavigateWithConsole();
            
            //Console.WriteLine(mapInfo.ToString());
            
            Console.Write("Which player would you like info about? ");
            var userReply = Console.ReadLine();
            if (string.IsNullOrEmpty(userReply)) userReply = "ArCh4oS";

            var playerStatsRequest = ApiInteraction.Request($"https://api.mozambiquehe.re/bridge?platform=PC&player={userReply}&auth={apiInteraction.Config.Auth}");
            var currentPlayer = new Info(playerStatsRequest);

            Console.WriteLine(currentPlayer.Stats.Global);
            Console.ReadKey();
        }
    }
}