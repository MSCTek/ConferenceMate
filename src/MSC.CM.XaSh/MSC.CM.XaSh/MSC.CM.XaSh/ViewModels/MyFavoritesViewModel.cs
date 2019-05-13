using System;
using System.Windows.Input;

using Xamarin.Forms;

namespace MSC.CM.XaSh.ViewModels
{
    public class MyFavoritesViewModel : BaseViewModel
    {
        public MyFavoritesViewModel()
        {
            Title = "My Favorites";

            //OpenWebCommand = new Command(() => Device.OpenUri(new Uri("https://xamarin.com/platform")));
        }

        //public ICommand OpenWebCommand { get; }
    }
}