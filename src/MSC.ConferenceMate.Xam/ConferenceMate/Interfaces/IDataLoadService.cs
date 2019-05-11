using System.Threading.Tasks;

namespace QuikRide.Interfaces
{
    public interface IDataLoadService
    {
        Task<bool> HeartbeatCheck();

        Task<int> LoadBarcodes();

        Task<int> LoadBarcodeTypes();

        Task<int> LoadBarcodeTypeTranslations();

        Task<int> LoadBusRoutes();

        Task<int> LoadBusRouteStops();

        Task<int> LoadBusRouteTranslations();

        Task<int> LoadFeedbackTypes();

        Task<int> LoadFeedbackTypeTranslations();

        Task<int> LoadLanguageTypes();

        Task<int> LoadLocations();

        Task<int> LoadReservationRequests();

        Task<int> LoadUser(int userId);

        Task<int> LoadUsers();

        Task<int> LoadVehicleBusRoutes();

        Task<int> LoadVehicleFeatureTypes();

        Task<int> LoadVehicles();

        Task<int> LoadVehicleStatusTypes();

        Task<int> LoadVehicleTypes();

        Task<int> LoadVehicleTypeVehicleFeatureTypes();

        Task<int> LoadVehicleVehicleFeatureTypes();
    }
}