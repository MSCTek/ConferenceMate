using System;
using System.Windows.Input;

using Xamarin.Forms;

namespace MSC.CM.XaSh.ViewModels
{
    public class GeneralInfoViewModel : BaseViewModel
    {
        public GeneralInfoViewModel()
        {
            Title = "GeneralInfo";

#pragma warning disable CS4014 // Because this call is not awaited, execution of the current method continues before the call is completed
            base.CheckAppCenter();
#pragma warning restore CS4014 // Because this call is not awaited, execution of the current method continues before the call is completed
        }
    }
}