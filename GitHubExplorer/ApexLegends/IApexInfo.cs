namespace GitHubExplorer.ApexLegends {
    interface IApexInfo {
        public string Name { get; }

        public void Initialize(string serverResponse);
        public string ToString();
    }
}