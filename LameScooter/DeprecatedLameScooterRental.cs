using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace LameScooter {
    public class DeprecatedLameScooterRental : ILameScooterRental{
        public async Task<int> GetScooterCountInStation(string stationName) {
            
            Console.WriteLine("Deprecated ScooterCount Request in progress.");
            if (stationName.Any(char.IsNumber))
                throw new ArgumentException("May not contain numbers.");
            
            var json = await File.ReadAllTextAsync("scooters.txt");
            var stations = ToDictionary(json);
            
            try {
                return stations[stationName];
            }
            catch (KeyNotFoundException e) {
                throw new NotFoundException(stationName);
            }
        }

        Dictionary<string, int> ToDictionary(string fromTextFile) {
            Dictionary<string, int> tmp = new();
            using var reader = new StringReader(fromTextFile);
            string line;
            while ((line = reader.ReadLine()) != null)
            {
                var element = line.Split(':', StringSplitOptions.TrimEntries);
                tmp.Add(element[0], int.Parse(element[1]));
            }
            return tmp;
        }
    }
}