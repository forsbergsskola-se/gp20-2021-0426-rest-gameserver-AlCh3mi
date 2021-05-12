using System;
using System.Threading.Tasks;

namespace LameScooter
{
    class Program
    {
        static async Task Main(string[] args) {
            ILameScooterRental rental = null;
            var count = await rental.GetScooterCountInStation(null);
            Console.WriteLine("Number of Scooters Available at this Station: ");
        }
    }
}
