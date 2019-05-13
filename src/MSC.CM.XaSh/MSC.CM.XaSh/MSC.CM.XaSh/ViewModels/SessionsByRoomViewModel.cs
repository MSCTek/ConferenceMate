using System;
using System.Collections.ObjectModel;
using System.Windows.Input;
using MSC.CM.Xam.ModelObj.CM;
using Xamarin.Forms;
using MSC.CM.Xam;

namespace MSC.CM.XaSh.ViewModels
{
    public class SessionsByRoomViewModel : BaseViewModel
    {
        public ObservableCollection<Session> Sessions { get; private set; }


        public SessionsByRoomViewModel()
        {
            Title = "Sessions By Room";
            Sessions = new ObservableCollection<Session>();
            Sessions.Add(Xam.ModelData.CM.DemoSession.SampleSession00.ToModelObj());
            Sessions.Add(Xam.ModelData.CM.DemoSession.SampleSession01.ToModelObj());
            Sessions.Add(Xam.ModelData.CM.DemoSession.SampleSession02.ToModelObj());
            Sessions.Add(Xam.ModelData.CM.DemoSession.SampleSession03.ToModelObj());
            Sessions.Add(Xam.ModelData.CM.DemoSession.SampleSession04.ToModelObj());
            Sessions.Add(Xam.ModelData.CM.DemoSession.SampleSession05.ToModelObj());
        }

    }
}