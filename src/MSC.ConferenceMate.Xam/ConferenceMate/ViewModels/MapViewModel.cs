using QuikRide.Interfaces;
using System.Threading.Tasks;

namespace QuikRide.ViewModels
{
    public class MapViewModel : CustomViewModelBase
    {
        public MapViewModel(INavigationService navService, IDataLoadService dataLoadService, IDataRetrievalService dataRetrievalService)
            : base(navService, dataLoadService, dataRetrievalService)
        {
        }

        public override async Task Init()
        {
        }
    }
}