using System;

namespace GitHubExplorer {
    public class PlayerInfo {
        
        //Apex Player Request
        //https://api.mozambiquehe.re/bridge?platform=PC&player=DeadwoodZa&auth=X8MmHiCTDGB3tCgZe0iv
        
        public string Name { get; private set; }
        public string Uid { get; private set; }
        public string AvatarUrl { get; private set; }
        public string Level{ get; private set; }
        public string NextLevelPercentTo{ get; private set; }
        
        public string RankScore{ get; private set; }
        public string RankName{ get; private set; }
        public string RankDivision{ get; private set; }
        public string RankImageUrl{ get; private set; }
        public string RankedSeason{ get; private set; }

        public PlayerInfo(string serverResponse) {
            SetupPlayerFromResponse(serverResponse);
            SetupRankFromResponse(serverResponse);
        }

        void SetupPlayerFromResponse(string serverResponse) {
            var subSection = ApiInteraction.SubSection("global\": {", serverResponse, "},");
            Name = ApiInteraction.FindInResponse("name", subSection);
            Uid = ApiInteraction.FindInResponse("uid", subSection);
            AvatarUrl = ApiInteraction.FindInResponse("avatar", subSection);
            Level = ApiInteraction.FindInResponse("level", subSection);
            NextLevelPercentTo = ApiInteraction.FindInResponse("toNextLevelPercent", subSection);
        }

        void SetupRankFromResponse(string serverResponse) {
            var subSection = ApiInteraction.SubSection("rank\": {", serverResponse, "},");
            RankScore = ApiInteraction.FindInResponse("rankScore", subSection);
            RankName = ApiInteraction.FindInResponse("rankName", subSection);
            RankDivision = ApiInteraction.FindInResponse("rankDiv", subSection);
            RankImageUrl = ApiInteraction.FindInResponse("rankImg", subSection);
            RankedSeason = ApiInteraction.FindInResponse("rankedSeason", subSection);
        }

        public void ConsoleInteraction() {
            var quit = false;
            Console.WriteLine("1. Name");
            Console.WriteLine("2. UId");
            Console.WriteLine("3. Avatar URL");
            Console.WriteLine("4. Level");
            Console.WriteLine("5. % to Next Level");
            Console.WriteLine("6. Rank");
            Console.WriteLine("7. RankDivision");
            Console.WriteLine("8. RankScore");
            Console.WriteLine("9. RankSeason");
            Console.WriteLine("0. Quit\n");
            
            do {
                Console.Write("what property would you like to view: ");
                var userReply = Console.ReadLine();
                Console.WriteLine();
                
                if (!int.TryParse(userReply, out var reply)) continue;
                
                string header;
                switch (reply) {
                    case 1:
                        header = Name;
                        break;
                    case 2:
                        header = Uid;
                        break;
                    case 3:
                        header = AvatarUrl;
                        break;
                    case 4:
                        header = Level;
                        break;
                    case 5:
                        header = NextLevelPercentTo;
                        break;
                    case 6:
                        header = RankName;
                        break;
                    case 7:
                        header = RankDivision;
                        break;
                    case 8:
                        header = RankScore;
                        break;
                    case 9:
                        header = RankedSeason;
                        break;
                    default:
                        quit = true;
                        continue;
                }

                Console.WriteLine(header);
            } while (!quit);
        }
    }
}