using System;

namespace TinyBrowser {
    class Program {
        static void Main(string[] args) {
            
            var tinyBrowser = new TinyBrowser("www.acme.com", 80);

            var userInput = string.Empty;
            try {
                while (true) {
                    Console.Write("Enter Request: ");
                    userInput = Console.ReadLine();

                    if (userInput?.ToUpper() == "EXIT")
                        break;

                    if (userInput == string.Empty)
                        userInput = "GET / HTTP/1.1\r\nHost: acme.com\r\n\r\n";

                    tinyBrowser.SendRequest(userInput);
                    var response = tinyBrowser.GetHostResponse();
                    Console.WriteLine(response);
                    
                    //var title = tinyBrowser.Get("<title>", "</title>", response);

                    //Console.WriteLine(title[0]);
                    
                    var links = tinyBrowser.FindOccurrences("<a href=\"", "</a>", response);

                    foreach (var link in links) {
                        Console.WriteLine(link);
                    }
                }
            }
            catch (Exception e) {
                Console.WriteLine(e.Message);
            }
            finally {
                tinyBrowser.Disconnect();    
            }
            
            
        }
        
        
    }
}