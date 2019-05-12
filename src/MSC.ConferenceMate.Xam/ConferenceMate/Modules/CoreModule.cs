using Ninject.Modules;
using ConferenceMate.Interfaces;
using ConferenceMate.Services;

namespace ConferenceMate.Modules
{
    public class CoreModule : NinjectModule
    {
        public override void Load()
        {
            Bind<IDatabase>().To<Database>().InSingletonScope();
            //Bind<IDataLoadService>().To<SampleDataLoadService>().InSingletonScope();
            Bind<IDataLoadService>().To<APIDataLoadService>().InSingletonScope();
            Bind<IDataRetrievalService>().To<DataRetrievalService>().InSingletonScope();
        }
    }
}