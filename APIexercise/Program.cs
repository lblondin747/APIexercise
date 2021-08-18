using System;
using Newtonsoft.Json.Linq;
using System.Net.Http;
using System.Threading;

namespace APIexercise
{
    class Program
    {
        static void Main(string[] args)
        {
            var kanyeUrl = "https://api.kanye.rest";
            var kanyeClient = new HttpClient();
            var kanyeResponse = kanyeClient.GetStringAsync(kanyeUrl).Result;
            var kanyeQuote = JObject.Parse(kanyeResponse).GetValue("quote").ToString();
            

            var ronUrl = "https://ron-swanson-quotes.herokuapp.com/v2/quotes";
            var ronClient = new HttpClient();
            var ronResponse = ronClient.GetStringAsync(ronUrl).Result;
            var ronQuote = JArray.Parse(ronResponse).ToString().Replace('[', ' ').Replace(']', ' ').Replace('"', ' ').Trim();
            

            for(int i = 0; i <= 5; i++)
            {
                Console.Write("Kanye West:");
                Console.Write(kanyeQuote);
                Console.WriteLine();
                Thread.Sleep(kanyeQuote.Length*40);
                Console.Write("Ron Swanson:");
                Console.Write(ronQuote);
                Console.WriteLine();
                Thread.Sleep(ronQuote.Length*40);
                kanyeResponse = kanyeClient.GetStringAsync(kanyeUrl).Result;
                kanyeQuote = JObject.Parse(kanyeResponse).GetValue("quote").ToString();
                ronResponse = ronClient.GetStringAsync(ronUrl).Result;
                ronQuote = JArray.Parse(ronResponse).ToString().Replace('[', ' ').Replace(']', ' ').Replace('"', ' ').Trim();



            }
        }
    }
}