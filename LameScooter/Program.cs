using System;
using System.Threading.Tasks;
using LameScooter.Rentals;
using LameScooter.Rentals.Data;

namespace LameScooter
{
    class Program
    {
        static async Task Main(string[] args) {

            if (args.Length is 0 or > 2) 
                throw new ArgumentException("Invalid parameters. Enter StationName or StationName Provider");
            
            ILameScooterRental rental;
            
            if(args.Length == 2) {
                rental = args[1].ToLower() switch {
                    "deprecated" => new DeprecatedLameScooterRental(),
                    "realtime" => new RealTimeLameScooterRental(),
                    "offline" => new OfflineLameScooterRental(),
                    _ => throw new ArgumentException("Valid arguments are deprecated, offline and realtime")
                };
            }
            else {
                rental = new OfflineLameScooterRental();
            }

            try {
                var count = await rental.GetScooterCountInStation(args[0]);
                Console.WriteLine($"Number of Scooters Available at {args[0]}: {count}");
            }
            catch (NotFoundException e) {
                Console.WriteLine("Could not find: " + e);
            }
            catch (ArgumentException e) {
                Console.Write("Invalid Argument: " + e);
            }
        }
    }
}