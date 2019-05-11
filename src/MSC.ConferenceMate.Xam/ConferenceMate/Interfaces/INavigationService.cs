using QuikRide.ViewModels;
using System;
using System.ComponentModel;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace QuikRide.Interfaces
{
    public interface INavigationService
    {
        event PropertyChangedEventHandler CanGoBackChanged;

        bool CanGoBack { get; }

        Page GetCurrentView();

        Page GetLastView();

        CustomViewModelBase GetViewModel(Type viewModelType);

        Task GoBack();

        Task NavigateTo<TVM>() where TVM : IViewModelBase;

        Task NavigateTo<TVM, TParameter>(TParameter parameter) where TVM : IViewModelBaseWithParam<TParameter>;

        Task NavigateToNoAnimation<TVM>() where TVM : IViewModelBase;

        Task NavigateToNoAnimation<TVM, TParameter>(TParameter parameter) where TVM : IViewModelBaseWithParam<TParameter>;

        Task NavigateToUri(Uri uri);

        Task PopToRoot();

        void RemoveDuplicatePageByType(Type pageType);

        void RemoveLastView();

        void RemovePageByType(Type pageType);

        Task StartNavStack(Type pageType);
    }
}