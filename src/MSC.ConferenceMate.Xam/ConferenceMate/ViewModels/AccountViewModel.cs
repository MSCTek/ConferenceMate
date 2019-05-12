using ConferenceMate.Interfaces;
using System.Threading.Tasks;

namespace ConferenceMate.ViewModels
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