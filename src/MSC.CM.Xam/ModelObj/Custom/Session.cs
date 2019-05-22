using GalaSoft.MvvmLight;
using System;
using System.Collections.Generic;
using System.Text;

namespace MSC.CM.Xam.ModelObj.CM
{
    public partial class Session : ObservableObject
    {
        public string DateDisplay
        {
            get { return StartTime != null ? ((DateTime)StartTime).ToString("dd MMM yyyy") : string.Empty; }
        }

        public bool HasLikes
        {
            get { return SessionLikes.Count > 0; }
        }

        public string SpeakerList
        {
            get
            {
                string returnMe = string.Empty;
                if (SessionSpeakers != null)
                {
                    foreach (var s in SessionSpeakers)
                    {
                        if (s.User != null)
                        {
                            returnMe += $"{s.User.DisplayName} ";
                        }
                    }
                }
                return returnMe;
            }
        }

        public string StartEndTimeDisplay
        {
            get { return (StartTime != null && EndTime != null) ? $"{((DateTime)StartTime).ToString("h:mm tt")} - {((DateTime)EndTime).ToString("h:mm tt")}" : string.Empty; }
        }
    }
}