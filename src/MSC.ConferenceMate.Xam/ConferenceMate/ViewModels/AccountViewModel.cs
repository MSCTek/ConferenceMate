using QuikRide.Interfaces;
using System.Threading.Tasks;

namespace QuikRide.ViewModels
{
    public class AccountViewModel : CustomViewModelBase
    {
        public AccountViewModel(INavigationService navService, IDataLoadService dataLoadService, IDataRetrievalService dataRetrievalService) : base(navService, dataLoadService, dataRetrievalService)
        {
        }

        public override async Task Init()
        {
            //await
        }
    }
}