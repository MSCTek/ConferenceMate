using MSC.CM.Xam.ModelObj.CM;
using System;
using System.Collections.Generic;
using System.Windows.Input;
using MSC.CM.Xam;
using Xamarin.Forms;
using System.Collections.ObjectModel;

namespace MSC.CM.XaSh.ViewModels
{
    public class AnnouncementsViewModel : BaseViewModel
    {
        public ObservableCollection<Announcement> Announcements { get; private set; }

        public AnnouncementsViewModel()
        {
            Title = "Announcements";
            Announcements = new ObservableCollection<Announcement>();
            Announcements.Add(Xam.ModelData.CM.DemoAnnouncement.SampleAnnouncement00.ToModelObj());
            Announcements.Add(Xam.ModelData.CM.DemoAnnouncement.SampleAnnouncement01.ToModelObj());
        }

    }
}