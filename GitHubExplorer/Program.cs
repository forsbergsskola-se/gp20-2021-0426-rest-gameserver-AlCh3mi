using System;

namespace GitHubExplorer
{
    class Program
    {
        //GitHub Personal Access Token
        //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
        
        //Apex Legends API Token
        //X8MmHiCTDGB3tCgZe0iv
        
        static void Main(string[] args) {
             //Map Rotation
             var mapRotationResponse = ApiInteraction.Request("https://api.mozambiquehe.re/maprotation?auth=X8MmHiCTDGB3tCgZe0iv");
             var currentMapInfo = new MapInfo(mapRotationResponse);
             Console.WriteLine(currentMapInfo.ToString());
            
            Console.Write("Which player would you like info about? ");
            var userReply = Console.ReadLine();
            if (string.IsNullOrEmpty(userReply)) userReply = "ArCh4oS";
            
            var playerStatsRequest = ApiInteraction.Request($"https://api.mozambiquehe.re/bridge?platform=PC&player={userReply}&auth=X8MmHiCTDGB3tCgZe0iv");
            var currentPlayer = new PlayerInfo(playerStatsRequest);
            currentPlayer.ConsoleInteraction();
            
            
            //ApexPlayerInfo.ConsoleInteraction(playerStatsRequest);

        }
    }
}
