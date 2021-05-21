using System;
using System.Linq;

namespace TinyBrowser {
    class Program {
        static void Main(string[] args) {
            
             var lastRequest = string.Empty;
            
             try {
                 Console.Write("Enter website: ");
                 var host = Console.ReadLine();
                 Console.Write("Enter path   :");
                 var userInput = Console.ReadLine();
            
                 var tinyBrowser = new TinyBrowser(host, 80);
                 var request = TinyBrowser.BuildHtmlRequest(userInput, host);
                 lastRequest = request;
                 tinyBrowser.SendRequest(request);
            
                 do {
                     //Display Webpage
                     var response = tinyBrowser.GetHostResponse();
                     Console.WriteLine(response);
            
                     //Display Hyperlink Options
                     //Display the Title of the page
                     Console.WriteLine(tinyBrowser.GetTitle(response) + "\n");
            
                     //Display all hyperlinks found
                     var links = tinyBrowser.GenerateLinks(response).ToList();
                     var count = 0;
                     foreach (var link in links) {
                         Console.WriteLine($"{++count}: {link.Title} - {link.Url}");
                     }
            
                     Console.Write("Which link would you like to follow?: ");
                     userInput = Console.ReadLine();
                     if (userInput == "b") {
                         tinyBrowser.SendRequest(lastRequest);
                     }
                     else {
                         request = TinyBrowser.BuildHtmlRequest("/" + links[int.Parse(userInput) - 1].Url, host);
                         lastRequest = request;
                         tinyBrowser.SendRequest(request);
                     }
                 } while (true);
             }
             catch (Exception e) {
                 Console.WriteLine(e.Message);
             }
        }
    }
}