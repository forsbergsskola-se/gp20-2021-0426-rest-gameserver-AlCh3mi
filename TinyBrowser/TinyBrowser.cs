using System;
using System.Collections.Generic;
using System.IO;
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

        public List<string> Get(string startsWith, string endsWith, string value) {

            List<string> occurrences = new();
            
            while (value.Contains(startsWith) && value.Contains(endsWith)) {
                var beginsAtPos = value.IndexOf(startsWith);
                var length = value.IndexOf(endsWith) + endsWith.Length - beginsAtPos;
                var subString = value.Substring(beginsAtPos, length);
                value = value.Replace(subString, "");
                subString = subString.Replace(startsWith, "").Replace(endsWith, "");
                occurrences.Add(subString);
                value = value.Remove(beginsAtPos, length);
            }

            return occurrences;
        }

        public List<string> FindOccurrences(string startsWith, string endsWith, string value) {

            List<string> occurrences = new();
            
            var recording = string.Empty;
            
            for (int i = 0; i < value.Length; i++) {
                if (i+startsWith.Length < value.Length && value[i] == startsWith[0]) {
                    if (value.Substring(i, startsWith.Length) == startsWith) {
                        for (var j = 0; ; j++) {
                            if (value[i + j] == endsWith[0]) {
                                if (value.Substring(i + j, endsWith.Length) == endsWith) break;
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
    }
}