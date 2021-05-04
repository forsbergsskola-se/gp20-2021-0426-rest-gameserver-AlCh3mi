using System;
using System.IO;
using System.Net;
using System.Threading.Tasks;

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
            Console.ReadKey();
        }
    }

    public class ApexLegendsApiInteraction {
        
        //Player Info Request
        //https://api.mozambiquehe.re/bridge?platform=PC&player=DeadwoodZa&auth=X8MmHiCTDGB3tCgZe0iv
        
        //Current Map Info
        //https://api.mozambiquehe.re/maprotation?auth=X8MmHiCTDGB3tCgZe0iv
        
        
        public async Task<string> Request(string url)
        {
            ServicePointManager.ServerCertificateValidationCallback = 
                (a, b, c, d) => true;

            var req = (HttpWebRequest)WebRequest.Create(url);
            var resp = (HttpWebResponse) await req.GetResponseAsync();
            using var sr = new StreamReader(resp.GetResponseStream());
            var results = await sr.ReadToEndAsync();
            return results;
        }
    }
}
