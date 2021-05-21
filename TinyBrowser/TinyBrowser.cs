using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Sockets;
using System.Text;

namespace TinyBrowser {
    class TinyBrowser {
        TcpClient TcpClient { get; set; }
        NetworkStream networkStream;

        string hostname;
        readonly int port;

        public TinyBrowser(string hostname, int port) {
            this.hostname = hostname;
            this.port = port;
        }

        public void SendRequest(string message) {
            Connect();
            Console.WriteLine($"REQUEST BEING SENT: {message}");
            var asBytes = Encoding.ASCII.GetBytes(message);
            networkStream.Write(asBytes, 0,asBytes.Length);
        }

        public string GetHostResponse() {
            Console.WriteLine("Listening for response: ");
            var reader = new StreamReader(networkStream, Encoding.ASCII);
            var bytes = Encoding.ASCII.GetBytes(reader.ReadToEnd());
            Disconnect();
            return Encoding.ASCII.GetString(bytes);
        }
        
        void Connect() {
            TcpClient = new TcpClient();
            TcpClient.Connect(hostname, port);
            networkStream = TcpClient.GetStream();
        }

        void Disconnect() {
            networkStream.Close();
            networkStream.Dispose();
            TcpClient.Close();
            TcpClient.Dispose();
            Console.WriteLine("Connection closed.");
        }
        
        public string GetTitle(string value) => InBetween("<title>", "</title>", value);

        public IEnumerable<Link> GenerateLinks(string response) {
            var linksAsString = FindOccurrences("<a href=\"", "</a>", response);
            return linksAsString.Select(BuildLink).ToList();
        }

        IEnumerable<string> FindOccurrences(string startsWith, string endsWith, string value) {

            List<string> occurrences = new();
            
            var recording = string.Empty;
            
            for (var i = 0; i < value.Length; i++) {                                                                    //iterates over every character of the html string
                if (i+startsWith.Length < value.Length && value[i] == startsWith[0]) {                                  //if the current character matches the starting character of startsWith
                    if (value.Substring(i, startsWith.Length) == startsWith) {                                  //if the following characters match the startsWith
                        for (var j = 0; ; j++) {                                                                        //start looping from the point we found the first character matching
                            if (value[i + j] == endsWith[0]) {                                                          //if we might have found the start of the endsWith string
                                if (value.Substring(i + j, endsWith.Length) == endsWith) {                      //if the following characters ARE the endsWith string
                                    recording += endsWith;
                                    break;
                                }                 
                            }
                            recording += value[i + j];
                        }
                        occurrences.Add(recording);
                        recording = string.Empty;
                    }
                }
            }
            return occurrences;
        }

        static string InBetween(string startsWith, string endsWith, string value) {
            if (value.Contains(startsWith) && value.Contains(endsWith)) {
                var beginsAtPos = value.IndexOf(startsWith)  + startsWith.Length;
                var length = value.IndexOf(endsWith) - beginsAtPos;
                return value.Substring(beginsAtPos, length).Replace("<b>", "").Replace("</b>", "");
            }
            return null;
        }

        static Link BuildLink(string value) {
            Link link;
            link.Url = InBetween("href=\"", "\">", value);
            link.Title = InBetween("\">", "</a>", value);
            return link;
        }
        
        //"GET / HTTP/1.1\r\nHost: acme.com\r\n\r\n";
        public static string BuildHtmlRequest(string path, string host) {
            
            const string version = "HTTP/1.1\r\n";

            var sb = new StringBuilder();
            sb.Append("GET ").Append($"{path} ").Append(version);
            sb.Append("Host: ").Append(host).Append("\r\n\r\n");
            return sb.ToString();
        }
    }
}