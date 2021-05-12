using System;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace LameScooter {
    public class RealTimeLameScooterRental : ILameScooterRental{
        
        const string Uri = "https://raw.githubusercontent.com/marczaku/GP20-2021-0426-Rest-Gameserver/main/assignments/scooters.json";
        
        public async Task<int> GetScooterCountInStation(string stationName) {
            
            Console.WriteLine("RealTime ScooterCount Request in progress.");
            if (stationName.Any(char.IsNumber))
                throw new ArgumentException("May not contain numbers.");
            
            var httpClient = new HttpClient();
            var json = await httpClient.GetStringAsync(Uri);
            var stationList = JsonConvert.DeserializeObject<LameScooterStationList>(json);
            
            foreach (var station in stationList.stations) {
                if (string.Compare(station.name, stationName, StringComparison.Ordinal) == 0) {
                    return station.bikesAvailable;
                }
            }
            throw new NotFoundException(stationName);
        }
    }
}