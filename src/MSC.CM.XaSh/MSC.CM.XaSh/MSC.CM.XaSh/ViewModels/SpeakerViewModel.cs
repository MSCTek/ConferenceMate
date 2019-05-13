using System;
using System.Windows.Input;

using Xamarin.Forms;

namespace MSC.CM.XaSh.ViewModels
{
    public class SpeakerViewModel : BaseViewModel
    {
        public SpeakerViewModel()
        {
            Title = "Speakers";

            //OpenWebCommand = new Command(() => Device.OpenUri(new Uri("https://xamarin.com/platform")));
        }

        //public ICommand OpenWebCommand { get; }
    }
}