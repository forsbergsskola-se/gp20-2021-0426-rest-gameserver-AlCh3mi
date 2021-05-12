using System.Threading.Tasks;

namespace LameScooter.Rentals.Data {
    public interface ILameScooterRental {
        Task<int> GetScooterCountInStation(string stationName);
    }
}