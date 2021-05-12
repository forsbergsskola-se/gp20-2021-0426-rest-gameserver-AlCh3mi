using System;
using System.Threading.Tasks;

namespace LameScooter
{
    class Program
    {
        static async Task Main(string[] args) {
            
            if (args.Length < 1) return;
            
            ILameScooterRental rental = new OfflineLameScooterRental();
            
            try {
                var count = await rental.GetScooterCountInStation(args[0]);
                Console.WriteLine($"Number of Scooters Available at {args[0]}: {count}");
            }
            catch (NotFoundException e) {
                Console.WriteLine("Could not find: " +e);
            }
            catch (ArgumentException e) {
                Console.Write("Invalid Argument: " +e);
            }
        }
    }
}