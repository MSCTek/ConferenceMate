using Ninject.Modules;
using ConferenceMate.Interfaces;
using ConferenceMate.iOS.Services;

namespace ConferenceMate.iOS.Modules
{
    public class IOSPlatformModule : NinjectModule
    {
        public override void Load()
        {
            Bind<ISQLite>().To<IOSSQLite>().InSingletonScope();
        }
    }
}