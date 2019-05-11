using Ninject.Modules;
using QuikRide.Interfaces;
using QuikRide.UWP.Services;

namespace QuikRide.UWP.Modules
{
    public class UWPPlatformModule : NinjectModule
    {
        public override void Load()
        {
            Bind<ISQLite>().To<UWPSQLite>().InSingletonScope();
        }
    }
}