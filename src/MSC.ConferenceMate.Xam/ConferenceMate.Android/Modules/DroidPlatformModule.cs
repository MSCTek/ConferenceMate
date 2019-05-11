using Ninject.Modules;
using QuikRide.Android.Services;
using QuikRide.Interfaces;

namespace QuikRide.Droid.Modules
{
    public class DroidPlatformModule : NinjectModule
    {
        public override void Load()
        {
            Bind<ISQLite>().To<DroidSQLite>().InSingletonScope();
        }
    }
}