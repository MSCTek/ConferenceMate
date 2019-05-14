using System;
using System.Collections.ObjectModel;
using System.Windows.Input;
using MSC.CM.Xam.ModelObj.CM;
using Xamarin.Forms;
using MSC.CM.Xam;

namespace MSC.CM.XaSh.ViewModels
{
    public class SpeakerViewModel : BaseViewModel
    {
        public ObservableCollection<SessionSpeaker> Speakers { get; private set; }


        public SpeakerViewModel()
        {
            Title = "Speakers";
            Speakers = new ObservableCollection<SessionSpeaker>();

            var sample1 = Xam.ModelData.CM.DemoSessionSpeaker.SampleSessionSpeaker00.ToModelObj();
            sample1.User = Xam.ModelData.CM.DemoUser.SampleUser00.ToModelObj();
            var sample2 = Xam.ModelData.CM.DemoSessionSpeaker.SampleSessionSpeaker01.ToModelObj();
            sample2.User = Xam.ModelData.CM.DemoUser.SampleUser01.ToModelObj();

            Speakers.Add(sample1);
            Speakers.Add(sample2);
        }

    }
}