using Ninject.Modules;
using QuikRide.Interfaces;
using QuikRide.Services;
using QuikRide.ViewModels;
using QuikRide.Views;
using Xamarin.Forms;

namespace QuikRide.Modules
{
    internal class NavigationModule : NinjectModule
    {
        private readonly INavigation _xfNav;
        private NavigationPage _navigationPage;

        public NavigationModule(NavigationPage navPage)
        {
            _navigationPage = navPage;
            _xfNav = navPage.Navigation;
        }

        public override void Load()
        {
            var navService = new NavigationService();

            RefreshNavModule(navService);

            if (Device.Idiom == TargetIdiom.Phone)
            {
                //for the phone
                //navService.RegisterViewMapping(typeof(myViewModel), typeof(myPage));
                navService.RegisterViewMapping(typeof(AboutViewModelMVVMDI), typeof(AboutPageMVVMDI_phone));
            }
            else
            {
                //for the tablet & desktop
                //navService.RegisterViewMapping(typeof(myViewModel), typeof(myPage));
                navService.RegisterViewMapping(typeof(AboutViewModelMVVMDI), typeof(AboutPageMVVMDI_tablet));
            }

            //Mappings for Views and ViewModels that do not change for tablets or phones
            navService.RegisterViewMapping(typeof(HomeViewModel), typeof(HomePage));
            navService.RegisterViewMapping(typeof(MyReservationRequestsViewModel), typeof(MyReservationRequestsPage));
            navService.RegisterViewMapping(typeof(MapViewModel), typeof(MapPage));
            navService.RegisterViewMapping(typeof(MapWithPinsViewModel), typeof(MapWithPinsPage));
            navService.RegisterViewMapping(typeof(UserLocationViewModel), typeof(UserLocationPage));
            navService.RegisterViewMapping(typeof(FeedbackViewModel), typeof(FeedbackPage));
            navService.RegisterViewMapping(typeof(GeofencingViewModel), typeof(GeofencingPage));
            navService.RegisterViewMapping(typeof(AccountViewModel), typeof(AccountPage));
            navService.RegisterViewMapping(typeof(BarcodeReaderViewModel), typeof(BarcodeReaderPage));
            navService.RegisterViewMapping(typeof(LoyaltyScannerViewModel), typeof(LoyaltyScannerPage));
            navService.RegisterViewMapping(typeof(LoyaltyBonusViewModel), typeof(LoyaltyBonusPage));

            Bind<INavigationService>().ToMethod(x => navService).InSingletonScope();
        }

        public void RefreshNavModule(NavigationService navService)
        {
            navService.NavigationPage = _navigationPage;
            navService.XamarinFormsNav = _navigationPage.Navigation;
        }
    }
}