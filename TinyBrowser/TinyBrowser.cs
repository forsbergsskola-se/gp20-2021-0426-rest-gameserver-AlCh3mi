using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Sockets;
using System.Text;

namespace TinyBrowser {
    class TinyBrowser {
        
        readonly TcpClient tcpClient;
        
        public TinyBrowser(string hostname, int port) {
            tcpClient = new TcpClient(hostname, port);
            if (tcpClient.Connected) {
                Console.WriteLine($"Connected to {hostname}");
            }
        }

        public void SendRequest(string message) {
            var networkStream = tcpClient.GetStream();
            var asBytes = Encoding.ASCII.GetBytes(message);
            networkStream.Write(asBytes, 0,asBytes.Length);
        }

        public string GetHostResponse() {
            var networkStream = tcpClient.GetStream();
            using var reader = new StreamReader(networkStream, Encoding.ASCII);
            var bytes = Encoding.ASCII.GetBytes(reader.ReadToEnd());
            return Encoding.ASCII.GetString(bytes);
        }

        public void Disconnect() {
            tcpClient.Close();
            tcpClient.Dispose();
            Console.WriteLine("Connection closed.");
        }

        public List<Link> GenerateLinks(List<string> value) {
            return value.Select(BuildLink).ToList();
        }

        public List<string> FindOccurrences(string startsWith, string endsWith, string value) {

            List<string> occurrences = new();
            
            var recording = string.Empty;
            
            for (int i = 0; i < value.Length; i++) {                                                                    //iterates over every character of the html string
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
        
        string InBetween(string startsWith, string endsWith, string value) {
            if (value.Contains(startsWith) && value.Contains(endsWith)) {
                var beginsAtPos = value.IndexOf(startsWith)  + startsWith.Length;
                var length = value.IndexOf(endsWith) - beginsAtPos;
                return value.Substring(beginsAtPos, length).Replace("<b>", "").Replace("</b>", "");
            }
            return null;
        }

        Link BuildLink(string value) {
            Link link;
            link.Url = InBetween("href=\"", "\">", value);
            link.Title = InBetween("\">", "</a>", value);
            return link;
        }
    }

    public struct Link {
        public string Title;
        public string Url;
    }
}