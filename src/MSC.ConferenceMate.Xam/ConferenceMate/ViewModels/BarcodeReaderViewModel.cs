using QuikRide.Interfaces;
using System.Threading.Tasks;

namespace QuikRide.ViewModels
{
    public class BarcodeReaderViewModel : CustomViewModelBase
    {
        public BarcodeReaderViewModel(INavigationService navService, IDataLoadService dataLoadService, IDataRetrievalService dataRetrievalService) : base(navService, dataLoadService, dataRetrievalService)
        {
        }

        public override async Task Init()
        {
        }
    }
}