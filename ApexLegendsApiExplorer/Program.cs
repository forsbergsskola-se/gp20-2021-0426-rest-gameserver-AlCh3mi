using System;
using System.IO;
using System.Net;

namespace ApexLegendsApiExplorer
{
    
    //Apex API
    //X8MmHiCTDGB3tCgZe0iv
    
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(Request("https://api.mozambiquehe.re/maprotation?auth=X8MmHiCTDGB3tCgZe0iv"));
        }
        
        public static string Request(string url)
        {
            ServicePointManager.ServerCertificateValidationCallback = 
                (a, b, c, d) => true;            

            var req = (HttpWebRequest)WebRequest.Create(url);
            var resp = (HttpWebResponse)req.GetResponse();
            using var sr = new StreamReader(resp.GetResponseStream());
            var results = sr.ReadToEnd();
            
            return results;
        }
        
        
        
    }

    public class CurrentMap {
        public string Map;
        public TimeSpan Remaining;
        
        
    }
}


/*
using System.Net;
using System.IO;

namespace ReadCSVFromURL
{
    class Program
    {
        static void Main(string[] args)
        {
            SplitCSV();
        }

        public static string GetCSV(string url)
        {

            ServicePointManager.ServerCertificateValidationCallback = 
            (object a, System.Security.Cryptography.X509Certificates.X509Certificate b, System.Security.Cryptography.X509Certificates.X509Chain c, System.Net.Security.SslPolicyErrors d) => { return true; };            

            HttpWebRequest req = (HttpWebRequest)WebRequest.Create(url);
            HttpWebResponse resp = (HttpWebResponse)req.GetResponse();
            StreamReader sr = new StreamReader(resp.GetResponseStream());
            string results = sr.ReadToEnd();
            sr.Close();

            return results;
        }
        public static void SplitCSV()
        {
            List<string> splitted = new List<string>();
            string fileList = GetCSV("URL");
            string[] tempStr;
            tempStr = fileList.Split(',');
            foreach (string item in tempStr)
            {
                if (!string.IsNullOrWhiteSpace(item))
                {
                    splitted.Add(item);
                } 
            }
        }
    }
}

*/