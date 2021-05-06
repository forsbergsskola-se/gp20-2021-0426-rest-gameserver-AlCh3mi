namespace GitHubExplorer.ApexLegends.Player {
    public class PlayerInfo : IApexInfo{
        //Apex Player Request
        //https://api.mozambiquehe.re/bridge?platform=PC&player=DeadwoodZa&auth=??????
        public string Name { get; private set; }
        public string Uid { get; private set; }
        public string AvatarUrl { get; private set; }
        public string Level { get; private set; }
        public string NextLevelPercentTo { get; private set; }

        public RankInfo RankInfo { get; private set; }

        public PlayerInfo(string serverResponse) {
            Initialize(serverResponse);
        }

        public void Initialize(string serverResponse) {
            var subSection = ApiInteraction.SubSection("global\": {", serverResponse);
            Name = ApiInteraction.FindInResponse("name", subSection);
            Uid = ApiInteraction.FindInResponse("uid", subSection);
            AvatarUrl = ApiInteraction.FindInResponse("avatar", subSection);
            Level = ApiInteraction.FindInResponse("level", subSection);
            NextLevelPercentTo = ApiInteraction.FindInResponse("toNextLevelPercent", subSection);
            RankInfo = new RankInfo(serverResponse);
        }

        public override string ToString() {
            return $"{Name}(Level {Level}.{100 - int.Parse(NextLevelPercentTo)}) UID:[{Uid}]\n" +
                   $"{RankInfo}";
        
        }
    }
}