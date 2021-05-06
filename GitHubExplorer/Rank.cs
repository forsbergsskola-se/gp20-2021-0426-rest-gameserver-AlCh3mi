namespace GitHubExplorer {
    public class Rank : IApexInfo{
        public string Score { get; private set; }
        public string Name { get; private set; }
        public string Division { get; private set; }
        public string ImageUrl { get; private set; }
        public string Season { get; private set; }

        public Rank(string serverResponse) {
            Initialize(serverResponse);
        }

        public void Initialize(string serverResponse) {
            var subSection = ApiInteraction.SubSection("rank\": {", serverResponse);
            Score = ApiInteraction.FindInResponse("rankScore", subSection);
            Name = ApiInteraction.FindInResponse("rankName", subSection);
            Division = ApiInteraction.FindInResponse("rankDiv", subSection);
            ImageUrl = ApiInteraction.FindInResponse("rankImg", subSection);
            Season = ApiInteraction.FindInResponse("rankedSeason", subSection);
        }

        public override string ToString() {
            return $"{Name} Rank {Division} ({Score})";
        }
    }
}