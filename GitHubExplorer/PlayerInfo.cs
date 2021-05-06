namespace GitHubExplorer {
    public class PlayerInfo : IApexInfo{
        //Apex Player Request
        //https://api.mozambiquehe.re/bridge?platform=PC&player=DeadwoodZa&auth=X8MmHiCTDGB3tCgZe0iv

        public string Name { get; private set; }
        public string Uid { get; private set; }
        public string AvatarUrl { get; private set; }
        public string Level { get; private set; }
        public string NextLevelPercentTo { get; private set; }

        public Rank Rank { get; private set; }

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
            Rank = new Rank(serverResponse);
        }

        public override string ToString() {
            return $"{Name}(Level {Level}.{100 - int.Parse(NextLevelPercentTo)}) UID:[{Uid}]\n" +
                   $"{Rank}";

        }
    }
}