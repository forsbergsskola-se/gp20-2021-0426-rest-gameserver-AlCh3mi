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
            var apexApi = new ApexLegendsApiInteraction();
            var response = apexApi.Request("https://api.mozambiquehe.re/maprotation?auth=X8MmHiCTDGB3tCgZe0iv");
            Console.Write(response.Result);

            ApexMapInfo ami = new ApexMapInfo();
            ami.InterpretFromApiResponse(response.Result);
            Console.WriteLine($"Current Map Name: {ami.Name} for the next {ami.RemainingTime} Minutes.");
            Console.ReadKey();
            
            
        }
    }
}
