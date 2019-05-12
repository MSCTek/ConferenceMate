using System.Threading.Tasks;

namespace ConferenceMate.Interfaces
{
    public interface IViewModelBase
    {
        bool IsBusy { get; set; }

        Task Init();
    }

    public interface IViewModelBaseWithParam<TParameter> : IViewModelBase
    {
        Task Init(TParameter parameter);
    }
}