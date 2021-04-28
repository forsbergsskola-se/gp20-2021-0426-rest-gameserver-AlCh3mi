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
                        userInput = "GET /\r/n HTTP/1.0";

                    tinyBrowser.SendRequest(userInput);
                    var response = tinyBrowser.GetHostResponse();
                    Console.WriteLine(response);
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