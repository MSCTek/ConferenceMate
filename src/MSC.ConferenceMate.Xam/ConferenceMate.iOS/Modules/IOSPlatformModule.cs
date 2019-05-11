using Ninject.Modules;
using QuikRide.Interfaces;
using QuikRide.iOS.Services;

namespace QuikRide.iOS.Modules
{
    public class IOSPlatformModule : NinjectModule
    {
        public override void Load()
        {
            Bind<ISQLite>().To<IOSSQLite>().InSingletonScope();
        }
    }
}