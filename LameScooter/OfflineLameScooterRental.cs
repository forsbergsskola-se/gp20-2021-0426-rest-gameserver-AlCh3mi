using System;
using System.IO;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace LameScooter {
    public class OfflineLameScooterRental : ILameScooterRental {
        readonly char[] forbiddenChars = {'1', '2', '3', '4', '5', '6', '7','8', '9', '0'};
        public async Task<int> GetScooterCountInStation(string stationName) {

            foreach (var invalidChar in forbiddenChars) {
                if (stationName.Contains(invalidChar))
                    throw new ArgumentException("May not contain numbers.");
            }
            
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