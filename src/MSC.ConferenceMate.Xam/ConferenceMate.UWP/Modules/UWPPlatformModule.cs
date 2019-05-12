using Ninject.Modules;
using ConferenceMate.Interfaces;
using ConferenceMate.UWP.Services;

namespace ConferenceMate.UWP.Modules
{
    public class UWPPlatformModule : NinjectModule
    {
        public override void Load()
        {
            Bind<ISQLite>().To<UWPSQLite>().InSingletonScope();
        }
    }
}