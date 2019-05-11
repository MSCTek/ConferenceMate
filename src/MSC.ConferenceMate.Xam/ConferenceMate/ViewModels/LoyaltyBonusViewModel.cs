using QuikRide.Interfaces;
using System.Threading.Tasks;

namespace QuikRide.ViewModels
{
    public class LoyaltyBonusViewModel : CustomViewModelBase
    {
        public LoyaltyBonusViewModel(INavigationService navService, IDataLoadService dataLoadService, IDataRetrievalService dataRetrievalService) : base(navService, dataLoadService, dataRetrievalService)
        {
        }

        public override async Task Init()
        {
        }
    }
}