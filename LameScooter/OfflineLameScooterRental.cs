using System;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace LameScooter {
    public class OfflineLameScooterRental : ILameScooterRental {
        
        public async Task<int> GetScooterCountInStation(string stationName) {

            Console.WriteLine("Offline ScooterCount Request in progress.");
            if (stationName.Any(char.IsNumber))
                throw new ArgumentException("May not contain numbers.");
            
            var json = await File.ReadAllTextAsync("Scooters.json");
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