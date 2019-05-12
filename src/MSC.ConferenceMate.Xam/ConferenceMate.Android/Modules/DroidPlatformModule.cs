using Ninject.Modules;
using ConferenceMate.Android.Services;
using ConferenceMate.Interfaces;

namespace ConferenceMate.Droid.Modules
{
    public class DroidPlatformModule : NinjectModule
    {
        public override void Load()
        {
            Bind<ISQLite>().To<DroidSQLite>().InSingletonScope();
        }
    }
}