using System;
using System.Text;

namespace TinyBrowser {
    class Program {
        static void Main(string[] args) {
            try {
                Console.WriteLine("Enter website: ");
                var host = Console.ReadLine();
                var tinyBrowser = new TinyBrowser(host, 80);
                
                var userInput = "/";

                // if (userInput == string.Empty)
                //     userInput = "GET / HTTP/1.1\r\nHost: acme.com\r\n\r\n";

                var request = BuildHtmlRequest(userInput, host);
                tinyBrowser.SendRequest(request);
                
                //Display Webpage
                var response = tinyBrowser.GetHostResponse();
                Console.WriteLine(response);

                //Display Hyperlink Options
                //Display the Title of the page
                var title = tinyBrowser.FindOccurrences("<title>", "</title>", response);
                Console.WriteLine(title[0].Replace("<title>", "").Replace("</title>", "") +"\n");

                //Display all hyperlinks found
                var linksAsStrings = tinyBrowser.FindOccurrences("<a href=\"", "</a>", response);
                var links = tinyBrowser.GenerateLinks(linksAsStrings);
                var count = 0;
                foreach (var link in links) {
                    Console.WriteLine($"{++count}: {link.Title} - {link.Url}");
                }
            }
            catch (Exception e) {
                Console.WriteLine(e.Message);
            }
        }

        static string BuildHtmlRequest(string path, string host) {
            
            const string version = "HTTP/1.1\r\n";
            
            var sb = new StringBuilder();
            sb.Append("GET ").Append($"{path} ").Append(version);
            sb.Append("Host: ").Append(host).Append("\r\n\r\n");
            return sb.ToString();
        }
    }
}