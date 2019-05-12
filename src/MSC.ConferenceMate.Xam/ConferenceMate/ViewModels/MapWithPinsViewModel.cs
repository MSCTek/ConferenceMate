using ConferenceMate.Interfaces;
using ConferenceMate.ModelsObj;
using ConferenceMate.SampleObjModels;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ConferenceMate.ViewModels
{
    public class MapWithPinsViewModel : CustomViewModelBase
    {
        public MapWithPinsViewModel(INavigationService navService, IDataLoadService dataLoadService, IDataRetrievalService dataRetrievalService)
            : base(navService, dataLoadService, dataRetrievalService)
        {
        }

        public override async Task Init()
        {
        }

        internal List<Location> GetLocations()
        {
            return new List<Location>() {
                SampleLocation.SampleCosleyZoo,
                SampleLocation.SampleHome,
                SampleLocation.SampleRockinJump,
                SampleLocation.SampleSafariLand
            };
        }
    }
}