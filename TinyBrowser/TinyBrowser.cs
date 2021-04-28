using System;
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
    }
}